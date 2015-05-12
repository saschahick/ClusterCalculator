using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClusteringCalculator.Classes.HelperClasses
{
    public static class CanvasDrawManager
    {

        private static readonly Color[] PointColors = {Colors.Blue, Colors.Tomato, Colors.Crimson, Colors.DarkViolet, Colors.Black, Colors.MediumSeaGreen};
        private static int _currentColorIndex = 0;

        public static Color GetNextColor()
        {

            if (_currentColorIndex >= PointColors.Length)
                _currentColorIndex = 0;

            return PointColors[_currentColorIndex++];

        }

        public static void DrawDataPoint(Canvas canvas, Sale dataPoint, bool useDefaultColor)
        {

            var color = useDefaultColor ? Colors.DarkSlateGray : dataPoint.Color;
            
            var rectDataPoint = new Rectangle
            {
                Fill = new SolidColorBrush(color),
                Width = 4,
                Height = 4,
                ToolTip = dataPoint.X + "/" + dataPoint.Y
            };

            Canvas.SetLeft(rectDataPoint, dataPoint.X);
            Canvas.SetBottom(rectDataPoint, dataPoint.Y);

            canvas.Children.Add(rectDataPoint);

        }

        public static void DrawClusterPoint(Canvas canvas, ClusterPoint clusterPoint)
        {

            var rectDataPoint = new Ellipse
            {
                Stroke = new SolidColorBrush(Colors.Black),
                Fill = new SolidColorBrush(clusterPoint.Color),
                Width = 10,
                Height = 10,
                ToolTip = clusterPoint.X + "/" + clusterPoint.Y
            };

            Canvas.SetLeft(rectDataPoint, clusterPoint.X);
            Canvas.SetBottom(rectDataPoint, clusterPoint.Y);

            canvas.Children.Add(rectDataPoint);

        }

        public static void CalculateCanvasCoordinates(Sale sale, Canvas canvas, int maxX, int maxY)
        {

            var cnvX = canvas.ActualWidth;
            var cnvY = canvas.ActualHeight;

            var saleXPercentage = (double)sale.Quantity / (double)maxX;
            var saleYPercentage = (double)sale.Price / (double)maxY;

            sale.X = cnvX * saleXPercentage;
            sale.Y = cnvY * saleYPercentage;

        }

        public static int GetMaxX(ObservableCollection<Sale> sales)
        {

            if (sales.Count < 1) return -1;

            return sales.Max(sale => sale.Quantity);

        }

        public static int GetMaxY(ObservableCollection<Sale> sales)
        {

            if (sales.Count < 1) return -1;

            return (int)(Decimal.Round(sales.Max(sale => sale.Price)));

        }

        public static void DrawScale(Canvas canvas)
        {

            //draw vertical lines
            for (var i = 0; i < 11; i++)
            {

                DrawRectangle(canvas, 30 + (i * 51), 1, 30, 510, true);

            }

            //draw horizontal lines
            for (var i = 0; i < 11; i++)
            {

                DrawRectangle(canvas, 30, 511, 30 + (i * 51), 1, true);

            }

            //draw horizontal labels
            for (var i = 0; i < 11; i++)
            {

                var text = (i * 50).ToString();
                var textOffset = text.Length * 4;

                DrawText(canvas, 30 + textOffset + (i * 50), 0, text);

            }

            //draw vertical labels
            for (var i = 0; i < 11; i++)
            {

                DrawText(canvas, 10, 31 + (i * 50), (i * 50).ToString());

            }

        }

        private static void DrawRectangle(Canvas canvas, int x, int sizeX, int y, int sizeY, bool lightColor = false)
        {

            var rct = new Rectangle
            {
                Width = sizeX,
                Height = sizeY,
                Fill = lightColor ? new SolidColorBrush(Colors.DarkGray) : new SolidColorBrush(Colors.Black)
            };

            Canvas.SetLeft(rct, x);
            Canvas.SetBottom(rct, y);

            canvas.Children.Add(rct);

        }

        private static void DrawText(Canvas canvas, int x, int y, String label)
        {

            var cnvLabel = new TextBlock
            {
                Text = label
            };

            Canvas.SetLeft(cnvLabel, x - cnvLabel.Text.Length * 5);
            Canvas.SetBottom(cnvLabel, y - cnvLabel.ActualHeight / 2);

            canvas.Children.Add(cnvLabel);
        }

    }
}
