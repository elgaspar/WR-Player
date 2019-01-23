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
    /// Interaction logic for SeekingBar.xaml
    /// </summary>
    public partial class SeekingBar : UserControl, ICompact
    {
        private const int COMPACT_MARGIN_LEFT = 5;
        private const int COMPACT_MARGIN_TOP = 0;
        private const int COMPACT_MARGIN_RIGHT = 5;
        private const int COMPACT_MARGIN_BOTTOM = 2;

        private Thickness savedMargin;

        public SeekingBar()
        {
            InitializeComponent();
        }

        public void DisableCompact()
        {
            this.Margin = savedMargin;
        }

        public void EnableCompact()
        {
            savedMargin = this.Margin;

            this.Margin = new Thickness(COMPACT_MARGIN_LEFT, COMPACT_MARGIN_TOP, COMPACT_MARGIN_RIGHT, COMPACT_MARGIN_BOTTOM);
        }

        public void Hide()
        {
            slider.Style = (Style)FindResource("controlCollapsedStyle");
            progressBar.Style = (Style)FindResource("controlCollapsedStyle");
        }

        public void Show()
        {
            slider.Style = (Style)FindResource("sliderStyle");
            progressBar.Style = (Style)FindResource("progressBarStyle");
        }
    }
}
