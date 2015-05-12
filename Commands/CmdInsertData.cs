using System;
using System.Windows.Input;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdInsertData : ICommand
    {

        public bool CanExecute(object parameter)
        {
            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return false;

            return dataContext.CurrentCalculatorState == MainViewModel.CalculatorState.DataLoaded;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var canvas = dataContext.CnvData;

            if (canvas == null) return;

            var maxX = CanvasDrawManager.GetMaxX(dataContext.Sales);
            var maxY = CanvasDrawManager.GetMaxY(dataContext.Sales);

            if(maxX < 1 || maxY < 1) return;

            foreach (var sale in dataContext.Sales)
            {

                CanvasDrawManager.CalculateCanvasCoordinates(sale, canvas, maxX, maxY);

                CanvasDrawManager.DrawDataPoint(canvas, sale, true);

            }

            dataContext.CurrentCalculatorState = MainViewModel.CalculatorState.DataInserted;

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
