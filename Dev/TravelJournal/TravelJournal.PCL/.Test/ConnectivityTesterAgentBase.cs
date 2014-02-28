﻿using GalaSoft.MvvmLight.Ioc;
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

    public abstract class ConnectivityTesterAgentBase : ServerAgentBase
    {
        public override void OnInvoke()
        {
            OperationStart();
            Random random = new Random();
            RequestDownloadTest(random.Next(100000));
        }

        public void RequestDownloadTest(int packageSize)
        {
            serviceClient.PrepareTestDataCompleted += serviceClient_PrepareTestDataCompleted;
            serviceClient.PrepareTestDataAsync(packageSize);
        }
        private void serviceClient_PrepareTestDataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DownloadTestPackage();
            serviceClient.PrepareTestDataCompleted -= serviceClient_PrepareTestDataCompleted;
        }
        private void DownloadTestPackage()
        {
            serviceClient.GetTestDataCompleted += serviceClient_GetTestDataCompleted;
            serviceClient.GetTestDataAsync();
        }
        private void serviceClient_GetTestDataCompleted(object sender, ServiceReference.GetTestDataCompletedEventArgs e)
        {
            serviceClient.GetTestDataCompleted -= serviceClient_GetTestDataCompleted;
            OperationEnd();
        }

        public void RequestSingleDownloadTest(int testPackageSize)
        {
            OperationStart(false);
            RequestDownloadTest(testPackageSize);
        }
    }
}
