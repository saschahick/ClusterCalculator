using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ClusteringCalculator.Classes;
using ClusteringCalculator.Database;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdLoadData : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return false;

            return dataContext.CurrentCalculatorState == MainViewModel.CalculatorState.Init;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var dbSaleList = new List<Sale>();

            switch (dataContext.SelectedDb)
            {
                case "TrainDB":
                    dbSaleList.AddRange(from sale in new TrainDbDataContext().train
                        select new Sale
                        {
                            Day = sale.day,
                            ItemId = sale.itemID,
                            Price = sale.price,
                            Quantity = sale.quantity
                        });
                    break;
                case "TwoSidesDB":
                    dbSaleList.AddRange(from sale in new TwoSideDbDataContext().twosides
                        select new Sale
                        {
                            Day = sale.day,
                            ItemId = sale.itemId,
                            Price = sale.price,
                            Quantity = sale.quantity
                        });
                    break;
                case "ChaosDB":
                    dbSaleList.AddRange(from sale in new ChaosDbDataContext().chaos
                        select new Sale
                        {
                            Day = sale.day,
                            ItemId = sale.itemId,
                            Price = sale.price,
                            Quantity = sale.quantity
                        });
                    break;
                case "ClusterMiddleDB":
                    dbSaleList.AddRange(from sale in new ClusterMiddleDbDataContext().clustermiddle
                        select new Sale
                        {
                            Day = sale.day,
                            ItemId = sale.itemId,
                            Price = sale.price,
                            Quantity = sale.quantity
                        });
                    break;
                case "RingDataDB":
                    dbSaleList.AddRange(from sale in new RingDataDBDataContext().ringdata
                        select new Sale
                        {
                            Day = sale.day,
                            ItemId = sale.itemId,
                            Price = sale.price,
                            Quantity = sale.quantity
                        });
                    break;
            }

            var saleList = dataContext.Sales;

            if (saleList == null) return;

            foreach (var sale in dbSaleList)
                saleList.Add(sale);

            dataContext.CurrentCalculatorState = MainViewModel.CalculatorState.DataLoaded;

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
