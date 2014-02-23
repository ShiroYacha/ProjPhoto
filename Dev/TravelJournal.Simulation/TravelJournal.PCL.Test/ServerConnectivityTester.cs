using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelJournal.PCL.Test
{
    public enum ConnectionStatus { Connected, Disconnected, ServerOffline }

    public class ServerConnectivityTester
    {
        private ServiceReference.ConnectionServiceClient serviceClient = new ServiceReference.ConnectionServiceClient();
        private Action<ConnectionStatus> resultHandler;
        private DateTime currentTime;

        public void ConnectServer(Action<ConnectionStatus> resultHandler)
        {
            this.resultHandler = resultHandler;
            serviceClient.ConnectCompleted += serviceClient_DoWorkCompleted;
            serviceClient.ConnectAsync("Emulator WVGA 512MB");
        }
        private void serviceClient_DoWorkCompleted(object sender, ServiceReference.ConnectCompletedEventArgs e)
        {
            try
            {
                resultHandler(e.Result ? ConnectionStatus.Connected : ConnectionStatus.Disconnected);
            }
            catch (Exception)
            {
                resultHandler(ConnectionStatus.ServerOffline);
            }
            finally
            {
                serviceClient.ConnectCompleted -= serviceClient_DoWorkCompleted;
            }
        }

        public void RequestDownloadTest(long packageSize)
        {
            serviceClient.PrepareTestDataCompleted += serviceClient_PrepareTestDataCompleted;
            serviceClient.PrepareTestDataAsync(packageSize);
        }

        void serviceClient_PrepareTestDataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DownloadTestPackage();
            serviceClient.PrepareTestDataCompleted -= serviceClient_PrepareTestDataCompleted;
        }

        private void DownloadTestPackage()
        {
            serviceClient.GetTestDataCompleted += serviceClient_GetTestDataCompleted;
            currentTime = DateTime.Now;
            serviceClient.GetTestDataAsync();
        }

        void serviceClient_GetTestDataCompleted(object sender, ServiceReference.GetTestDataCompletedEventArgs e)
        {
            TimeSpan latency=DateTime.Now-currentTime;
            serviceClient.ReportLatencyAsync((decimal)latency.TotalSeconds);
            serviceClient.GetTestDataCompleted -= serviceClient_GetTestDataCompleted;
        }

    }
}
