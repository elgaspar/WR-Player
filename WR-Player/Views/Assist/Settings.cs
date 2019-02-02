using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    static class Settings
    {
        private static MainViewModel mainVM { get { return (MainViewModel)Application.Current.MainWindow.DataContext; } }
        private static MainView mainWin { get { return (MainView)Application.Current.MainWindow; } }



        public static bool OpenLastUsedFile
        {
            get { return Properties.Settings.Default.OpenLastUsedFile; }
            set
            {
                Properties.Settings.Default.OpenLastUsedFile = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string LastUsedFilepath
        {
            get { return Properties.Settings.Default.LastUsedFilepath; }
            set
            {
                Properties.Settings.Default.LastUsedFilepath = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool AlwaysOnTop
        {
            get { return Properties.Settings.Default.AlwaysOnTop; }
            set
            {
                Properties.Settings.Default.AlwaysOnTop = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool HideTaskbarIcon
        {
            get { return Properties.Settings.Default.HideTaskbarIcon; }
            set
            {
                Properties.Settings.Default.HideTaskbarIcon = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string Theme
        {
            get { return Properties.Settings.Default.Theme; }
            set
            {
                Properties.Settings.Default.Theme = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool IsCompacModeEnabled
        {
            get { return Properties.Settings.Default.IsCompacModeEnabled; }
            set
            {
                Properties.Settings.Default.IsCompacModeEnabled = value;
                Properties.Settings.Default.Save();
            }
        }

        public static double Volume
        {
            get { return Properties.Settings.Default.Volume; }
            set
            {
                Properties.Settings.Default.Volume = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool HideSeekingBar
        {
            get { return Properties.Settings.Default.HideSeekingBar; }
            set
            {
                Properties.Settings.Default.HideSeekingBar = value;
                Properties.Settings.Default.Save();
            }
        }





        public static void Apply()
        {
            ApplyTheme();
            applyVolume();
            openLastUsedFileIfNeeded();
            enableCompactModeIfNeeded();
        }

        public static void Save()
        {
            LastUsedFilepath = mainVM.PlaylistVM.Filepath;
            IsCompacModeEnabled = mainWin.menu.IsCompactModeEnabled;
            Volume = mainVM.PlayerVM.Volume;
        }

        public static void ApplyTheme()
        {
            try
            {
                Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Theme), ThemeManager.GetAppTheme("BaseLight"));
            }
            catch (Exception)
            {
                Dialogs.Error("Couldn't apply theme.");
            }
        }





        private static void applyVolume()
        {
            mainVM.PlayerVM.Volume = Volume;
        }

        private static void openLastUsedFileIfNeeded()
        {
            bool openFile = OpenLastUsedFile;
            bool validFile = !string.IsNullOrEmpty(LastUsedFilepath);
            if (openFile && validFile)
                mainVM.PlaylistVM.Load(LastUsedFilepath);
        }

        private static void enableCompactModeIfNeeded()
        {
            if (IsCompacModeEnabled)
                Actions.EnableCompactMode();
        }
    }
}
