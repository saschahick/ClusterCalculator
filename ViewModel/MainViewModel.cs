using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ClusteringCalculator.Classes;
using ClusteringCalculator.Commands;

namespace ClusteringCalculator.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {

        private CmdLoadData _cmdLoadData;
        private CmdInsertData _cmdInsertData;
        private CmdClearData _cmdClearData;
        private CmdAddNewClusterPoint _cmdAddNewClusterPoint;
        private CmdRunOneIteration _cmdRunOneIteration;
        private CmdClearClusterPoints _cmdClearClusterPoints;
        private CmdRunComplete _cmdRunComplete;
        private CmdExportToImage _cmdExportToImage;

        private ObservableCollection<Sale> _sales;
        private ObservableCollection<ClusterPoint> _clusterPoints;

        private int _iterations;
        private String _selectedDb;

        public MainViewModel()
        {
            
            CurrentCalculatorState = CalculatorState.Init;
            Iterations = 100;

        }

        public CmdLoadData CmdLoadData
        {
            get { return _cmdLoadData ?? (_cmdLoadData = new CmdLoadData()); }
            set { _cmdLoadData = value; }
        }

        public CmdInsertData CmdInsertData
        {
            get { return _cmdInsertData ?? (_cmdInsertData = new CmdInsertData()); }
            set { _cmdInsertData = value; }
        }

        public CmdClearData CmdClearData
        {
            get { return _cmdClearData ?? (_cmdClearData = new CmdClearData()); }
            set { _cmdClearData = value; }
        }

        public CmdAddNewClusterPoint CmdAddNewClusterPoint
        {
            get { return _cmdAddNewClusterPoint ?? (_cmdAddNewClusterPoint = new CmdAddNewClusterPoint()); }
            set { _cmdAddNewClusterPoint = value; }
        }

        public CmdRunOneIteration CmdRunOneIteration
        {
            get { return _cmdRunOneIteration ?? (_cmdRunOneIteration = new CmdRunOneIteration()); }
            set { _cmdRunOneIteration = value; }
        }

        public CmdClearClusterPoints CmdClearClusterPoints
        {
            get { return _cmdClearClusterPoints ?? (_cmdClearClusterPoints = new CmdClearClusterPoints()); }
            set { _cmdClearClusterPoints = value; }
        }

        public CmdRunComplete CmdRunComplete
        {
            get { return _cmdRunComplete ?? (_cmdRunComplete = new CmdRunComplete()); }
            set { _cmdRunComplete = value; }
        }

        public CmdExportToImage CmdExportToImage
        {
            get { return _cmdExportToImage ?? (_cmdExportToImage = new CmdExportToImage()); }
            set { _cmdExportToImage = value; }
        }

        public ObservableCollection<Sale> Sales
        {
            get { return _sales ?? (_sales = new ObservableCollection<Sale>()); }
            set { _sales = value; }
        }

        public ObservableCollection<ClusterPoint> ClusterPoints
        {
            get { return _clusterPoints ?? (_clusterPoints = new ObservableCollection<ClusterPoint>()); }
            set { _clusterPoints = value; }
        }

        public int Iterations
        {
            get { return _iterations; }
            set { _iterations = value; OnPropertyChanged(); }
        }

        public String SelectedDb
        {
            get { return _selectedDb; }
            set { _selectedDb = value; OnPropertyChanged(); }
        }

        public CalculatorState CurrentCalculatorState { get; set; }

        public Canvas CnvScale { get; set; }

        public Canvas CnvData { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public enum CalculatorState
        {
            Init,
            DataLoaded,
            DataInserted,
            Calculating
        }
    }
}
