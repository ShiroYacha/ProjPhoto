using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public abstract class ServerBase
    {
        protected ServiceReference.ConnectionServiceClient serviceClient = new ServiceReference.ConnectionServiceClient();
        private Action<ConnectionStatus> resultHandler;

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
                if(resultHandler!=null)  resultHandler(e.Result ? ConnectionStatus.Connected : ConnectionStatus.Disconnected);
            }
            catch (Exception)
            {
                if (resultHandler != null) resultHandler(ConnectionStatus.ServerOffline);
            }
            finally
            {
                serviceClient.ConnectCompleted -= serviceClient_DoWorkCompleted;
            }
        }
    }
}
