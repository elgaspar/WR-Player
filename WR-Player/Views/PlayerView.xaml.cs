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
using WR_Player.Views.Assist;

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for PlayerControlView.xaml
    /// </summary>
    public partial class PlayerView : UserControl, ICompact
    {
        private const double COMPACT_WIDTH = 258;
        private const double COMPACT_HEIGHT = Double.NaN; //Double.NaN is the default value. (equal to "Auto" in xaml)

        private const int COMPACT_GRID_MARGIN_LEFT = 3;
        private const int COMPACT_GRID_MARGIN_TOP = 0;
        private const int COMPACT_GRID_MARGIN_RIGHT = 3;
        private const int COMPACT_GRID_MARGIN_BOTTOM = 0;

        private double savedWidth;
        private double savedHeight;
        private Thickness savedGridMargin;

        public PlayerView()
        {
            InitializeComponent();
        }

        public void EnableCompact()
        {
            saveValues();
            
            this.Width = COMPACT_WIDTH;
            this.Height = COMPACT_HEIGHT;
            grid.Margin = new Thickness(COMPACT_GRID_MARGIN_LEFT, COMPACT_GRID_MARGIN_TOP, COMPACT_GRID_MARGIN_RIGHT, COMPACT_GRID_MARGIN_BOTTOM);

            showBorder();
          
            if (Settings.HideSeekingBar)
                seekingBar.Hide();
            loadedItemTextBlock.EnableCompact();
            seekingBar.EnableCompact();
            previousButton.EnableCompact();
            playButton.EnableCompact();
            pauseButton.EnableCompact();
            stopButton.EnableCompact();
            nextButton.EnableCompact();
            volumeSlider.EnableCompact();
            bufferingStatusTextBlock.EnableCompact();
            positionDurationTextBlock.EnableCompact();
            compactTitleBar.EnableCompact();
        }

        public void DisableCompact()
        {
            restoreValues();
            hideBorder();

            seekingBar.Show();
            loadedItemTextBlock.DisableCompact();
            seekingBar.DisableCompact();
            previousButton.DisableCompact();
            playButton.DisableCompact();
            pauseButton.DisableCompact();
            stopButton.DisableCompact();
            nextButton.DisableCompact();
            volumeSlider.DisableCompact();
            bufferingStatusTextBlock.DisableCompact();
            positionDurationTextBlock.DisableCompact();
            compactTitleBar.DisableCompact();
        }


        private void saveValues()
        {
            savedWidth = this.Width;
            savedHeight = this.Height;
            savedGridMargin = grid.Margin;
        }

        private void restoreValues()
        {
            this.Width = savedWidth;
            this.Height = savedHeight;
            grid.Margin = savedGridMargin;
        }

        private void showBorder()
        {
            border.BorderThickness = new Thickness(1);
        }

        private void hideBorder()
        {
            border.BorderThickness = new Thickness(0);
        }
    }
}
