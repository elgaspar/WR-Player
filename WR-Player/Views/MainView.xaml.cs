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
using WR_Player.Views.Assist;

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        private SizeToContent default_SizeToContent;
        private ResizeMode default_ResizeMode;
        private bool default_ShowTitleBar;
        private double default_MinWidth;
        private double default_MinHeight;

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
            default_SizeToContent = SizeToContent.Manual;
            default_ResizeMode = ResizeMode.CanResize;
            default_ShowTitleBar = true;
            default_MinWidth = MinWidth;
            default_MinHeight = MinHeight;
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
        }

        public void DisableCompact()
        {
            SizeToContent = default_SizeToContent;
            ResizeMode = default_ResizeMode;
            ShowTitleBar = default_ShowTitleBar;

            initWindowButtons();

            MinWidth = default_MinWidth;
            MinHeight = default_MinHeight;
            restoreSizeAndState();
        }

        //window buttons (close, maximize, minimize) need to be reinitialized to be shown correctly
        private void initWindowButtons()
        {
            WindowButtonCommands = new WindowButtonCommands();
            WindowButtonCommands.ParentWindow = this;
        }
    }
}
