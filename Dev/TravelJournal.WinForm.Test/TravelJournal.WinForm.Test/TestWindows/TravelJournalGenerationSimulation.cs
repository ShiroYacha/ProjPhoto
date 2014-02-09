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
using TravelJournal.WinForm.Test.Controls;
using System.Runtime.CompilerServices;

namespace TravelJournal.WinForm.Test
{
    public partial class TravelJournalGenerationSimulation : UserControl , ITestWindow
    {
        List<System.Threading.Timer> timers = new List<System.Threading.Timer>();

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

        public void UpdateInfoInspector(Dictionary<string, string> infoDict)
        {
            InvokeMethod(() =>
            {
                infoInspector.UpdateInfo(infoDict);
            });
        }

        public void Log(LogType type, string log,[CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine=-1)
        {
            InvokeMethod(() =>
           {
               logger.Log(type, log, callerName, callerFilePath, callerLine);
           });
        }

        private void TravelJournalGenerationSimulation_Load(object sender, EventArgs e)
        {
            TestInfoInspector();
            TestLogger();
            TestStateMachineViewer();
        }

        private void TravelJournalGenerationSimulation_Leave(object sender, EventArgs e)
        {
            foreach(System.Threading.Timer timer in timers)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }
        }

        #region Test
        private void TestWithTimer(Action action)
        {
            Random rnd = new Random();
            timers.Add(new System.Threading.Timer((o) => { action(); }, null, 1000, rnd.Next(500, 1000)));
        }

        private void TestInfoInspector()
        {
            TestWithTimer(() =>
            {
                Dictionary<string, string> infoDict = new Dictionary<string, string>();
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                    infoDict.Add("test " + i, rnd.Next(100).ToString());
                UpdateInfoInspector(infoDict);
            });
        }

        private void TestLogger()
        {
            TestWithTimer(() =>
            {
                Random rnd = new Random();
                Log((LogType)rnd.Next(3), string.Format("This is a test log"));
            });
        }

        private void TestStateMachineViewer()
        {
            Size size = new Size(12, 14);
            State S0 = new State() { Row = 2, Column = 4, ID = 0 };
            State S1 = new State() { Row = 4, Column = 6, ID = 1 };
            State S2 = new State() { Row = 6, Column = 4, ID = 2 };
            State S3 = new State() { Row = 6, Column = 8, ID = 3 };
            State S4 = new State() { Row = 8, Column = 6, ID = 4 };
            State S5 = new State() { Row = 10, Column = 4, ID = 5 };
            S0.ToStates = new List<State>() { S1 };
            S1.ToStates = new List<State>() { S2, S3 };
            S2.ToStates = new List<State>() { S4 };
            S3.ToStates = new List<State>() { S4 };
            S4.ToStates = new List<State>() { S1, S5 };
            stateMachineViewer.ViewerSize = size;
            stateMachineViewer.AddState(S0).AddState(S1).AddState(S2).AddState(S3).AddState(S4).AddState(S5);
            stateMachineViewer.Refresh();
            TestWithTimer(() =>
            {
                Random rnd = new Random();
                stateMachineViewer.NavigateToState(rnd.Next(6));
            });
        }

        #endregion
    }
}
