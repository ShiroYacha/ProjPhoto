using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelJournal.PCL;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    public class TravelSimulator
    {
        public event Action OnSimulatorStatusChanged;

        private Timer timer;
        private TravelMapPlayer player;

        private TravelItineraryData data;
        private SimulationModelPoint currentPosition;
        private List<SimulationModelPoint> photos=new List<SimulationModelPoint>();

        private int currentIndex;
        private int currentSegmentCount;
        private double currentSegmentLatStep;
        private double currentSegmentLngStep;
        private int currentSegmentIndex;
        private bool isConnected;

        public TravelSimulator(TravelMapPlayer player)
        {
            this.player = player;
            this.isConnected = false;
        }

        #region Private members
        private void CalculateSegmentLength()
        {
            if (currentIndex >= data.Anchors.Count)
            {
                PauseSimulation();
            }
            else
            // Get start and end point
            {
                SimulationModelPoint startPoint = data.Anchors[currentIndex];
                SimulationModelPoint endPoint = data.Anchors[currentIndex == data.Anchors.Count - 1 ? 0 : currentIndex + 1];
                // Calculate segment count
                long interval = startPoint.CustomTimeInterval == 0 ? data.TimeIntervalPerAnchor : startPoint.CustomTimeInterval;
                currentSegmentCount = (int)(interval / TravelJournalSimulation.generalSettings.SimualtionStep);
                // Initialize segment index
                currentSegmentIndex = 0;
                // Calculate segment step
                currentSegmentLatStep = (endPoint.Gps.Lat - startPoint.Gps.Lat) / currentSegmentCount;
                currentSegmentLngStep = (endPoint.Gps.Lng - startPoint.Gps.Lng) / currentSegmentCount;
            }
        }
        private void OnStep()
        {
            if (currentSegmentIndex >= currentSegmentCount - 1)
            {
                // Calculate new segment
                currentIndex++;
                CalculateSegmentLength();
                SimulationModelPoint point = data.Anchors.First();
                player.SetAnchors(new List<SimulationModelPoint>() { point });
                currentSegmentIndex++;
                // Update current position
                currentPosition = point;
            }
            else if (currentSegmentIndex == 0) // Draw first point
            {
                SimulationModelPoint point = data.Anchors.First();
                player.SetAnchors(new List<SimulationModelPoint>() { point });
                currentSegmentIndex++;
                // Update current position
                currentPosition = point;
            }
            else // Draw next segment using the linear model
            {
                // Take pasted anchors
                List<SimulationModelPoint> points = new List<SimulationModelPoint>(data.Anchors.Take(currentIndex + 1));
                SimulationModelPoint lastPoint = points.Last();
                // Calculate current anchor (linear interpolation)
                SimulationModelPoint interPoint;
                if (currentSegmentIndex == currentSegmentCount - 2)
                {
                    interPoint = data.Anchors[currentIndex == data.Anchors.Count - 1 ? 0 : currentIndex + 1]; ;
                }
                else
                {
                    // linear interpolation
                    interPoint = new SimulationModelPoint() { CustomTimeInterval = lastPoint.CustomTimeInterval };
                    interPoint.Gps = new PointLatLng(lastPoint.Gps.Lat + currentSegmentLatStep * currentSegmentIndex, lastPoint.Gps.Lng + currentSegmentLngStep * currentSegmentIndex);
                }
                points.Add(interPoint);
                // Update current position
                currentPosition = interPoint;
                // Draw anchors
                player.SetAnchors(points, TravelJournalSimulation.InAutoZoomMode, AnchorMode.ShowOnlyPhotoAnchors);
                // Draw routes
                player.ConnectAnchors();
                currentSegmentIndex++;
                // Update photos
                photos.Clear();
                photos.AddRange(points.Where((point) => { return point.PhotoGenNumber > 0; }));
                // Inspect information
#if DEBUG
                TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { 
            {"Current index", currentIndex}, 
            {"Current segment index",currentSegmentIndex},
            {"Current segment count", currentSegmentCount}
            });
#endif
                TravelJournalSimulation.UpdateInfoInspector(new Dictionary<string, object>() { 
            {"Photo count", photos.Count}, 
            });
            }
        } 
        #endregion

        #region Public members
        public bool IsReady
        {
            get { return IsConnected&&data != null && data.IsComplete && data.IsCompiled; }
        }
        public bool ValidateData(TravelItineraryData data)
        {
            if (data.IsComplete)
            {
                if (!data.IsCompiled)
                {
                    TravelSimulationDataCompiler compiler = new TravelSimulationDataCompiler(data.CameraRadius);
                    this.data = compiler.Compile(data);
                }
                else
                    this.data = data;
                if (OnSimulatorStatusChanged!=null) OnSimulatorStatusChanged();
                return true;
            }
            else
                return false;
        }
        public bool IsConnected 
        {
            get
            {
                return isConnected;
            }
            set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    if (OnSimulatorStatusChanged != null) OnSimulatorStatusChanged();
                }
            }
        }
        public void StartSimulation()
        {
            if (timer == null)
            {
                // Log
                TravelJournalSimulation.Log(LogType.Info, "Simulator started.");
                // Preparation
                currentIndex = 0;
                CalculateSegmentLength();
                // Launch 
                timer = new Timer((o) => { OnStep(); }, null, 0,TravelJournalSimulation.generalSettings.SimualtionStep);
            }
            else
            {
                // Log
                TravelJournalSimulation.Log(LogType.Info, "Simulator resumed.");
                // Resume 
                timer.Change(1000, TravelJournalSimulation.generalSettings.SimualtionStep);
            }
        }
        public void PauseSimulation()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                TravelJournalSimulation.Log(LogType.Info, "Simulation paused.");
            }
        }
        public void ResetSimulation()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
                player.SetAnchors(new List<SimulationModelPoint>() { data.Anchors.First() }, true, AnchorMode.ShowAllAnchors);
                player.DisconnectAnchors();
                TravelJournalSimulation.Log(LogType.Info, "Simulation reset.");
            }
        }
        public void CloseDown()
        {
            ResetSimulation();
            timer = null;
        }

        public GpsPoint GetCurrentGps()
        {
            if (currentPosition != null)
                return new GpsPoint() { Latitude = currentPosition.Gps.Lat, Longitude = currentPosition.Gps.Lng, TimeStamp = DateTime.Now };
            else return null;
        }
        #endregion
    }
}
