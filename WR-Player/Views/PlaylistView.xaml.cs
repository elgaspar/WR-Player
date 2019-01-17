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
using WR_Player.Models;
using WR_Player.ViewModels;
using WR_Player.Views.Assist;

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for PlaylistView.xaml
    /// </summary>
    public partial class PlaylistView : UserControl
    {
        public PlaylistView()
        {
            InitializeComponent();
        }

        public void MakeVisible()
        {
            Visibility = Visibility.Visible;
        }

        public void MakeInvisible()
        {
            Visibility = Visibility.Collapsed;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlaylistViewModel vm = (PlaylistViewModel)DataContext;

            foreach (PlaylistItem item in e.AddedItems)
                vm.ItemsToProcess.Add(item);

            foreach (PlaylistItem item in e.RemovedItems)
                vm.ItemsToProcess.Remove(item);
        }

        private void MenuItem_Click_Play(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void MenuItem_Click_Edit(object sender, RoutedEventArgs e)
        {
            Actions.Edit();
        }

        private void MenuItem_Click_Remove(object sender, RoutedEventArgs e)
        {
            Actions.RemoveSelected();
        }
    }
}
