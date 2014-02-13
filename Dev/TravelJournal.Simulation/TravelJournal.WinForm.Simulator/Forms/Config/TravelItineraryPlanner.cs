using GenericUndoRedo;
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
using TravelJournal.WinForm.Simulator.Rendering;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class TravelItineraryPlanner : ConfigForm,ITravelItineraryDataOwner
    {
        private UndoRedoHistory<ITravelItineraryDataOwner> history;

        public TravelItineraryPlanner()
        {
            InitializeComponent();
            // Rendering
            RenderToolStrip();
            // Memento initializing
            history = new UndoRedoHistory<ITravelItineraryDataOwner>(this, 100);
            // Map control initializing
            travelMapPlayer.RegisterMouseClickHandler(OnClickEventHandler);
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

        protected override void OnDataSet(IConfigData data)
        {
            TravelItineraryData dt = data as TravelItineraryData;
            base.OnDataSet(dt);
            // Update view
            UpdateView(data);
        }
        protected override void OnDataChanging(IConfigData data)
        {
            if(!history.InUndoRedo)
                history.Do(new TravelItineraryDataMemento(data as TravelItineraryData));
        }
        protected override void OnDataChanged(IConfigData data)
        {
            // Update view
            UpdateView(data);
        }

        private void UpdateView(IConfigData data)
        {
            TravelItineraryData dt = data as TravelItineraryData;
            undoButton.Enabled = history.CanUndo;
            redoButton.Enabled = history.CanRedo;
            setTimeIntervalTextBox.Text = dt.TimeIntervalPerAnchor.ToString();
            setCameraNumTextBox.Text = dt.CameraProbPerSpot.ToString();
            // Map
            if (dt.Anchors != null)
                travelMapPlayer.SetAnchors(dt.Anchors);
            if (dt.CameraSpots != null)
                travelMapPlayer.SetCameraSpots(dt.CameraSpots);

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
                dt.CameraProbPerSpot = value;
            else
            {
                e.Cancel = true;
                setCameraNumTextBox.Text = dt.CameraProbPerSpot.ToString();
            }
        }
        private void placeStartButton_Click(object sender, EventArgs e)
        {
            placeAnchorButton.Checked = false;
            placeCameraSpotButton.Checked = false;
        }
        private void placeAnchorButton_Click(object sender, EventArgs e)
        {
            placeStartButton.Checked = false;
            placeCameraSpotButton.Checked = false;
        }
        private void placeCameraSpotButton_Click(object sender, EventArgs e)
        {
            placeStartButton.Checked = false;
            placeAnchorButton.Checked = false;
        }
        private void clearMarkersButton_Click(object sender, EventArgs e)
        {
            TravelItineraryData.ClearAnchorsAndCameraSpots();
        }


        private void OnClickEventHandler(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.Button == MouseButtons.Right)
            {
                if (placeStartButton.Checked)
                {
                    // Place start point

                }
                else if (placeAnchorButton.Checked)
                {
                    // Place anchor 
                    GpsPoint point = travelMapPlayer.ConvertToGpsPoint(me.Location);
                    TravelItineraryData.AddAnchor(point);
                    UpdateView(data);
                }
                else if (placeCameraSpotButton.Checked)
                {
                    // Place camera spot 
                    GpsPoint point = travelMapPlayer.ConvertToGpsPoint(me.Location);
                    TravelItineraryData.AddCameraSpot(point);
                    UpdateView(data);
                }
            }
        }

    }

    public interface ITravelItineraryDataOwner
    {
        TravelItineraryData TravelItineraryData { get; set; }
    }

    public class TravelItineraryDataMemento : IMemento<ITravelItineraryDataOwner>
    {
        string xmlStream;

        public TravelItineraryDataMemento(TravelItineraryData data)
        {
            xmlStream = XmlSerialization.SerializeString<TravelItineraryData>(data);
        }

        public IMemento<ITravelItineraryDataOwner> Restore(ITravelItineraryDataOwner target)
        {
            IMemento<ITravelItineraryDataOwner> inverse = new TravelItineraryDataMemento(target.TravelItineraryData);
            target.TravelItineraryData = XmlSerialization.DeserializeString<TravelItineraryData>(xmlStream);
            return inverse;
        }
    }
}
