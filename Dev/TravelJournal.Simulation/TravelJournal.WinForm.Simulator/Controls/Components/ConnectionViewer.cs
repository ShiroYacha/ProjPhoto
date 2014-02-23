using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TravelJournal.WinForm.Simulator.Controls.Components
{
    public partial class ConnectionViewer : UserControl, ITestControl
    {
        private System.Threading.Timer updateTimer;
        private List<decimal> values = new List<decimal>();

        public ConnectionViewer()
        {
            InitializeComponent();
            // Rendering
            perfChart.TimerInterval = 2000;
            perfChart.ScaleMode = ScaleMode.Relative;
            perfChart.PerfChartStyle.AvgLinePen.Color = Color.Silver;
            perfChart.PerfChartStyle.ChartLinePen.Color = Color.DodgerBlue;
        }

        public void Initialize()
        {
            // Clear data
            values.Clear();
            // Stop timer
            if(updateTimer!=null) updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
            // Clear chart
            perfChart.Clear();
            perfChart.TimerMode = TimerMode.Disabled;
        }

        public void Run()
        {
            perfChart.TimerMode = TimerMode.Simple;
            updateTimer = new System.Threading.Timer((o) => { UpdatePoints(); }, null, 0, 100);
        }

        public void RunTest()
        {
            perfChart.TimerMode = TimerMode.Simple;
            updateTimer = new System.Threading.Timer((o) => { TestWork(); }, null, 1000, 1000);
        }

        public void AddValue(decimal value)
        {
            values.Add(value);
            if (perfChart.TimerMode == TimerMode.Disabled && values.Count > 0)
                Run();
        }

        private void UpdatePoints()
        {
            foreach (decimal value in values)
                perfChart.AddValue(value);
            values.Clear();
        }

        private void TestWork()
        {
            Random random = new Random();
            perfChart.AddValue((decimal)random.NextDouble()*100);
            Thread.Sleep(1000);
        }


    }
}
