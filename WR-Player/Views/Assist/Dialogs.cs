using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR_Player.Views.Assist
{
    class Dialogs
    {
        //TODO
        private static readonly string FILE_EXTENSION = ".m3u8";
        private static readonly string FILE_FILTER = "UTF-8 Encoded Audio Playlist files (*.m3u8)|*.m3u8";


        //public static bool? ShowDialog(DialogViewModelBase vm)
        //{
        //    IWindowManager manager = new WindowManager();
        //    return manager.ShowDialog(vm, null, null);
        //}

        public static string BrowseFileToSave()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = FILE_EXTENSION;
            dialog.Filter = FILE_FILTER;
            bool? result = dialog.ShowDialog();
            if (result != true) //null or false
                return null;
            return dialog.FileName;
        }

        public static string BrowseFileToOpen()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = FILE_EXTENSION;
            dialog.Filter = FILE_FILTER;
            bool? result = dialog.ShowDialog();
            if (result != true) //null or false
                return null;
            return dialog.FileName;
        }

        //public static bool? ConfirmDialog(string msg)
        //{
        //    DialogConfirmViewModel vm = new DialogConfirmViewModel(msg);
        //    IWindowManager manager = new WindowManager();
        //    manager.ShowDialog(vm, null, null);
        //    return vm.Result;
        //}

        public static void Error(string errorMsg)
        {
            //DialogErrorViewModel vm = new DialogErrorViewModel(errorMsg);
            //IWindowManager manager = new WindowManager();
            //manager.ShowDialog(vm, null, null);
            //TODO
            Console.WriteLine("----- ERROR -----");
            Console.WriteLine(errorMsg);
            Console.WriteLine("-----------------");
        }

    }
}
