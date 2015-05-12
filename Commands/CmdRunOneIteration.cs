using System;
using System.Windows.Input;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdRunOneIteration : ICommand
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

            var canvas = dataContext.CnvData;

            if (canvas == null) return;

            ClusterManager.AssignDataPointsToCluster(canvas, dataContext.ClusterPoints, dataContext.Sales);
            ClusterManager.MoveClusterToCenter(canvas, dataContext.ClusterPoints, dataContext.Sales);
            ClusterManager.AssignDataPointsToCluster(canvas, dataContext.ClusterPoints, dataContext.Sales);

            dataContext.CurrentCalculatorState = MainViewModel.CalculatorState.Calculating;
            dataContext.Iterations -= 1;

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
