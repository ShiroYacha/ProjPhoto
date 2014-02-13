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
    public partial class PropertyConfigForm<T> : ConfigForm<T> where T : IConfigData
    {
        public PropertyConfigForm()
        {
            InitializeComponent();
        }

        protected override void OnDataSet(T data)
        {
            base.OnDataSet(data);
            propertyGrid.SelectedObject = data;
        }

        protected override void OnDataChanging(T data)
        {
            throw new NotImplementedException();
        }

        protected override void OnDataChanged(T data)
        {
            throw new NotImplementedException();
        }
    }
}
