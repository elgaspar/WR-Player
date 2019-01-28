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
        private Brush savedBackground;

        private bool dragFromAnywhereIsEnabled;

        public MainView()
        {
            InitializeComponent();

            dragFromAnywhereIsEnabled = false;
        }

        private void saveValues()
        {
            savedMinWidth = MinWidth;
            savedMinHeight = MinHeight;
            savedState = WindowState;
            savedWidth = Width;
            savedHeight = Height;
            savedBackground = Background;
        }

        private void restoreValues()
        {
            MinWidth = savedMinWidth;
            MinHeight = savedMinHeight;
            WindowState = savedState;
            Width = savedWidth;
            Height = savedHeight;
            Background = savedBackground;
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
            Background = Brushes.Transparent;
            hideBorder();

            menu.EnableCompact();
            playlist.EnableCompact();
            player.EnableCompact();

            dragFromAnywhereIsEnabled = true;
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
            showBorder();

            menu.DisableCompact();
            playlist.DisableCompact();
            player.DisableCompact();

            dragFromAnywhereIsEnabled = false;
        }

        //window buttons (close, maximize, minimize) need to be reinitialized to be shown correctly
        private void initWindowButtons()
        {
            WindowButtonCommands = new WindowButtonCommands();
            WindowButtonCommands.ParentWindow = this;
        }

        private void showBorder()
        {
            this.BorderThickness = new Thickness(1);
        }

        private void hideBorder()
        {
            this.BorderThickness = new Thickness(0);
        }




        private void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Settings.Apply();
        }

        private void metroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = Actions.PromptForPlaylistSave();
            if (!success)
                e.Cancel = true; //cancel closing of application
            Settings.Save();
        }

        private void metroWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ( dragFromAnywhereIsEnabled && (e.ChangedButton == MouseButton.Left))
                this.DragMove();
        }
    }
}
