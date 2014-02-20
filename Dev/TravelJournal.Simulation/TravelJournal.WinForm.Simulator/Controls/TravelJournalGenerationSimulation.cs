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
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace TravelJournal.WinForm.Simulator
{
    public partial class TravelJournalSimulation : UserControl , ITestProjectControl
    {
        // Static instance
        private static TravelJournalSimulation currentInstance;

        // System fields
        private TravelSimulator simulator;
        private ServerConnectivityViewer connectivityViewer;
        private ServiceHost host;

        // Data fields
        public static SimulatorGeneralSettings generalSettings;
        private TravelItineraryData itineraryData;

        public TravelJournalSimulation()
        {
            InitializeComponent();
            // Assign static instance
            currentInstance = this;
            // Setup data
            itineraryData = new TravelItineraryData();
            generalSettings = new SimulatorGeneralSettings();
            // Setup systems
            simulator = new TravelSimulator(travelMapPlayer);
            connectivityViewer = new ServerConnectivityViewer();
            connectivityViewer.Dock = DockStyle.Fill;
            // Rendering
            RenderToolStrip();
        }

        #region Test

        private List<System.Threading.Timer> testTimers = new List<System.Threading.Timer>();
        private void TestWithTimer(Action action, int timeInterval)
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
                UpdateInfoInspector(new Dictionary<string, object>() { { "Current time", DateTime.Now.ToLongTimeString() } });
            }, 1000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, object>() { { "InfoInspector interval", "1 sec" } });
        }
        private void TestLogger()
        {
            TestWithTimer(() =>
            {
                Random rnd = new Random();
                LogType log = (LogType)rnd.Next(3);
                Log(log, string.Format("This is a test [{0}] log.", log));
            }, 3000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, object>() { { "Logger interval", "3 sec" } });
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
                int state = rnd.Next(6);
                stateMachineViewer.NavigateToState(state);
                UpdateInfoInspector(new Dictionary<string, object>() { { "Current state", state } });
            }, 1000);
            // Inspect info
            UpdateInfoInspector(new Dictionary<string, object>() { { "StateMachineViewer interval", "1 sec" } });
        }

        #endregion

        #region ITestProjectControl implementation
        public string TestName
        {
            get { return "Travel journal generation"; }
        }
        public string TestDescription
        {
            get { return "Simulate a travel behavior and assemble the travel journals."; }
        } 
        #endregion

        public TravelSimulator Simulator { get { return simulator; } }
        public ServerConnectivityViewer ConnectivityViewer { get { return connectivityViewer; } }
        public void CloseDown()
        {
            StopAllTimers();
            simulator.CloseDown();
        } 

        #region Public static members
        public static bool InAutoZoomMode
        {
            get { return currentInstance.autoZoomButton.Checked; }
        }
        public static void UpdateInfoInspector(Dictionary<string, object> infoDict)
        {
            currentInstance.InvokeMethod(() =>
            {
                currentInstance.infoInspector.UpdateInfo(infoDict);
            });
        }
        public static void Log(LogType type, string log, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1)
        {
            currentInstance.InvokeMethod(() =>
           {
               currentInstance.logger.Log(type, log, callerName, callerFilePath, callerLine);
           });
        }
        #endregion

        #region Private members

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
            // Initialize
            foreach (ITestControl control in leftTableLayoutPanel.Controls)
                control.Initialize();
            foreach (ITestControl control in rightTableLayoutPanel.Controls)
                control.Initialize();
            // Display the general settings
            UpdateViews();
        }
        private void UpdateViews()
        {
            // Load simulator
            simulator.ValidateData(itineraryData);
            UpdateButtonInConsole();
            // Update other inspector data
            UpdateRestInspectors();
        }
        private void DisableOtherButtonInConsole(ToolStripButton buttonNotToDisable=null)
        {
            foreach (ToolStripItem item in toolStrip.Items)
                item.Enabled = false;
            if (buttonNotToDisable != null) buttonNotToDisable.Enabled = true;
        }
        private void UpdateButtonInConsole()
        {
            foreach (ToolStripItem item in toolStrip.Items)
                item.Enabled = true;
            if (!serverButton.Checked)
            {
                connectivityTestButton.Enabled = false;
                if (!simulator.IsReady)
                {
                    playButton.Enabled = false;
                    pauseButton.Enabled = false;
                    resetButton.Enabled = false;
                }
            }
            //connectivityTestButton.Enabled = false;
            UpdateInfoInspector(new Dictionary<string, object>() { { "Simulator status", simulator.IsReady ? "Ready" : "Not ready" } });
        } 
        private void UpdateRestInspectors()
        {
            UpdateInfoInspector(generalSettings.Display());
            UpdateInfoInspector(itineraryData.Display());
        }
        private void SetupServerHost()
        {
            host = new ServiceHost("http://192.168.1.4:8733/");
            host.Open();
            // Log
            Log(LogType.Info, "Server host opened...");
        }
        private void CloseServerHost()
        {
            host.Close();
            host = null;
            // Log
            Log(LogType.Info, "Server host closed...");
        }
        #endregion

        #region Event handlers
        private void TravelJournalGenerationSimulation_Load(object sender, EventArgs e)
        {
            InitializeAllControls();
            // Initialization
            UpdateButtonInConsole();
        }

        private void serverButton_Click(object sender, EventArgs e)
        {
            if (serverButton.Checked)
                SetupServerHost();
            else
                CloseServerHost();
            UpdateButtonInConsole();
        }


        private void settingButton_Click(object sender, EventArgs e)
        {
            PropertyConfigForm<SimulatorGeneralSettings> configWindow = new PropertyConfigForm<SimulatorGeneralSettings>();
            configWindow.Data = generalSettings;
            configWindow.ShowDialog();
            UpdateViews();
        }
        private void uiTestButton_Click(object sender, EventArgs e)
        {
            if (uiTestButton.Checked)
            {
                // Disable all other buttons
                DisableOtherButtonInConsole(uiTestButton);
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
                // Resume all buttons
                UpdateButtonInConsole();
            }
        }

        private void connectivityTestButton_Click(object sender, EventArgs e)
        {
            if (connectivityTestButton.Checked)
            {
                rightTableLayoutPanel.Controls.RemoveAt(1);
                rightTableLayoutPanel.Controls.Add(connectivityViewer);
                DisableOtherButtonInConsole(connectivityTestButton);
            }
            else
            {
                rightTableLayoutPanel.Controls.RemoveAt(1);
                rightTableLayoutPanel.Controls.Add(travelMapPlayer);
                UpdateButtonInConsole();
            }
        }

        private void designButton_Click(object sender, EventArgs e)
        {
            TravelItineraryPlanner configPopupWindow = new TravelItineraryPlanner();
            configPopupWindow.Data = itineraryData;
            configPopupWindow.ShowDialog();
            itineraryData = configPopupWindow.Data;
            UpdateViews();
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            simulator.StartSimulation();
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            resetButton.Enabled = true;
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            simulator.PauseSimulation();
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            resetButton.Enabled = true;
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            simulator.ResetSimulation();
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            resetButton.Enabled = false;
        } 

        #endregion

    }
}
