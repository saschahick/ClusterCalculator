using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClusteringCalculator.Classes.HelperClasses
{
    public static class ClusterManager
    {

        public static void AssignDataPointsToCluster(Canvas canvas, ObservableCollection<ClusterPoint> clusterPoints, ObservableCollection<Sale> dataPoints)
        {

            canvas.Children.Clear();

            foreach (var clusterPoint in clusterPoints)
            {
                CanvasDrawManager.DrawClusterPoint(canvas, clusterPoint);
                clusterPoint.Sales.Clear();
            }

            foreach (var dataPoint in dataPoints)
            {

                var nearestClusterPoint = GetNearestClusterPoint(clusterPoints, dataPoint);

                nearestClusterPoint.Sales.Add(dataPoint);

                dataPoint.Color = nearestClusterPoint.Color;

                CanvasDrawManager.DrawDataPoint(canvas, dataPoint, false);

            }

        }

        public static void MoveClusterToCenter(Canvas canvas, ObservableCollection<ClusterPoint> clusterPoints, ObservableCollection<Sale> dataPoints)
        {

            foreach (var clusterPoint in clusterPoints)
            {

                if(clusterPoint.Sales.Count < 1) continue;

                var newPoint = CalculateCentroid(clusterPoint.Sales);

                clusterPoint.X = newPoint.X;
                clusterPoint.Y = newPoint.Y;

            }

            canvas.Children.Clear();

            foreach (var clusterPoint in clusterPoints)
                CanvasDrawManager.DrawClusterPoint(canvas, clusterPoint);

            foreach (var dataPoint in dataPoints)
                CanvasDrawManager.DrawDataPoint(canvas, dataPoint, false);

        }

        private static Point CalculateCentroid(IReadOnlyCollection<Sale> dataPoints)
        {

            var count = dataPoints.Count;
            var sumX = dataPoints.Sum(dp => dp.X);
            var sumY = dataPoints.Sum(dp => dp.Y);

            return new Point(sumX / count, sumY / count);

        }

        private static ClusterPoint GetNearestClusterPoint(ObservableCollection<ClusterPoint> clusterPoints, Sale dataPoint)
        {

            ClusterPoint nearestClusterPoint = null;
            var nearestDistance = double.MaxValue;

            foreach (var clusterPoint in clusterPoints)
            {

                if (nearestDistance > GetDistance(clusterPoint, dataPoint))
                {
                    nearestDistance = GetDistance(clusterPoint, dataPoint);
                    nearestClusterPoint = clusterPoint;
                }

            }

            return nearestClusterPoint;

        }

        private static double GetDistance(ClusterPoint clusterPoint, Sale dataPoint)
        {

            return Math.Sqrt(Math.Pow((clusterPoint.X - dataPoint.X), 2) + Math.Pow((clusterPoint.Y - dataPoint.Y), 2));

        }

    }
}
