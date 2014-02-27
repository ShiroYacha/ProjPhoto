using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TravelJournal.PCL.ViewModel
{
    public class BindedViewModel : ViewModelBase
    {
        /// <summary>
        /// ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public virtual string BindedViewXamlName
        {
            get
            {
                return this.GetType().Name.Replace("ViewModel", "Page"); 
            }
        }

        public ICommand OnNavigateTo
        {
            get
            {
                return new RelayCommand<Object>(NavigateTo);
            }
        }

        private void NavigateTo(object navigateToItem)
        {
            if(navigateToItem!=null)
                Messenger.Default.Send(new NavigationMessage((navigateToItem as BindedViewModel).BindedViewXamlName));
        }

        public virtual void NavigateFrom()
        {

        }
    }
}
