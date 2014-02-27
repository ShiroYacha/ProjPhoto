using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public abstract class ServerAgentBase:ServerBase, IPeriodicAgent
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract void Start();
        public abstract void Stop();
        public abstract bool OnInvoke();
    }
}
