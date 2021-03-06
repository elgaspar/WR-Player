﻿using System;
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
    /// Interaction logic for LoadedItemTextBlock.xaml
    /// </summary>
    public partial class LoadedItemTextBlock : TextBlock, ICompact
    {
        private const double COMPACT_WIDTH = 185;
        private const int COMPACT_FONT_SIZE = 12;

        private double savedWidth;
        private double savedFontSize;

        public LoadedItemTextBlock()
        {
            InitializeComponent();
        }

        public void DisableCompact()
        {
            this.Width = savedWidth;
            this.FontSize = savedFontSize;
        }

        public void EnableCompact()
        {
            savedWidth = this.Width;
            savedFontSize = this.FontSize;

            this.Width = COMPACT_WIDTH;
            this.FontSize = COMPACT_FONT_SIZE;
        }
    }
}
