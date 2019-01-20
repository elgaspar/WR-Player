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

        

        public void EnableCompact()
        {
            if (Settings.HideSeekingBar)
                hideSeekingBar();
            setCompactSize(previousButton);
            setCompactSize(playButton);
            setCompactSize(stopButton);
            setCompactSize(nextButton);
            setCompactSize(volumeSlider);

            Width = 271;
        }

        public void DisableCompact()
        {
            showSeekingBar();
            setNormalSize(previousButton);
            setNormalSize(playButton);
            setNormalSize(stopButton);
            setNormalSize(nextButton);
            setNormalSize(volumeSlider);

            Width = Double.NaN; //Double.NaN is the default value. (equal to "Auto" in xaml)
        }





        private void initDefaultSizeValues()
        {
            default_buttons_width_height = previousButton.Width;
            default_slider_width = volumeSlider.Width;
            default_slider_height = volumeSlider.Height;
        }



        private void hideSeekingBar()
        {
            seekingBarSlider.Style = (Style)FindResource("controlCollapsedStyle");
            seekingBarPositionDuration.Style = (Style)FindResource("stackPanelHiddenStyle");
            seekingProgressBar.Style = (Style)FindResource("controlCollapsedStyle");
        }

        private void showSeekingBar()
        {
            seekingBarSlider.Style = (Style)FindResource("seekingBarSliderStyle");
            seekingBarPositionDuration.Style = (Style)FindResource("seekingBarPositionDurationStyle");
            seekingProgressBar.Style = (Style)FindResource("seekingProgressBarStyle");
        }

        private void setCompactSize(Button button)
        {
            button.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            button.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            IconContentControl icon = (IconContentControl)button.Content;
            icon.IconWidth = COMPACT_BUTTONS_WIDTH_HEIGHT;
            icon.IconHeight = COMPACT_BUTTONS_WIDTH_HEIGHT;
        }

        private void setCompactSize(Slider slider)
        {
            slider.Width = COMPACT_SLIDER_WIDTH;
            slider.Height = COMPACT_SLIDER_HEIGHT;
        }



        private void setNormalSize(Button button)
        {
            button.Width = default_buttons_width_height;
            button.Height = default_buttons_width_height;

            IconContentControl icon = (IconContentControl)button.Content;
            icon.IconWidth = default_buttons_width_height;
            icon.IconHeight = default_buttons_width_height;
        }

        private void setNormalSize(Slider slider)
        {
            slider.Width = default_slider_width;
            slider.Height = default_slider_height;
        }

    }
}
