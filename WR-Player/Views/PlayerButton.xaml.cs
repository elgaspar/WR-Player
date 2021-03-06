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
    /// Interaction logic for PlayerButton.xaml
    /// </summary>
    public partial class PlayerButton : Button
    {
        private double COMPACT_WIDTH_HEIGHT { get { return savedWidthHeight - 10; } }
        private double COMPACT_ICON_WIDTH_HEIGHT { get { return savedIconWidthHeight - 10; } }

        private const int COMPACT_MARGIN_LEFT = 2;
        private const int COMPACT_MARGIN_TOP = 2;
        private const int COMPACT_MARGIN_RIGHT = 2;
        private const int COMPACT_MARGIN_BOTTOM = 5;

        private double savedWidthHeight;
        private Thickness savedMargin;
        private double savedIconWidthHeight;

        public PlayerButton()
        {
            InitializeComponent();
        }

        public void EnableCompact()
        {
            savedWidthHeight = this.Width;
            savedMargin = this.Margin;

            this.Width = COMPACT_WIDTH_HEIGHT;
            this.Height = COMPACT_WIDTH_HEIGHT;
            this.Margin = new Thickness(COMPACT_MARGIN_LEFT, COMPACT_MARGIN_TOP, COMPACT_MARGIN_RIGHT, COMPACT_MARGIN_BOTTOM);

            IconContentControl icon = (IconContentControl)this.Content;
            savedIconWidthHeight = icon.IconWidth;
            icon.IconWidth = COMPACT_ICON_WIDTH_HEIGHT;
            icon.IconHeight = COMPACT_ICON_WIDTH_HEIGHT;
        }

        public void DisableCompact()
        {
            this.Width = savedWidthHeight;
            this.Height = savedWidthHeight;
            this.Margin = savedMargin;

            IconContentControl icon = (IconContentControl)this.Content;
            icon.IconWidth = savedIconWidthHeight;
            icon.IconHeight = savedIconWidthHeight;
        }
    }
}
