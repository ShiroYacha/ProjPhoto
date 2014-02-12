using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelJournal.WinForm.Simulator.Rendering;

namespace TravelJournal.WinForm.Simulator.Forms
{
    public partial class TravelItineraryPlanner : ConfigForm
    {
        public TravelItineraryPlanner()
        {
            InitializeComponent();
            // Rendering
            RenderToolStrip();
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
    }
}
