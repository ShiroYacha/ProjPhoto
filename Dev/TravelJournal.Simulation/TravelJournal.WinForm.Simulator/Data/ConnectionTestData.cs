using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    public class ConnectionTestData
    {
        [DataMember]
        public List<int> Data
        {
            get;
            set;
        }
    }
}
