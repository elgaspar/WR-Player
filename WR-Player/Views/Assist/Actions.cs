using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WR_Player.ViewModels;

namespace WR_Player.Views.Assist
{
    static class Actions
    {
        public static MainViewModel MainVM { get { return (MainViewModel)Application.Current.MainWindow.DataContext; } }



        public static void PlaylistNew()
        {
            if (!promptForSaveSucceed())
                return;

            MainVM.PlaylistVM.New();
        }

        public static void PlaylistOpen()
        {
            if (!promptForSaveSucceed())
                return;

            string filepath = Dialogs.BrowseFileToOpen();
            if (filepath == null)
                return;

            bool succeed = MainVM.PlaylistVM.Load(filepath);
            if (!succeed)
                Dialogs.Error("Couldn't open playlist.");
        }

        public static bool PlaylistSave()
        {
            if (!MainVM.PlaylistVM.isPlaylistFileOpen)
                return PlaylistSaveAs();
            bool succeed = MainVM.PlaylistVM.Save();
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }

        public static bool PlaylistSaveAs()
        {
            string filepath = Dialogs.BrowseFileToSave();
            if (filepath == null)
                return false;
            bool succeed = MainVM.PlaylistVM.SaveAs(filepath);
            if (!succeed)
                Dialogs.Error("Couldn't save playlist.");
            return succeed;
        }



        public static void StreamAdd()
        {
            Dialogs.StreamAdd(MainVM);
        }

        public static void StreamEdit()
        {
            Dialogs.StreamEdit(MainVM);
        }

        public static void StreamRemove()
        {
            bool? result = Dialogs.StreamRemove();
            if (result == true)
                MainVM.PlaylistVM.RemoveStream();
        }



        public static void CompactMode()
        {
            Console.WriteLine("COMPACT MODE");//TODO: delete it
            //TODO
        }

        public static void Settings()
        {
            Console.WriteLine("SETTINGS");//TODO: delete it
            //TODO
        }

        public static void About()
        {
            Console.WriteLine("ABOUT");//TODO: delete it
            //TODO
        }





        private static bool promptForSaveSucceed()
        {
            if (MainVM.PlaylistVM.AnyChangeHappened)
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
