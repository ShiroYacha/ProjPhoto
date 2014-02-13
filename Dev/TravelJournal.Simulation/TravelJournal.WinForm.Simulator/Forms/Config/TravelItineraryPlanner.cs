using GenericUndoRedo;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelJournal.WinForm.Simulator.Controls;
using TravelJournal.WinForm.Simulator.Rendering;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class TravelItineraryPlanner : ConfigFormTravelItineraryData
    {
        private UndoRedoHistory<TravelItineraryPlanner> history;

        public TravelItineraryPlanner()
        {
            InitializeComponent();
            // Memento initializing
            history = new UndoRedoHistory<TravelItineraryPlanner>(this, 100);
            // Map control initializing
            travelMapPlayer.GMapControl.MouseClick += OnClickEventHandler;
            travelMapPlayer.GMapControl.OnMarkerClick += OnMarkerClickEventHandler;
            // Rendering
            RenderToolStrip();
        }

        public TravelItineraryData TravelItineraryData
        {
            get
            {
                return Data as TravelItineraryData;
            }
            set
            {
                Data = value;
            }
        }

        protected override void OnDataSet(TravelItineraryData data)
        {
            base.OnDataSet(data);
            // Update view
            UpdateView(data);
        }
        protected override void OnDataChanging(TravelItineraryData data)
        {
            if(!history.InUndoRedo)
                history.Do(new TravelItineraryDataMemento(data));
        }
        protected override void OnDataChanged(TravelItineraryData data)
        {
            // Update view
            UpdateView(data);
        }

        private void UpdateView(TravelItineraryData data)
        {
            undoButton.Enabled = history.CanUndo;
            redoButton.Enabled = history.CanRedo;
            setTimeIntervalTextBox.Text = data.TimeIntervalPerAnchor.ToString();
            setCameraNumTextBox.Text = data.CameraRadius.ToString();
            // Map
            if (data.Anchors != null)
                travelMapPlayer.SetAnchors(data.Anchors);
            if (data.HomePlacemark.CountryName != null)
                travelMapPlayer.SetHomePlace(data.HomePlacemark);
            travelMapPlayer.DisconnectAnchors();
        }
        private void RenderToolStrip()
        {
            // Use the vs2013-like dark theme
            toolStrip.Renderer = new DarkThemeToolStripRenderer();
            // Render menu strip color
            toolStrip.BackColor = Color.FromArgb(38, 38, 38);
            // Define fore color
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.ForeColor = Color.White;
                if (item is ToolStripDropDownButton)
                    foreach (ToolStripItem subItem in (item as ToolStripDropDownButton).DropDownItems)
                    {
                        subItem.ForeColor = Color.White;
                    }
            }
        }
        
        private void TravelItineraryPlanner_Load(object sender, EventArgs e)
        {
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (history.CanUndo)
            {
                history.Undo();
                UpdateView(data);
            }
        }
        private void redoButton_Click(object sender, EventArgs e)
        {
            if (history.CanRedo)
            {
                history.Redo();
                UpdateView(data);
            }
        }
        private void setTimeIntervalTextBox_Validating(object sender, CancelEventArgs e)
        {
            long value;
            TravelItineraryData dt = data as TravelItineraryData;
            if (long.TryParse(setTimeIntervalTextBox.Text, out value))
                dt.TimeIntervalPerAnchor = value;
            else
            {
                e.Cancel = true;
                setTimeIntervalTextBox.Text = dt.TimeIntervalPerAnchor.ToString();
            }
        }
        private void setCameraNumTextBox_Validating(object sender, CancelEventArgs e)
        {
            float value;
            TravelItineraryData dt = data as TravelItineraryData;
            if (float.TryParse(setCameraNumTextBox.Text, out value))
                dt.CameraRadius = value;
            else
            {
                e.Cancel = true;
                setCameraNumTextBox.Text = dt.CameraRadius.ToString();
            }
        }
        private void placeStartButton_Click(object sender, EventArgs e)
        {
            placeAnchorButton.Checked = false;
        }
        private void placeAnchorButton_Click(object sender, EventArgs e)
        {
            placeStartButton.Checked = false;
        }
        private void placeCameraSpotButton_Click(object sender, EventArgs e)
        {
            placeStartButton.Checked = false;
            placeAnchorButton.Checked = false;
        }
        private void clearMarkersButton_Click(object sender, EventArgs e)
        {
            TravelItineraryData.ClearAnchors();
        }

        private void OnClickEventHandler(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.Button == MouseButtons.Right)
            {
                if (placeStartButton.Checked)
                {
                    // Place start point
                    Placemark placemark = travelMapPlayer.ConvertToPlacemark(me.Location);
                    TravelItineraryData.HomePlacemark = placemark;
                    UpdateView(data);
                }
                else if (placeAnchorButton.Checked)
                {
                    // Place anchor 
                    SimulationModelPoint point = travelMapPlayer.ConvertToSimulationModelPoint(me.Location);
                    TravelItineraryData.AddAnchor(point);
                    UpdateView(data);
                }
            }
        }
        private void OnMarkerClickEventHandler(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && item.Overlay.Id == TravelMapPlayer.ID_ANCHORS_LAYER)
            {
                int index = travelMapPlayer.GetAnchorIndex(item);
                // Create config dialog
                TrackBarConfigDialog dialog = new TrackBarConfigDialog();
                dialog.Text = "Set the number of photos of the spot.";
                dialog.InitializeData(0, 20, data.Anchors[index].PhotoGenNumber);
                dialog.ShowDialog();
                // Set photo number
                data.SetAnchorPhotoGenNumber(index, dialog.Data);
                // Update view
                UpdateView(data);
            }
        }

        private void connectAnchorsButton_Click(object sender, EventArgs e)
        {
            toolStrip.Enabled = false;
            SimulationDataCompiler compiler = new SimulationDataCompiler(data.CameraRadius);
            TravelItineraryData compiledData = compiler.Compile(data);
            UpdateView(compiledData);
            travelMapPlayer.ConnectAnchors();
            toolStrip.Enabled = true;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateView(data);
        }
    }

    public class TravelItineraryDataMemento : IMemento<TravelItineraryPlanner>
    {
        string xmlStream;

        public TravelItineraryDataMemento(TravelItineraryData data)
        {
            xmlStream = XmlSerialization.SerializeString<TravelItineraryData>(data);
        }

        public IMemento<TravelItineraryPlanner> Restore(TravelItineraryPlanner target)
        {
            IMemento<TravelItineraryPlanner> inverse = new TravelItineraryDataMemento(target.TravelItineraryData);
            target.TravelItineraryData = XmlSerialization.DeserializeString<TravelItineraryData>(xmlStream);
            return inverse;
        }
    }

    #region Workaround for UI
    public class ConfigFormTravelItineraryData : ConfigForm<TravelItineraryData> { } 
    #endregion
}
