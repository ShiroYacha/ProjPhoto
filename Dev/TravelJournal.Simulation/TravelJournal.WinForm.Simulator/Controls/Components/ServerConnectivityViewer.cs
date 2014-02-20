using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelJournal.WinForm.Simulator.Controls
{
    public partial class ServerConnectivityViewer : UserControl
    {
        public bool IsReady { get; set; }

        public ServerConnectivityViewer()
        {
            InitializeComponent();
            // Initialize
            IsReady = false;
        }

        private void ServerConnectivityViewer_Load(object sender, EventArgs e)
        {
            Setup();
        }

        private void Setup()
        {
            IsReady=true;
            // Log
            TravelJournalSimulation.Log(LogType.Info, "Waiting for client to launch test...");
        }

        private void ServerConnectivityViewer_Leave(object sender, EventArgs e)
        {

            // Log
            TravelJournalSimulation.Log(LogType.Info, "Connectivity test closed down...");
        }
    }
}
