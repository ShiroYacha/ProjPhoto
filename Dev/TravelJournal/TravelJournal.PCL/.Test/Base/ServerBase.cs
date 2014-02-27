using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public abstract class ServerBase
    {
        protected ServiceReference.SimulationServicesClient serviceClient = new ServiceReference.SimulationServicesClient();

        protected DateTime startTime;
        private Action<ConnectionStatus> resultHandler;

        public event Action OnCompletedHandler;
        protected bool IsAsync { get { return OnCompletedHandler != null; } }

        public void ConnectServer(Action<ConnectionStatus> resultHandler)
        {
            this.resultHandler = resultHandler;
            serviceClient.ConnectCompleted += serviceClient_ConnectCompleted;
            serviceClient.ConnectAsync("Emulator WVGA 512MB");
        }
        private void serviceClient_ConnectCompleted(object sender, ServiceReference.ConnectCompletedEventArgs e)
        {
            try
            {
                if(resultHandler!=null)  resultHandler(e.Result ? ConnectionStatus.Connected : ConnectionStatus.Disconnected);
            }
            catch (Exception ex)
            {
                if (resultHandler != null) resultHandler(ConnectionStatus.ServerOffline);
            }
            finally
            {
                serviceClient.ConnectCompleted -= serviceClient_ConnectCompleted;
            }
        }

        public void DisconnectServer(Action<ConnectionStatus> resultHandler)
        {
            this.resultHandler = resultHandler;
            serviceClient.DisconnectCompleted += serviceClient_DisconnectCompleted;
            serviceClient.DisconnectAsync("Emulator WVGA 512MB");
        }
        private void serviceClient_DisconnectCompleted(object sender, ServiceReference.DisconnectCompletedEventArgs e)
        {
            try
            {
                if (resultHandler != null) resultHandler(e.Result ? ConnectionStatus.Connected : ConnectionStatus.Disconnected);
            }
            catch (Exception ex)
            {
                if (resultHandler != null) resultHandler(ConnectionStatus.ServerOffline);
            }
            finally
            {
                serviceClient.DisconnectCompleted -= serviceClient_DisconnectCompleted;
            }
        }

        protected void OperationStart()
        {
            startTime = DateTime.Now;
        }

        protected void OperationEnd()
        {
            TimeSpan latency = DateTime.Now - startTime;
            serviceClient.ReportLatencyCompleted += serviceClient_ReportLatencyCompleted;
            serviceClient.ReportLatencyAsync((decimal)latency.TotalSeconds);
        }

        protected void OperationEndDirectly()
        {
            if (OnCompletedHandler != null) OnCompletedHandler();
        }

        void serviceClient_ReportLatencyCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (OnCompletedHandler != null) OnCompletedHandler();
        }
    }
}
