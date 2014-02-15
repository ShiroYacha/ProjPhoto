using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TravelJournal.WinForm.Simulator.Controls;

namespace TravelJournal.WinForm.Simulator
{
    public class TravelSimulator
    {
        private TravelJournalGenerationSimulation main;
        private Timer timer;

        private TravelItineraryData data;

        private int currentIndex;
        private int currentSegmentCount;
        private double currentSegmentLatStep;
        private double currentSegmentLngStep;
        private int currentSegmentIndex;

        public TravelSimulator(TravelJournalGenerationSimulation main)
        {
            this.main = main;
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
                return true;
            }
            else
                return false;  
        }

        public void StartSimulation()
        {
            // Preparation
            currentIndex = 0;
            CalculateSegmentLength();
            // Launch 
            timer = new Timer((o) => { OnStep(); }, null, 1000, TravelJournalGenerationSimulation.generalSettings.SimualtionStep);
        }

        private void CalculateSegmentLength()
        {
            if (currentIndex == data.Anchors.Count)
            {
                ResetSimulation();
            }
            else
            // Get start and end point
            {
                SimulationModelPoint startPoint = data.Anchors[currentIndex];
                SimulationModelPoint endPoint = data.Anchors[currentIndex == data.Anchors.Count - 1 ? 0 : currentIndex + 1];
                // Calculate segment count
                long interval = startPoint.CustomTimeInterval == 0 ? data.TimeIntervalPerAnchor : startPoint.CustomTimeInterval;
                currentSegmentCount = (int)(interval / TravelJournalGenerationSimulation.generalSettings.SimualtionStep);
                // Initialize segment index
                currentSegmentIndex = 0;
                // Calculate segment step
                currentSegmentLatStep = endPoint.Gps.Lat - startPoint.Gps.Lat;
                currentSegmentLngStep = endPoint.Gps.Lng - startPoint.Gps.Lng;
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
                main.Player.SetAnchors(new List<SimulationModelPoint>() { point });
                currentSegmentIndex++;
            }
            else if (currentSegmentIndex == 0) // Draw first point
            {
                SimulationModelPoint point = data.Anchors.First();
                main.Player.SetAnchors(new List<SimulationModelPoint>() { point });
                currentSegmentIndex++;
            }
            else // Draw next segment using the linear model
            {
                // Take pasted anchors
                List<SimulationModelPoint> points = new List<SimulationModelPoint>(data.Anchors.Take(currentIndex+1));
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
                    interPoint.Gps = new PointLatLng(lastPoint.Gps.Lat + currentSegmentLatStep, lastPoint.Gps.Lng + currentSegmentLngStep);
                }
                points.Add(interPoint);
                main.Player.SetAnchors(points);
                currentSegmentIndex++;
            }
        }

        public void PauseSimulation()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void ResetSimulation()
        {
            PauseSimulation();
            timer.Dispose();
        }
    }
}
