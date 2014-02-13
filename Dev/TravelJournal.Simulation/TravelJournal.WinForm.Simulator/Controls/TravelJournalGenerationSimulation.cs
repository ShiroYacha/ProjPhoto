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
using TravelJournal.WinForm.Simulator.Controls;
using System.Runtime.CompilerServices;
using TravelJournal.WinForm.Simulator.Rendering;
using TravelJournal.WinForm.Simulator.Forms;

namespace TravelJournal.WinForm.Simulator
{
    public partial class TravelJournalGenerationSimulation : UserControl , ITestProjectControl
    {
 
        public TravelJournalGenerationSimulation()
        {
            InitializeComponent();
            // Rendering
            RenderToolStrip();
        }

        public string TestName
        {
            get { return "Travel journal generation"; }
        }
        public string TestDescription
        {
            get { return "Simulate a travel behavior and assemble the travel journals."; }
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
        public void CloseDown()
        {
            StopAllTimers();
        }

        #region Test

        private List<System.Threading.Timer> testTimers = new List<System.Threading.Timer>();
        private void TestWithTimer(Action action,int timeInterval)
        {
            testTimers.Add(new System.Threading.Timer((o) => { action(); }, null, 1000, timeInterval));
        }
        private void StartTest()
        {
            // Log 
            Log(LogType.Info, "Test starting...");
            TestInfoInspector();
            TestLogger();
            TestStateMachineViewer();
            // Log 
            Log(LogType.Info, "Test started.");
        }
        private void TestInfoInspector()
        {
            TestWithTimer(() =>
            {
                UpdateInfoInspector(new Dictionary<string, string>() { {"Current time",DateTime.Now.ToLongTimeString()}});
            },1000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, string>() { { "InfoInspector interval", "1 sec" } });
        }
        private void TestLogger()
        {
            TestWithTimer(() =>
            {
                Random rnd = new Random();
                LogType log = (LogType)rnd.Next(3);
                Log(log, string.Format("This is a test [{0}] log.", log));
            },3000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, string>() { { "Logger interval", "3 sec" } });
        }
        private void TestStateMachineViewer()
        {
            Size size = new Size(14, 14);
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
                int state=rnd.Next(6);
                stateMachineViewer.NavigateToState(state);
                UpdateInfoInspector(new Dictionary<string, string>() { { "Current state", state.ToString()} });
            },1000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, string>() { { "StateMachineViewer interval", "1 sec" } });
        }

        #endregion

        #region Private methods

        private void RenderToolStrip()
        {
            // Use the vs2013-like dark theme
            toolStrip.Renderer = new DarkThemeToolStripRenderer();
            // Render menu strip color
            toolStrip.BackColor = Color.FromArgb(28, 28, 28);
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
        private void InvokeMethod(Action action)
        {
            this.Invoke(
              new MethodInvoker(() =>
              {
                  action();
              }));
        }
        private void StopAllTimers()
        {
            foreach (System.Threading.Timer timer in testTimers)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }
            testTimers.Clear();
        }
        private void InitializeAllControls()
        {
            foreach (ITestControl control in leftTableLayoutPanel.Controls)
                control.Initialize();
            foreach (ITestControl control in rightTableLayoutPanel.Controls)
                control.Initialize();
        } 

        #endregion

        private void TravelJournalGenerationSimulation_Load(object sender, EventArgs e)
        {

        }
        private void testButton_Click(object sender, EventArgs e)
        {
            if (testButton.Checked)
            {
                // Disable all other buttons
                foreach (ToolStripItem item in toolStrip.Items)
                    item.Enabled = false;
                testButton.Enabled = true;
                // Initialize
                StopAllTimers();
                InitializeAllControls();
                // Start test
                StartTest();
            }
            else
            {
                // Initialize
                StopAllTimers();
                InitializeAllControls();
                // Enable all other buttons
                foreach (ToolStripItem item in toolStrip.Items)
                    item.Enabled = true;
            }
        }

        private void designButton_Click(object sender, EventArgs e)
        {
            TravelItineraryPlanner configPopupWindow = new TravelItineraryPlanner();
            configPopupWindow.Data = new TravelItineraryData();
            configPopupWindow.ShowDialog();
        }

        private void travelMapPlayer_Load(object sender, EventArgs e)
        {

        }

        private void settingButton_Click(object sender, EventArgs e)
        {

        }


    }
}
