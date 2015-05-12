using System;
using System.Windows.Input;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdClearClusterPoints : ICommand
    {

        public bool CanExecute(object parameter)
        {
            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return false;

            return dataContext.ClusterPoints.Count > 0;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var canvas = dataContext.CnvData;

            if (canvas == null) return;

            dataContext.ClusterPoints.Clear();
            canvas.Children.Clear();

            foreach (var dataPoint in dataContext.Sales)
                CanvasDrawManager.DrawDataPoint(canvas, dataPoint, true);

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
