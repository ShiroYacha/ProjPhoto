using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{
    public class TravelInfoTestViewModel : ServerTestItemViewModelBase
    {
        protected override PCL.Test.ServerAgentBase CreateServerAgentTester()
        {
            return SimpleIoc.Default.GetInstance<TravelInfoTesterAgentBase>();
        }
    }
}
