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
    public partial class PlayerView : UserControl
    {
        private const double COMPACT_BUTTONS_WIDTH_HEIGHT = 30;
        private const double COMPACT_SLIDER_WIDTH = 100;
        private const double COMPACT_SLIDER_HEIGHT = 10;

        private double default_buttons_width_height;
        private double default_slider_width;
        private double default_slider_height;

        public PlayerView()
        {
            InitializeComponent();

            initDefaultSizeValues();
        }

        private void initDefaultSizeValues()
        {
            default_buttons_width_height = previousButton.Width;
            default_slider_width = volumeSlider.Width;
            default_slider_height = volumeSlider.Height;
        }

        public void EnableCompact()
        {
            previousButton.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            previousButton.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            playButton.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            playButton.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            stopButton.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            stopButton.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            nextButton.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            nextButton.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            volumeSlider.Width = COMPACT_SLIDER_WIDTH;
            volumeSlider.Height = COMPACT_SLIDER_HEIGHT;

            Width = 271;
        }

        public void DisableCompact()
        {
            previousButton.Width = default_buttons_width_height;
            previousButton.Height = default_buttons_width_height;

            playButton.Width = default_buttons_width_height;
            playButton.Height = default_buttons_width_height;

            stopButton.Width = default_buttons_width_height;
            stopButton.Height = default_buttons_width_height;

            nextButton.Width = default_buttons_width_height;
            nextButton.Height = default_buttons_width_height;

            volumeSlider.Width = default_slider_width;
            volumeSlider.Height = default_slider_height;

            Width = Double.NaN; //Double.NaN is the default value. (equal to "Auto" in xaml)
        }

    }
}
