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



        private void PlaylistNew(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistNew();
        }

        private void PlaylistOpen(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistOpen();
        }

        private void PlaylistSave(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistSave();
        }

        private void PlaylistSaveAs(object sender, RoutedEventArgs e)
        {
            Actions.PlaylistSaveAs();
        }    
        
        private void StreamAdd(object sender, RoutedEventArgs e)
        {
            Actions.StreamAdd();
        }

        private void StreamEdit(object sender, RoutedEventArgs e)
        {
            Actions.StreamEdit();
        }

        private void StreamRemove(object sender, RoutedEventArgs e)
        {
            Actions.StreamRemove();
        }

        private void CompactMode(object sender, RoutedEventArgs e)
        {
            Actions.EnableCompactMode();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            Actions.Settings();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            Actions.About();
        }

        
    }
}
