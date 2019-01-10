using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    class Dialogs
    {
        //TODO
        private static readonly string FILE_EXTENSION = ".m3u8";
        private static readonly string FILE_FILTER = "UTF-8 Encoded Audio Playlist files (*.m3u8)|*.m3u8";



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

        public static void StreamAdd(MainViewModel mainVM)
        {
            ShowDialog(new DialogStreamAddEditViewModel(mainVM, true));
        }

        public static void StreamEdit(MainViewModel mainVM)
        {
            ShowDialog(new DialogStreamAddEditViewModel(mainVM, false));
        }

        public static bool? StreamRemove()
        {
            return ConfirmDialog("Remove selected entry?");
        }

        public static bool? PromptForSave()
        {
            return ConfirmDialog("Save changes in playlist?");
        }

        public static void Settings(MainViewModel mainVM)
        {
            ShowDialog(new DialogSettingsViewModel(mainVM));
        }

        public static void Error(string errorMsg)
        {
            DialogErrorViewModel vm = new DialogErrorViewModel(errorMsg);
            IWindowManager manager = new WindowManager();
            manager.ShowDialog(vm, null, null);
        }


        private static bool? ShowDialog(DialogViewModelBase vm)
        {
            IWindowManager manager = new WindowManager();
            return manager.ShowDialog(vm, null, null);
        }

        private static bool? ConfirmDialog(string msg)
        {
            DialogConfirmViewModel vm = new DialogConfirmViewModel(msg);
            ShowDialog(vm);
            return vm.Result;
        }
    }
}
