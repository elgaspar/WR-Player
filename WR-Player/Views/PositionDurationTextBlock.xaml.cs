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
    /// Interaction logic for PositionDurationTextBlock.xaml
    /// </summary>
    public partial class PositionDurationTextBlock : TextBlock, ICompact
    {
        private const int COMPACT_FONT_SIZE = 10;

        private const int COMPACT_MARGIN_LEFT = 0;
        private const int COMPACT_MARGIN_TOP = -5;
        private const int COMPACT_MARGIN_RIGHT = 2;
        private const int COMPACT_MARGIN_BOTTOM = 0;

        private double savedFontSize;
        private Thickness savedMargin;

        public PositionDurationTextBlock()
        {
            InitializeComponent();
        }

        public void DisableCompact()
        {
            this.FontSize = savedFontSize;
            this.Margin = savedMargin;
        }

        public void EnableCompact()
        {
            savedFontSize = this.FontSize;
            savedMargin = this.Margin;

            this.FontSize = COMPACT_FONT_SIZE;
            this.Margin = new Thickness(COMPACT_MARGIN_LEFT, COMPACT_MARGIN_TOP, COMPACT_MARGIN_RIGHT, COMPACT_MARGIN_BOTTOM);
        }
    }
}
