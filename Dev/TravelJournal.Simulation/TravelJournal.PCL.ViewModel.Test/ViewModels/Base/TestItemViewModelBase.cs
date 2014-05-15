using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TravelJournal.PCL.ViewModel;

namespace TravelJournal.PCL.ViewModel.Test
{

    public class TestItemViewModelBase : BindedViewModel
    {
        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged("ID");
                }
            }
        }

        private string _lineOne;
        /// <summary>
        /// ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    RaisePropertyChanged("LineOne");
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    RaisePropertyChanged("LineTwo");
                }
            }
        }

        private string _lineThree;
        /// <summary>
        /// ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                if (value != _lineThree)
                {
                    _lineThree = value;
                    RaisePropertyChanged("LineThree");
                }
            }
        }
    }
}