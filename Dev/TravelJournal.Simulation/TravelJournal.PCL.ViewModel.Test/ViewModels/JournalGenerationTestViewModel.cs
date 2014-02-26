using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TravelJournal.PCL.Test;

namespace TravelJournal.PCL.ViewModel.Test
{
    public class JournalGenerationTestViewModel : ServerTestItemViewModelBase
    {
        protected override PCL.Test.ServerAgentBase CreateServerAgentTester()
        {
            return SimpleIoc.Default.GetInstance<JournalGenerationTesterAgentBase>();
        }
    }
}
