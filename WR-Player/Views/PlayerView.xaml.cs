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
        private const double COMPACT_WIDTH = 240; //TODO
        private const double COMPACT_HEIGHT = Double.NaN; //Double.NaN is the default value. (equal to "Auto" in xaml)

        private double savedWidth;
        private double savedHeight;

        public PlayerView()
        {
            InitializeComponent();
        }

        public void EnableCompact()
        {
            saveValues();
            
            this.Width = COMPACT_WIDTH;
            this.Height = COMPACT_HEIGHT;

            if (Settings.HideSeekingBar)
                seekingBar.Hide();
            loadedItemTextBlock.EnableCompact();
            seekingBar.EnableCompact();
            previousButton.EnableCompact();
            playButton.EnableCompact();
            stopButton.EnableCompact();
            nextButton.EnableCompact();
            volumeSlider.EnableCompact();
            bufferingStatusTextBlock.EnableCompact();
            positionDurationTextBlock.EnableCompact();
        }

        public void DisableCompact()
        {
            restoreValues();
            
            seekingBar.Show();
            loadedItemTextBlock.DisableCompact();
            seekingBar.DisableCompact();
            previousButton.DisableCompact();
            playButton.DisableCompact();
            stopButton.DisableCompact();
            nextButton.DisableCompact();
            volumeSlider.DisableCompact();
            bufferingStatusTextBlock.DisableCompact();
            positionDurationTextBlock.DisableCompact();
        }


        private void saveValues()
        {
            savedWidth = this.Width;
            savedHeight = this.Height;
        }

        private void restoreValues()
        {
            this.Width = savedWidth;
            this.Height = savedHeight;
        }
    }
}
