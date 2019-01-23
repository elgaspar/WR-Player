using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using WR_Player.ViewModels;
using WR_Player.Views.Assist;

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow, ICompact
    {
        private double savedMinWidth;
        private double savedMinHeight;
        private WindowState savedState;
        private double savedWidth;
        private double savedHeight;
        

        public MainView()
        {
            InitializeComponent();
        }

        private void saveValues()
        {
            savedMinWidth = MinWidth;
            savedMinHeight = MinHeight;
            savedState = WindowState;
            savedWidth = Width;
            savedHeight = Height;
        }

        private void restoreValues()
        {
            MinWidth = savedMinWidth;
            MinHeight = savedMinHeight;
            WindowState = savedState;
            Width = savedWidth;
            Height = savedHeight;
        }


        public void EnableCompact()
        {
            saveValues();

            WindowState = WindowState.Normal;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.NoResize;
            ShowTitleBar = false;
            ShowCloseButton = false;
            MinWidth = 0;
            MinHeight = 0;
            Topmost = Settings.AlwaysOnTop;
            ShowInTaskbar = !Settings.HideTaskbarIcon;

            menu.EnableCompact();
            playlist.EnableCompact();
            player.EnableCompact();
        }

        public void DisableCompact()
        {
            SizeToContent = SizeToContent.Manual;
            ResizeMode = ResizeMode.CanResize;
            ShowTitleBar = true;
            ShowCloseButton = true;
            Topmost = false;
            ShowInTaskbar = true;

            initWindowButtons();

            restoreValues();

            menu.DisableCompact();
            playlist.DisableCompact();
            player.DisableCompact();
        }

        //window buttons (close, maximize, minimize) need to be reinitialized to be shown correctly
        private void initWindowButtons()
        {
            WindowButtonCommands = new WindowButtonCommands();
            WindowButtonCommands.ParentWindow = this;
        }




        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Settings.Apply();
        }

        private void metroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Actions.PromptForPlaylistSave();
            Settings.Save();
        }
    }
}
