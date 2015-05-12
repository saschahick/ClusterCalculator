using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Brushes = System.Windows.Media.Brushes;

namespace ClusteringCalculator.Classes.HelperClasses
{
    public class ImageCreation
    {

        public static void SaveToImageFile(FrameworkElement frameworkElement, String fileName, IEnumerable<ImageFormat> allowedImageFormats)
        {

            var image = Convert(frameworkElement);

            SaveToImageFile(image, fileName, allowedImageFormats);

        }

        private static void SaveToImageFile(Image image, String fileName, IEnumerable<ImageFormat> allowedImageFormats)
        {

            if (image == null) return;

            var allowedDialogDialogImageFormats = GetFilterString(allowedImageFormats);

            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = allowedDialogDialogImageFormats.FilterString,
                Title = "Save to",
                FileName = "ClusterCalculator_" + fileName
            };

            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "") return;

            try
            {

                image.Save(saveFileDialog1.FileName, allowedDialogDialogImageFormats.FilterImageFormats[saveFileDialog1.FilterIndex - 1]);

            }
            catch (Exception) { }

        }

        private static Image Convert(UIElement controlToRender)
        {

            var renderWidth = (int)(controlToRender.RenderSize.Width);
            var renderHeight = (int)(controlToRender.RenderSize.Height);

            var renderTarget = new RenderTargetBitmap(renderWidth, renderHeight, 96, 96, PixelFormats.Default);
            var sourceBrush = new VisualBrush(controlToRender);

            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();

            var rect = new Rect(0, 0, controlToRender.RenderSize.Width, controlToRender.RenderSize.Height);
            var rectEXT = new Rect(0, 0, controlToRender.RenderSize.Width + 10, controlToRender.RenderSize.Height + 10);

            using (drawingContext)
            {
                drawingContext.DrawRectangle(Brushes.LightGray, null, rectEXT);
                drawingContext.DrawRectangle(sourceBrush, null, rect);
            }

            renderTarget.Render(drawingVisual);

            var png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(renderTarget));
            
            var ms = new MemoryStream();
            png.Save(ms);

            ms.Position = 0;

            var retImg = Image.FromStream(ms);
            return retImg;

        }

        private static AllowedDialogImageFormats GetFilterString(IEnumerable<ImageFormat> allowedImageFormats)
        {

            var filterString = "";
            var filterList = new List<ImageFormat>();

            foreach (var allowedImageFormat in allowedImageFormats)
            {

                if (allowedImageFormat.Guid.Equals(ImageFormat.Bmp.Guid))
                {
                    filterString += "Bitmap Image|*.bmp|";
                    filterList.Add(ImageFormat.Bmp);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Emf.Guid))
                {
                    filterString += "EMF|*.emf|";
                    filterList.Add(ImageFormat.Emf);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Gif.Guid))
                {
                    filterString += "Gif Image|*.gif|";
                    filterList.Add(ImageFormat.Gif);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Jpeg.Guid))
                {
                    filterString += "Jpeg Image|*.jpg|";
                    filterList.Add(ImageFormat.Jpeg);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Png.Guid))
                {
                    filterString += "PNG Image|*.png|";
                    filterList.Add(ImageFormat.Png);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Tiff.Guid))
                {
                    filterString += "Tiff Image|*.tiff|";
                    filterList.Add(ImageFormat.Tiff);
                }

                if (allowedImageFormat.Guid.Equals(ImageFormat.Wmf.Guid))
                {
                    filterString += "WMF Image|*.wmf|";
                    filterList.Add(ImageFormat.Wmf);
                }

            }

            filterString = filterString.Substring(0, filterString.Length - 1);

            return new AllowedDialogImageFormats
            {
                FilterString = filterString,
                FilterImageFormats = filterList
            };

        }

    }

    class AllowedDialogImageFormats
    {

        public String FilterString { get; set; }
        public List<ImageFormat> FilterImageFormats { get; set; }

    }

}