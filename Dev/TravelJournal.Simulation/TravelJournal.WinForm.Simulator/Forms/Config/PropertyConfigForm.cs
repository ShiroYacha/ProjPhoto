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

        protected override void OnDataSet(IConfigData data)
        {
            base.OnDataSet(data);
            propertyGrid.SelectedObject = data;
        }

        protected override void OnDataChanging(IConfigData data)
        {
            throw new NotImplementedException();
        }

        protected override void OnDataChanged(IConfigData data)
        {
            throw new NotImplementedException();
        }
    }
}
