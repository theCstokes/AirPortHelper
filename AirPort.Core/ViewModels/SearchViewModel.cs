using AirPort.Core.Commands;
using AirPort.Core.Models;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace AirPort.Core.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private FlightSearch flightSearch;

        public SearchViewModel()
        {
            flightSearch = new FlightSearch();
            NextCommand = new NextCommand(this);
        }

       public FlightSearch FlightSearch
        {
            get
            {
                return flightSearch;
            }
        }

        public ICommand NextCommand
        {
            get;
            private set;
        }

        public void SwitchModel<T>(object parameterValuesObject,
                                   IMvxBundle presentationBundle = null,
                                   MvxRequestedBy requestedBy = null) where T : MvxViewModel
        {
            ShowViewModel<T>(parameterValuesObject.ToSimplePropertyDictionary(),
                presentationBundle,
                requestedBy);
        }
    }
}
