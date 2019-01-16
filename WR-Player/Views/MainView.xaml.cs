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
    public partial class MainView : MetroWindow
    {
        private double defaultMinWidth;
        private double defaultMinHeight;

        private WindowState savedState;
        private double savedWidth;
        private double savedHeight;
        

        public MainView()
        {
            InitializeComponent();

            initDefaultValues();
        }

        private void initDefaultValues()
        {
            defaultMinWidth = MinWidth;
            defaultMinHeight = MinHeight;
        }

        private void saveSizeAndState()
        {
            savedState = WindowState;
            savedWidth = Width;
            savedHeight = Height;
        }

        private void restoreSizeAndState()
        {
            WindowState = savedState;
            Width = savedWidth;
            Height = savedHeight;
        }

        public void EnableCompact()
        {
            saveSizeAndState();
            WindowState = WindowState.Normal;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.NoResize;
            ShowTitleBar = false;
            MinWidth = 0;
            MinHeight = 0;

            Topmost = Settings.AlwaysOnTop;
            ShowInTaskbar = !Settings.HideTaskbarIcon;

            compactModeRestoreButton.EnableCompact();
        }

        public void DisableCompact()
        {
            SizeToContent = SizeToContent.Manual;
            ResizeMode = ResizeMode.CanResize;
            ShowTitleBar = true;

            initWindowButtons();

            MinWidth = defaultMinWidth;
            MinHeight = defaultMinHeight;
            restoreSizeAndState();

            Topmost = false;
            ShowInTaskbar = true;

            compactModeRestoreButton.DisableCompact();
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
