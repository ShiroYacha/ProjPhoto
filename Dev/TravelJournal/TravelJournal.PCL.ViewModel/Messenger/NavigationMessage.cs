using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.ViewModel
{
    public class NavigationMessage : NotificationMessage
    {
        public string PageName
        {
            get { return base.Notification; }
        }
        public BindedViewModel ViewModel
        {
            get;
            private set;
        }

        public NavigationMessage(string pageName, BindedViewModel viewModel) : base(pageName) { this.ViewModel = viewModel; }

    }
}
