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

        public NavigationMessage(string pageName) : base(pageName) { }

    }
}
