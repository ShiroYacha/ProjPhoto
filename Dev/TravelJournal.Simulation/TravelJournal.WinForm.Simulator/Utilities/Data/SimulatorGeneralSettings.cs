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
    public class SimulatorGeneralSettings:ConfigDataBase
    {
        private const long DEFAULT_SIMULATION_STEP = 500;

        [Browsable(false)]
        public override string ConfigName
        {
            get { return "Simulator general settings"; }
        }

        [Browsable(false)]
        public override string Extension
        {
            get { return ".gs"; }
        }

        private long simualtionStep = DEFAULT_SIMULATION_STEP;
        [DataMember()]
        [Category("Simulation")]
        [DisplayName("Step")]
        [Description("The simulation step in millisecond.")]
        public long SimualtionStep
        {
            get { return simualtionStep; }
            set
            {
                if (simualtionStep != value)
                {
                    OnDataChanging();
                    simualtionStep = value;
                    OnDataChanged();
                }
            }
        }

        public override Dictionary<string, string> Display()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("SimualtionStep",simualtionStep.ToString()+"ms");
            return data;
        }

        public override void Initialize()
        {
            simualtionStep = DEFAULT_SIMULATION_STEP;
        }
    }
}
