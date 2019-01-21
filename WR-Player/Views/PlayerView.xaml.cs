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
        private const double COMPACT_USERCONTROL_WIDTH = 271; //TODO
        private const double COMPACT_USERCONTROL_HEIGHT = Double.NaN; //Double.NaN is the default value. (equal to "Auto" in xaml)

        private const double COMPACT_BUTTONS_WIDTH_HEIGHT = 30;
        private const double COMPACT_SLIDER_WIDTH = 100;
        private const double COMPACT_SLIDER_HEIGHT = 10;

        private double savedUserControlWidth;
        private double savedUserControlHeight;

        private double savedButtonsWidthHeight;
        private double savedSliderWidth;
        private double savedSliderHeight;

        


        public PlayerView()
        {
            InitializeComponent();

            saveDefaultSizeValues();
        }

        

        public void EnableCompact()
        {
            setCompactSizeUserControl();

            if (Settings.HideSeekingBar)
                hideSeekingBar();

            setCompactSizeButton(previousButton);
            setCompactSizeButton(playButton);
            setCompactSizeButton(stopButton);
            setCompactSizeButton(nextButton);

            setCompactSizeSlider(volumeSlider);
        }

        public void DisableCompact()
        {
            setNormalSizeUserControl();

            showSeekingBar();

            setNormalSizeButton(previousButton);
            setNormalSizeButton(playButton);
            setNormalSizeButton(stopButton);
            setNormalSizeButton(nextButton);

            setNormalSizeSlider(volumeSlider); 
        }





        private void saveDefaultSizeValues()
        {
            savedUserControlWidth = this.Width;
            savedUserControlHeight = this.Height;

            savedButtonsWidthHeight = previousButton.Width;
            savedSliderWidth = volumeSlider.Width;
            savedSliderHeight = volumeSlider.Height;  
        }




        

        private void setCompactSizeUserControl()
        {
            this.Width = COMPACT_USERCONTROL_WIDTH;
            this.Height = COMPACT_USERCONTROL_HEIGHT; 
        }

        private void hideSeekingBar()
        {
            seekingBarSlider.Style = (Style)FindResource("controlCollapsedStyle");
            seekingBarPositionDuration.Style = (Style)FindResource("stackPanelHiddenStyle");
            seekingProgressBar.Style = (Style)FindResource("controlCollapsedStyle");
        }

        private void setCompactSizeButton(Button button)
        {
            button.Width = COMPACT_BUTTONS_WIDTH_HEIGHT;
            button.Height = COMPACT_BUTTONS_WIDTH_HEIGHT;

            IconContentControl icon = (IconContentControl)button.Content;
            icon.IconWidth = COMPACT_BUTTONS_WIDTH_HEIGHT;
            icon.IconHeight = COMPACT_BUTTONS_WIDTH_HEIGHT;
        }

        private void setCompactSizeSlider(Slider slider)
        {
            slider.Width = COMPACT_SLIDER_WIDTH;
            slider.Height = COMPACT_SLIDER_HEIGHT;
        }



        

        private void setNormalSizeUserControl()
        {
            this.Width = savedUserControlWidth;
            this.Height = savedUserControlHeight;
        }

        private void showSeekingBar()
        {
            seekingBarSlider.Style = (Style)FindResource("seekingBarSliderStyle");
            seekingBarPositionDuration.Style = (Style)FindResource("seekingBarPositionDurationStyle");
            seekingProgressBar.Style = (Style)FindResource("seekingProgressBarStyle");
        }

        private void setNormalSizeButton(Button button)
        {
            button.Width = savedButtonsWidthHeight;
            button.Height = savedButtonsWidthHeight;

            IconContentControl icon = (IconContentControl)button.Content;
            icon.IconWidth = savedButtonsWidthHeight;
            icon.IconHeight = savedButtonsWidthHeight;
        }

        private void setNormalSizeSlider(Slider slider)
        {
            slider.Width = savedSliderWidth;
            slider.Height = savedSliderHeight;
        }

    }
}
