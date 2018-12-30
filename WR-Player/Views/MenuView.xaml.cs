using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WR_Player.ViewModels;
using WR_Player.Views.Assist;

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }

        public MainViewModel MainVM { get { return (MainViewModel)Application.Current.MainWindow.DataContext; } }

        private void PlaylistNew(object sender, RoutedEventArgs e)
        {
            //bool? result = _promptForSaveAndSave("Do you want to save changes to file?");
            //if (result == null)
            //    return;

            Console.WriteLine("NEW");//TODO: delete it

            MainVM.PlaylistVM.New();
        }

        private void PlaylistOpen(object sender, RoutedEventArgs e)
        {
            //bool? result = _promptForSaveAndSave("Do you want to save changes to file?");
            //if (result == null)
            //    return;

            string filepath = Dialogs.BrowseFileToOpen();
            if (filepath == null)
                return;

            Console.WriteLine("OPEN: " + filepath);//TODO: delete it

            bool succeed = MainVM.PlaylistVM.Load(filepath);
            if (succeed == false)
                Dialogs.Error("Couldn't open playlist.");
        }

        private void PlaylistSave(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(MainVM.Filepath))
            //{
            //    return FileSaveAs();
            //}
            //else
            //{
            //    bool succeed = MainVM.Save(null);
            //    _handleError(succeed, "File saved successfully.", "Couldn't save file.");
            //    return succeed;
            //}
        }

        private void PlaylistSaveAs(object sender, RoutedEventArgs e)
        {
            string filepath = Dialogs.BrowseFileToSave();
            if (filepath == null)
                return;

            Console.WriteLine("SAVE AS: " + filepath);//TODO: delete it

            bool succeed = MainVM.PlaylistVM.Save(filepath);
            if (succeed == false)
                Dialogs.Error("Couldn't save playlist.");
        }

        private void StreamAdd(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void StreamEdit(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void StreamRemove(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void CompactMode(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void About(object sender, RoutedEventArgs e)
        {
            //TODO
        }


    }
}
