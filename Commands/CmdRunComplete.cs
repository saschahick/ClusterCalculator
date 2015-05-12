using System;
using System.Windows.Input;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdRunComplete : ICommand
    {

        public bool CanExecute(object parameter)
        {
            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return false;

            if (dataContext.ClusterPoints.Count < 1) return false;
            if (dataContext.Iterations < 1) return false;

            return dataContext.CurrentCalculatorState == MainViewModel.CalculatorState.DataInserted ||
                dataContext.CurrentCalculatorState == MainViewModel.CalculatorState.Calculating;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var initCount = dataContext.Iterations;

            for (var i = 0; i < initCount; i++)
                new CmdRunOneIteration().Execute(dataContext);
             
        }

        #region Implementation of ICommand

        /// <summary>
        /// Is raised, if the status of CanExecute changed
        /// </summary>
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

    }
}
