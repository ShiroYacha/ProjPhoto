using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class TrackBarConfigDialog : Form 
    {
        private const int SMALL_INTERVAL = 10;
        private const int BIG_INTERVAL = 3;

        public int Data { get { return trackBar.Value; } }

        public TrackBarConfigDialog()
        {
            InitializeComponent();
        }

        public void InitializeData(int min, int max, int data = default(int))
        {
            trackBar.Minimum = min;
            trackBar.Maximum = max;
            trackBar.Value = data;
            trackBar.SmallChange = (max - min) / SMALL_INTERVAL;
            trackBar.LargeChange = (max - min) / BIG_INTERVAL;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            valueLabel.Text = trackBar.Value.ToString();
        }

        private void TrackBarConfigDialog_Load(object sender, EventArgs e)
        {
            valueLabel.Text = trackBar.Value.ToString();
        }

        
    }
}
