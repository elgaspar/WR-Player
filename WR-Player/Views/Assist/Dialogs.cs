using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WR_Player.Models;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    class Dialogs
    {
        private static readonly string PLAYLIST_FILE_FILTER = playlistFileFilter();
        private static readonly string AUDIO_FILE_FILTER = audioFileFilter();



        public static string BrowsePlaylistFileToSave()
        {
            return ShowFileSaveDialog(PLAYLIST_FILE_FILTER);
        }

        public static string BrowsePlaylistFileToOpen()
        {
            return ShowFileOpenDialog(PLAYLIST_FILE_FILTER);
        }

        public static string BrowseAudioFileToOpen()
        {
            return ShowFileOpenDialog(AUDIO_FILE_FILTER);
        }

        public static string BrowseFolderToOpen()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                return dialog.SelectedPath;
            else
                return null;
        }



        public static void AddUrl(MainViewModel mainVM)
        {
            ShowDialog(new DialogAddUrlViewModel(mainVM));
        }

        public static Result ConfirmRemoveSelected()
        {
            return ConfirmDialog("Remove selected item?");
        }

        public static Result ConfirmRemoveAll()
        {
            return ConfirmDialog("Remove all items?");
        }

        public static Result Edit(MainViewModel mainVM)
        {
            DialogEditPlaylistItemViewModel vm = new DialogEditPlaylistItemViewModel(mainVM);
            ShowDialog(vm);
            return boolToSuccessFail(vm.Success);
        }

        public static Result ConfirmPromptForSave()
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

        public static void About()
        {
            ShowDialog(new DialogAboutViewModel());
        }





        public enum Result { Yes, No, Cancel, Success, Fail}





        private static string ShowFileSaveDialog(string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            //dialog.DefaultExt = PLAYLIST_FILE_EXTENSION;
            dialog.Filter = filter;
            bool? result = dialog.ShowDialog();
            if (result != true) //null or false
                return null;
            return dialog.FileName;
        }

        private static string ShowFileOpenDialog(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.DefaultExt = PLAYLIST_FILE_EXTENSION;
            dialog.Filter = filter;
            bool? result = dialog.ShowDialog();
            if (result != true) //null or false
                return null;
            return dialog.FileName;
        }

        private static bool? ShowDialog(DialogViewModelBase vm)
        {
            IWindowManager manager = new WindowManager();
            return manager.ShowDialog(vm, null, null);
        }

        private static Result ConfirmDialog(string msg)
        {
            DialogConfirmViewModel vm = new DialogConfirmViewModel(msg);
            ShowDialog(vm);
            return boolToYesNo(vm.Result);
        }

        private static Result boolToYesNo(bool? value)
        {
            if (value == true)
                return Result.Yes;
            if (value == false)
                return Result.No;
            return Result.Cancel;
        }

        private static Result boolToSuccessFail(bool? value)
        {
            if (value == true)
                return Result.Success;
            if (value == false)
                return Result.Fail;
            return Result.Cancel;
        }

        private static string playlistFileFilter()
        {
            return "Playlist files (*.m3u8) | *.m3u8";
        }

        private static string audioFileFilter()
        {
            //"Audio files (*.aac, *.mp3, *.ogg, *.wav, *.wma) | *.aac; *.mp3; *.ogg; *.wav; *.wma"
            string filter1 = "(";
            string filter2 = "";
            foreach (AudioType at in Enum.GetValues(typeof(AudioType)).Cast<AudioType>())
            {
                if (at != AudioType.Url)
                {
                    string ext = "*." + at.ToString().ToLower();
                    filter1 += ext + ", ";
                    filter2 += ext + "; ";
                }
            }
            filter1 = filter1.Remove(filter1.Length - 2);
            filter2 = filter2.Remove(filter2.Length - 2);
            string result = "Audio files " + filter1 + ") | " + filter2;
            return result;
        }
    }
}
