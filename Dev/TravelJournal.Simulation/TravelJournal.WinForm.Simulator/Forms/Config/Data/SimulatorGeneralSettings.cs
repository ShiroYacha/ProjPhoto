using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    [KnownType(typeof(SimulatorGeneralSettings))]
    public class SimulatorGeneralSettings:IConfigData
    {
        [Browsable(false)]
        public string ConfigName
        {
            get { return "Simulator general settings"; }
        }

        [Browsable(false)]
        public string Extension
        {
            get { return ".gs"; }
        }


    }
}
