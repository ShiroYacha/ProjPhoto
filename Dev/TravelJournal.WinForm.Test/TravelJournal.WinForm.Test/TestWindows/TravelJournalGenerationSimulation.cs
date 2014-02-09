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

namespace TravelJournal.WinForm.Test
{
    public partial class TravelJournalGenerationSimulation : UserControl , ITestWindow
    {
        public TravelJournalGenerationSimulation()
        {
            InitializeComponent();
        }

        public string TestName
        {
            get { return "Travel journal generation"; }
        }

        public string TestDescription
        {
            get { return "Simulate a travel behavior and assemble the travel journals."; }
        }

        public string TestIconPath
        {
            get { return "appbar.map.treasure.png"; }
        }

        private void InvokeMethod(Action action)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
                action();
            }));
        }

        public void UpdateInfoInspector(SortedDictionary<string, string> infoDict)
        {
            InvokeMethod(() =>
            {
                infoInspector.UpdateInfo(infoDict);
            });
        }

        private void TestWithTimer(Action action)
        {
            System.Threading.Timer timer = new System.Threading.Timer((o) => { action(); }, null, 1000, 500);
        }

        private void TestInfoInspector()
        {
            TestWithTimer(() =>
            {
                SortedDictionary<string, string> infoDict = new SortedDictionary<string, string>();
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                    infoDict.Add("test" + i, rnd.Next(100).ToString());
                UpdateInfoInspector(infoDict);
            });
        }

        private void TravelJournalGenerationSimulation_Load(object sender, EventArgs e)
        {
            TestInfoInspector();
        }

    }
}
