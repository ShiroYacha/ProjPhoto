using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.DataService
{
    public class UserInfo
    {

        private string userName;
        private GpsPosition userPosition;
        private GpsPosition originalPosition;
            
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

        public GpsPosition UserPosition
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


        public GpsPosition OriginalPosition
        {
            get { return originalPosition; }
            set { originalPosition = value; }
        }

        public UserInfo() { }
        public UserInfo(string userName, GpsPosition userPosition)
        {
            this.userName = userName;
            this.userPosition = userPosition;
        }
      
    }
}
