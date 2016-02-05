using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Core.Models
{
    class ResultsViewModel : MvxViewModel
    {
        private FlightSearch flightSearch;

        public ResultsViewModel()
        {
        }

        public FlightSearch FlightSearch
        {
            get
            {
                return flightSearch;
            }
        }

        public void Init(FlightSearch flightSearch)
        {
            this.flightSearch = flightSearch;
        }
    }
}
