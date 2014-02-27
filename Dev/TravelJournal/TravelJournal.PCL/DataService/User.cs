using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    class User
    {

        private string userName;
        private GpsPoint userPosition;
        private GpsPoint originalPosition = new GpsPoint(135.00, 75.00, Convert.ToDateTime("07/09/2013"));
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public GpsPoint UserPosition
        {
            get
            {
                return userPosition;
            }
            set
            {
                userPosition = value;
            }
        }

        public User() { }
        public User(string userName, GpsPoint userPosition)
        {
            this.userName = userName;
            this.userPosition = userPosition;
        }



      
    }
}
