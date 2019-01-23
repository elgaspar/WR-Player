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

namespace WR_Player.Views
{
    /// <summary>
    /// Interaction logic for VolumeSlider.xaml
    /// </summary>
    public partial class VolumeSlider : Slider, ICompact
    {
        private const double COMPACT_WIDTH = 100;
        private const double COMPACT_HEIGHT = 10;

        private const int COMPACT_MARGIN_LEFT = 2;
        private const int COMPACT_MARGIN_TOP = 2;
        private const int COMPACT_MARGIN_RIGHT = 5;
        private const int COMPACT_MARGIN_BOTTOM = 5;

        private double savedWidth;
        private double savedHeight;
        private Thickness savedMargin;

        public VolumeSlider()
        {
            InitializeComponent();
        }

        public void DisableCompact()
        {
            this.Width = savedWidth;
            this.Height = savedHeight;
            this.Margin = savedMargin;
        }

        public void EnableCompact()
        {
            savedWidth = this.Width;
            savedHeight = this.Height;
            savedMargin = this.Margin;

            this.Width = COMPACT_WIDTH;
            this.Height = COMPACT_HEIGHT;
            this.Margin = new Thickness(COMPACT_MARGIN_LEFT, COMPACT_MARGIN_TOP, COMPACT_MARGIN_RIGHT, COMPACT_MARGIN_BOTTOM);
        }
    }
}
