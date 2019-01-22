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
    /// Interaction logic for CompactModeRestoreButton.xaml
    /// </summary>
    public partial class CompactModeRestoreButton : UserControl, ICompact
    {
        private Thickness savedMargin;

        public CompactModeRestoreButton()
        {
            InitializeComponent();
        }

        public void EnableCompact()
        {
            savedMargin = this.Margin;
            if (Settings.HideSeekingBar)
                this.Margin = createMargin();
        }

        public void DisableCompact()
        {
            this.Margin = savedMargin;
        }


        //TODO: use const value isntead
        private Thickness createMargin()
        {
            double left = savedMargin.Left;
            double top = 25;
            double right = savedMargin.Right;
            double bottom = savedMargin.Bottom;
            return new Thickness(left, top, right, bottom);
        }


        private void Button_Click_Restore(object sender, RoutedEventArgs e)
        {
            Actions.DisableCompactMode();
        }
    }
}
