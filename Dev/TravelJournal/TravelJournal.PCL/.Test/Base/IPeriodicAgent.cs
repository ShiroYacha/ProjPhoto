using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelJournal.PCL.Test
{
    public interface IPeriodicAgent
    {
        void Start();
        void Stop();
        bool OnInvoke(Action onCompleteHandler = null);
    }
}
