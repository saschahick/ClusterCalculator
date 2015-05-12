using System;
using System.Windows.Input;
using ClusteringCalculator.Classes;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.Database;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {

            InitializeComponent();

            CanvasDrawManager.DrawScale(CnvScale);

        }

        private void CnvScale_OnInitialized(object sender, EventArgs e)
        {
            var dataContext = DataContext as MainViewModel;

            if (dataContext == null) return;

            dataContext.CnvScale = CnvScale;
        }

        private void CnvData_OnInitialized(object sender, EventArgs e)
        {

            var dataContext = DataContext as MainViewModel;

            if (dataContext == null) return;

            dataContext.CnvData = CnvData;

        }

        

        private void CnvData_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            var dataContext = DataContext as MainViewModel;

            if (dataContext == null) return;

            if (dataContext.ClusterPoints.Count > 5) return;

            var mousePosition = e.MouseDevice.GetPosition(CnvData);

            mousePosition.Y = CnvData.ActualHeight - mousePosition.Y;

            var newClusterPoint = new ClusterPoint
            {
                X = mousePosition.X - 5,
                Y = mousePosition.Y - 5,
                Color = CanvasDrawManager.GetNextColor()
            };

            dataContext.ClusterPoints.Add(newClusterPoint);

            CanvasDrawManager.DrawClusterPoint(CnvData, newClusterPoint);

        }

        private void CnvData_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

            var dataContext = DataContext as MainViewModel;

            if (dataContext == null) return;

            var mousePosition = e.MouseDevice.GetPosition(CnvData);

            mousePosition.Y = CnvData.ActualHeight - mousePosition.Y;

            switch (dataContext.SelectedDb)
            {
                case "TrainDB":
                    var dbContext = new TrainDbDataContext();
                      
                    dbContext.train.InsertOnSubmit(new train
                    {
                        day = 1,
                        itemID = 1,
                        price = (decimal)mousePosition.Y,
                        quantity = (int)mousePosition.X
                    });
                    dbContext.SubmitChanges();
                    break;
                case "TwoSidesDB":
                    var dbContext2 = new TwoSideDbDataContext();

                    dbContext2.twosides.InsertOnSubmit(new twosides
                    {
                        day = 1,
                        itemId = 1,
                        price = (decimal)mousePosition.Y,
                        quantity = (int)mousePosition.X
                    });
                    dbContext2.SubmitChanges();
                    break;
                case "ChaosDB":
                    var dbContext3 = new ChaosDbDataContext();

                    dbContext3.chaos.InsertOnSubmit(new chaos
                    {
                        day = 1,
                        itemId = 1,
                        price = (decimal)mousePosition.Y,
                        quantity = (int)mousePosition.X
                    });
                    dbContext3.SubmitChanges();
                    break;
                case "ClusterMiddleDB":
                    var dbContext4 = new ClusterMiddleDbDataContext();

                    dbContext4.clustermiddle.InsertOnSubmit(new clustermiddle
                    {
                        day = 1,
                        itemId = 1,
                        price = (decimal)mousePosition.Y,
                        quantity = (int)mousePosition.X
                    });
                    dbContext4.SubmitChanges();
                    break;
                case "RingDataDB":
                    var dbContext5 = new RingDataDBDataContext();

                    dbContext5.ringdata.InsertOnSubmit(new ringdata
                    {
                        day = 1,
                        itemId = 1,
                        price = (decimal)mousePosition.Y,
                        quantity = (int)mousePosition.X
                    });
                    dbContext5.SubmitChanges();
                    break;
            }

        }

    }
}
