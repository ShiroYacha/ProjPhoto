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
    public partial class PropertyConfigForm : ConfigForm
    {
        public PropertyConfigForm()
        {
            InitializeComponent();
        }

        public override IConfigData Data
        {
            get
            {
                return base.Data;
            }
            set
            {
                base.Data = value;
                propertyGrid.SelectedObject = data;
            }
        }
    }
}
