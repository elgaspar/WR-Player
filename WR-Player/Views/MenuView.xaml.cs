using MahApps.Metro.Controls.Dialogs;
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



        public bool IsCompactModeEnabled
        {
            get { return (bool)GetValue(IsCompactModeEnabledProperty); }
            set { SetValue(IsCompactModeEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCompactModeEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCompactModeEnabledProperty =
            DependencyProperty.Register("IsCompactModeEnabled", typeof(bool), typeof(MenuView), new PropertyMetadata(false));



        public void MakeVisible()
        {
            Visibility = Visibility.Visible;
        }

        public void MakeInvisible()
        {
            Visibility = Visibility.Collapsed;
        }



        private void Click_PlaylistNew(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistNew();
        }

        private void Click_PlaylistOpen(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistOpen();
        }

        private void Click_PlaylistSave(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistSave();
        }

        private void Click_PlaylistSaveAs(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistSaveAs();
        }    
        


        private void Click_AddFile(object sender, RoutedEventArgs e)
        {
            Actions.AddFile();
        }

        private void Click_AddDirectory(object sender, RoutedEventArgs e)
        {
            Actions.AddDirectory();
        }

        private void Click_AddUrl(object sender, RoutedEventArgs e)
        {
            Actions.AddUrl();
        }



        private void Click_RemoveSelected(object sender, RoutedEventArgs e)
        {
            Actions.RemoveSelected();
        }

        private void Click_RemoveAll(object sender, RoutedEventArgs e)
        {
            Actions.RemoveAll();
        }



        private void Click_CompactMode(object sender, RoutedEventArgs e)
        {
            Actions.EnableCompactMode();
        }

        private void Click_Settings(object sender, RoutedEventArgs e)
        {
            Actions.Settings();
        }

        private void Click_About(object sender, RoutedEventArgs e)
        {
            Actions.About();
        }

        
    }
}
