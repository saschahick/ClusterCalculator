using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Input;
using ClusteringCalculator.Classes.HelperClasses;
using ClusteringCalculator.ViewModel;

namespace ClusteringCalculator.Commands
{
    class CmdExportToImage : ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            var dataContext = parameter as MainViewModel;

            if (dataContext == null) return;

            var canvas = dataContext.CnvData;

            if (canvas == null) return;

            var allowedFormats = new List<ImageFormat>
                {
                    ImageFormat.Bmp,
                    ImageFormat.Emf,
                    ImageFormat.Exif,
                    ImageFormat.Gif,
                    ImageFormat.Icon,
                    ImageFormat.Jpeg,
                    ImageFormat.MemoryBmp,
                    ImageFormat.Png,
                    ImageFormat.Tiff,
                    ImageFormat.Wmf
                };

            ImageCreation.SaveToImageFile(canvas, "Graph", allowedFormats);

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
