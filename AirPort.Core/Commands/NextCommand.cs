using AirPort.Core.Models;
using AirPort.Core.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirPort.Core.Commands
{
    class NextCommand : IMvxCommand
    {
        private SearchViewModel viewModel;

        public NextCommand(SearchViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute()
        {
            return !viewModel.FlightSearch.HasErrors;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute()
        {
            viewModel.SwitchModel<ResultsViewModel>(new { FlightSearch = viewModel.FlightSearch });
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            Execute();
        }
    }
}
