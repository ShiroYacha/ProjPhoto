using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public interface IPeriodicAgentLauncher
    {
        void Start();
        void Stop();
    }
}
