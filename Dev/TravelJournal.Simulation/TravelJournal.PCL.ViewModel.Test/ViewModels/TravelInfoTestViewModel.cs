using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{
    public class TravelInfoTestViewModel : ServerTestItemViewModelBase
    {
        protected override PCL.Test.ServerBase CreateServerTester()
        {
            return new TravelInfoTester();
        }
    }
}
