using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public class ServerConnectivityTester
    {
        private Action<bool> resultHandler;

        public void ConnectServer(Action<bool> resultHandler)
        {
            this.resultHandler = resultHandler;
            ServiceReference.ConnectivityTestServiceClient serviceClient = new ServiceReference.ConnectivityTestServiceClient();
            serviceClient.StartTestCompleted += serviceClient_StartTestCompleted;
            serviceClient.StartTestAsync();
        }

        void serviceClient_StartTestCompleted(object sender, ServiceReference.StartTestCompletedEventArgs e)
        {
            resultHandler(e.Result);
        }
    }
}
