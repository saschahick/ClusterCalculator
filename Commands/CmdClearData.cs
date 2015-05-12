using System;
using System.Windows.Input;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdClearData : ICommand
    {

        public bool CanExecute(object parameter)
        {
            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return false;

            return dataContext.CurrentCalculatorState != MainViewModel.CalculatorState.Init;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var canvas = dataContext.CnvData;

            if (canvas == null) return;

            dataContext.Sales.Clear();
            canvas.Children.Clear();

            foreach (var clusterPoint in dataContext.ClusterPoints)
                CanvasDrawManager.DrawClusterPoint(canvas, clusterPoint);

            dataContext.CurrentCalculatorState = MainViewModel.CalculatorState.Init;

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
