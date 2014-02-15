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
        private const long DEFAULT_SIMULATION_STEP = 50;

        [Browsable(false)]
        public override string ConfigName
        {
            get { return "Simulator general settings"; }
        }

        [Browsable(false)]
        public override string ExtensionFilter
        {
            get { return "Simulator general settings files|*.sgs"; }
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

        public override Dictionary<string, object> Display()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("SimualtionStep",simualtionStep.ToString()+"ms");
            return data;
        }

        public override void Initialize()
        {
            simualtionStep = DEFAULT_SIMULATION_STEP;
        }
    }
}
