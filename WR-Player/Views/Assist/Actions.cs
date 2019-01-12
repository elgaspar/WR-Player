using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WR_Player.Models;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    static class Actions
    {
        private static MainViewModel mainVM { get { return (MainViewModel)Application.Current.MainWindow.DataContext; } }
        private static MainView mainWin { get { return (MainView)Application.Current.MainWindow; } }


        public static void PlaylistNew()
        {
            bool succeed = PromptForPlaylistSave();
            if (!succeed)
                return;

            mainVM.PlaylistVM.New();
        }

        public static void PlaylistOpen()
        {
            bool succeed = PromptForPlaylistSave();
            if (!succeed)
                return;

            string filepath = Dialogs.BrowsePlaylistFileToOpen();
            if (filepath == null)
                return;

            PlaylistOpen(filepath);
        }

        private static void PlaylistOpen(string filepath)
        {
            bool succeed = mainVM.PlaylistVM.Load(filepath);
            if (!succeed)
                Dialogs.Error("Couldn't open playlist.");
        }

        public static bool PlaylistSave()
        {
            if (!mainVM.PlaylistVM.IsPlaylistFileOpen)
                return PlaylistSaveAs();
            bool succeed = mainVM.PlaylistVM.Save();
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }

        public static bool PlaylistSaveAs()
        {
            string filepath = Dialogs.BrowsePlaylistFileToSave();
            if (filepath == null)
                return false;
            bool succeed = mainVM.PlaylistVM.SaveAs(filepath);
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }

        public static bool PromptForPlaylistSave()
        {
            if (mainVM.PlaylistVM.AnyChangeHappened)
            {
                bool? result = Dialogs.PromptForSave();
                if (result == null)
                    return false;
                if (result == true)
                {
                    bool saveSucceed = PlaylistSave();
                    return saveSucceed;
                }
            }
            return true;
        }



        public static void AddFile()
        {
            string filepath = Dialogs.BrowseAudioFileToOpen();
            if (filepath == null)
                return;
            mainVM.PlaylistVM.AddFile(filepath);
        }

        public static void AddDirectory()
        {
            string folderPath = Dialogs.BrowseFolderToOpen();
            if (folderPath == null)
                return;
            IEnumerable<string> filepaths = getAllFilesInFolder(folderPath);
            foreach(string path in filepaths)
                mainVM.PlaylistVM.AddFile(path);
        }

        public static void AddUrl()
        {
            Dialogs.AddUrl(mainVM);
        }



        public static void RemoveSelected()
        {
            bool? result = Dialogs.RemoveSelected();
            if (result == true)
                mainVM.PlaylistVM.RemoveSelectedItem();
        }

        public static void RemoveAll()
        {
            bool? result = Dialogs.RemoveAll();
            if (result == true)
                mainVM.PlaylistVM.RemoveAllItems();
        }

        //public static void StreamAdd()
        //{
        //    Dialogs.StreamAdd(mainVM);
        //}

        //public static void StreamEdit()
        //{
        //    Dialogs.StreamEdit(mainVM);
        //}

        //public static void StreamRemove()
        //{
        //    bool? result = Dialogs.StreamRemove();
        //    if (result == true)
        //        mainVM.PlaylistVM.RemoveStream();
        //}



        public static void EnableCompactMode()
        {
            mainWin.menu.IsCompactModeEnabled = true;
            mainWin.EnableCompact();
            mainWin.menu.MakeInvisible();
            mainWin.playlist.MakeInvisible();
            mainWin.player.EnableCompact();
        }

        public static void DisableCompactMode()
        {
            mainWin.DisableCompact();
            mainWin.menu.MakeVisible();
            mainWin.playlist.MakeVisible();
            mainWin.player.DisableCompact();
            mainWin.menu.IsCompactModeEnabled = false;
        }

        public static void Settings()
        {
            Dialogs.Settings(mainVM);
            applyTheme();
        }

        public static void About()
        {
            Console.WriteLine("ABOUT");//TODO: delete it
            //TODO
        }



        public static void ApplySettings()
        {
            applyTheme();
            openLastUsedFileIfNeeded();
            enableCompactModeIfNeeded();
        }

        public static void SaveSettings()
        {
            Properties.Settings.Default.LastUsedFilepath = mainVM.PlaylistVM.Filepath;
            Properties.Settings.Default.IsCompacModeEnabled = mainWin.menu.IsCompactModeEnabled;
            Properties.Settings.Default.Save();
        }







        private static void applyTheme()
        {
            try
            {
                Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Properties.Settings.Default.Theme), ThemeManager.GetAppTheme("BaseLight"));
            }
            catch (Exception)
            {
                Dialogs.Error("Couldn't apply theme.");
            }
        }

        private static void openLastUsedFileIfNeeded()
        {
            bool openFile = Properties.Settings.Default.OpenLastUsedFile;
            bool validFile = !string.IsNullOrEmpty(Properties.Settings.Default.LastUsedFilepath);
            if (openFile && validFile)
                Actions.PlaylistOpen(Properties.Settings.Default.LastUsedFilepath);
        }

        private static void enableCompactModeIfNeeded()
        {
            if (Properties.Settings.Default.IsCompacModeEnabled)
                EnableCompactMode();
        }

        private static IEnumerable<string> getAllFilesInFolder(string folderPath)
        {
            return Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories).Where(s => hasValidAudioFormat(s));
        }

        private static bool hasValidAudioFormat(string filepath)
        {
            string str = filepath.ToLower();
            foreach (AudioType at in Enum.GetValues(typeof(AudioType)).Cast<AudioType>())
            {
                if (at != AudioType.Url)
                {
                    string ext = at.ToString().ToLower();
                    if (str.EndsWith(ext))
                        return true;
                }
            }
            return false;
        }

    }
}
