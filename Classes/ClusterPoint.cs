using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ClusteringCalculator.Classes
{
    public class ClusterPoint : INotifyPropertyChanged
    {

        private Color _color;

        private ObservableCollection<Sale> _sales;

        private double _x;
        private double _y;

        public Color Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(); OnPropertyChanged("ColorBrush"); }
        }

        public Brush ColorBrush
        {
            get { return new SolidColorBrush(Color); }
        }

        public ObservableCollection<Sale> Sales
        {
            get { return _sales ?? (_sales = new ObservableCollection<Sale>()); }
            set { _sales = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); OnPropertyChanged("XText"); }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); OnPropertyChanged("YText"); }
        }

        public String XText
        {
            get { return ((int)_x).ToString(CultureInfo.InvariantCulture); }
        }

        public String YText
        {
            get { return ((int)_y).ToString(CultureInfo.InvariantCulture); }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
