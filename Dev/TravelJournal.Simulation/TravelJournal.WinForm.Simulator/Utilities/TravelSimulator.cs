using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.WinForm.Simulator
{
    public class TravelSimulator
    {
        private TravelItineraryData data;

        public bool ValidateData(TravelItineraryData data)
        {
            if (data.IsComplete)
            {
                if (!data.IsCompiled)
                {
                    TravelSimulationDataCompiler compiler = new TravelSimulationDataCompiler(data.CameraRadius);
                    this.data = compiler.Compile(data);
                }
                else
                    this.data = data;
                return true;
            }
            else
                return false;  
        }

        public void StartSimulation()
        {

        }
    }
}
