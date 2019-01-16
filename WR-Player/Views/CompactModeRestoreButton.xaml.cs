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
    public partial class CompactModeRestoreButton : UserControl
    {
        private Thickness defaultMargin;

        public CompactModeRestoreButton()
        {
            InitializeComponent();
        }

        

        public void EnableCompact()
        {
            defaultMargin = this.Margin;
            if (Settings.HideSeekingBar)
                this.Margin = createMargin();
        }

        public void DisableCompact()
        {
            Console.WriteLine(defaultMargin);
            this.Margin = defaultMargin;
        }

        private Thickness createMargin()
        {
            double left = defaultMargin.Left;
            double top = 19;
            double right = defaultMargin.Right;
            double bottom = defaultMargin.Bottom;
            return new Thickness(left, top, right, bottom);
        }


        private void Button_Click_Restore(object sender, RoutedEventArgs e)
        {
            Actions.DisableCompactMode();
        }

    }
}
