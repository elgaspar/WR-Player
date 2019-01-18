using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
            bool success = PromptForPlaylistSave();
            if (!success)
                return;

            mainVM.PlaylistVM.New();
        }

        public static void PlaylistOpen()
        {
            bool success = PromptForPlaylistSave();
            if (!success)
                return;

            string filepath = Dialogs.BrowsePlaylistFileToOpen();
            if (filepath == null)
                return;

            PlaylistOpen(filepath);
        }

        public static void PlaylistOpen(string filepath)
        {
            bool success = mainVM.PlaylistVM.Load(filepath);
            if (!success)
                Dialogs.Error("Couldn't open playlist.");
        }

        public static bool PlaylistSave()
        {
            if (!mainVM.PlaylistVM.IsPlaylistFileOpen)
                return PlaylistSaveAs();
            bool success = mainVM.PlaylistVM.Save();
            if (!success)
                Dialogs.Error("Couldn't save playlist.");
            return success;
        }

        public static bool PlaylistSaveAs()
        {
            string filepath = Dialogs.BrowsePlaylistFileToSave();
            if (filepath == null)
                return false;
            bool success = mainVM.PlaylistVM.SaveAs(filepath);
            if (!success)
                Dialogs.Error("Couldn't save playlist.");
            return success;
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
            addAllFiles(filepaths);
        }

        public static void AddUrl()
        {
            Dialogs.AddUrl(mainVM);
        }



        public static void RemoveSelected()
        {
            bool? result = Dialogs.RemoveSelected();
            if (result == true)
                mainVM.PlaylistVM.RemoveSelectedItems();
        }

        public static void RemoveAll()
        {
            bool? result = Dialogs.RemoveAll();
            if (result == true)
                mainVM.PlaylistVM.RemoveAllItems();
        }

        public static void EditSelected()
        {
            bool? success = Dialogs.Edit(mainVM);
            if (success == false)
                Dialogs.Error("Couldn't edit item. Filepath is invalid.");
        }

        public static void PlaySelected()
        {
            mainVM.PlaylistVM.SetSelectedItem();
            mainVM.PlayerVM.Play();
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
            WR_Player.Views.Assist.Settings.ApplyTheme();
        }

        public static void About()
        {
            Dialogs.About();
        }



        

        private static IEnumerable<string> getAllFilesInFolder(string folderPath)
        {
            return Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories).Where(s => hasValidAudioFormat(s));
        }

        private static void addAllFiles(IEnumerable<string> filepaths)
        {
            foreach (string path in filepaths)
                mainVM.PlaylistVM.AddFile(path);
        }

        private static bool hasValidAudioFormat(string path)
        {
            string filepath = path.ToLower();
            foreach (AudioType type in Enum.GetValues(typeof(AudioType)).Cast<AudioType>())
            {
                if (type != AudioType.Url)
                {
                    string ext = type.ToString().ToLower();
                    if (filepath.EndsWith(ext))
                        return true;
                }
            }
            return false;
        }

    }
}
