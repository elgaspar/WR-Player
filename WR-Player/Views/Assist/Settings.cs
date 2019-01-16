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

        public static void Apply()
        {
            ApplyTheme();
            applyVolume();
            openLastUsedFileIfNeeded();
            enableCompactModeIfNeeded();
        }

        public static void Save()
        {
            Properties.Settings.Default.LastUsedFilepath = mainVM.PlaylistVM.Filepath;
            Properties.Settings.Default.IsCompacModeEnabled = mainWin.menu.IsCompactModeEnabled;
            Properties.Settings.Default.Volume = mainVM.PlayerVM.Volume;
            Properties.Settings.Default.Save();
        }

        public static void ApplyTheme()
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





        private static void applyVolume()
        {
            mainVM.PlayerVM.Volume = Properties.Settings.Default.Volume;
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
                Actions.EnableCompactMode();
        }
    }
}
