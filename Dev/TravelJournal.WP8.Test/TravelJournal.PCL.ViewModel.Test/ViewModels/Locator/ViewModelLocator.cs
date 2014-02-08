/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TravelJournal.WP8.TestUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace TravelJournal.PCL.ViewModel.Test
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator : TravelJournal.PCL.ViewModel.ViewModelLocator
    {
        protected override void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<JournalGenerationTestViewModel>();
        }

        public MainViewModel TestMain
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public JournalGenerationTestViewModel JournalGenerationTestViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<JournalGenerationTestViewModel>();
            }
        }
    }
}