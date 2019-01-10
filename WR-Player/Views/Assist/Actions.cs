using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    static class Actions
    {
        private static MainViewModel mainVM { get { return (MainViewModel)Application.Current.MainWindow.DataContext; } }
        private static MainView mainWin { get { return (MainView)Application.Current.MainWindow; } }


        public static void PlaylistNew()
        {
            bool succeed = promptForSave();
            if (!succeed)
                return;

            mainVM.PlaylistVM.New();
        }

        public static void PlaylistOpen()
        {
            bool succeed = promptForSave();
            if (!succeed)
                return;

            string filepath = Dialogs.BrowseFileToOpen();
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
            if (!mainVM.PlaylistVM.isPlaylistFileOpen)
                return PlaylistSaveAs();
            bool succeed = mainVM.PlaylistVM.Save();
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }

        public static bool PlaylistSaveAs()
        {
            string filepath = Dialogs.BrowseFileToSave();
            if (filepath == null)
                return false;
            bool succeed = mainVM.PlaylistVM.SaveAs(filepath);
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }



        public static void StreamAdd()
        {
            Dialogs.StreamAdd(mainVM);
        }

        public static void StreamEdit()
        {
            Dialogs.StreamEdit(mainVM);
        }

        public static void StreamRemove()
        {
            bool? result = Dialogs.StreamRemove();
            if (result == true)
                mainVM.PlaylistVM.RemoveStream();
        }



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

        private static bool promptForSave()
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

    }
}
