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
    /// Interaction logic for CompactTitleBar.xaml
    /// </summary>
    public partial class CompactTitleBar : UserControl, ICompact
    {
        public CompactTitleBar()
        {
            InitializeComponent();
        }

        
        public void EnableCompact()
        {
            this.Visibility = Visibility.Visible;
        }

        public void DisableCompact()
        {
            this.Visibility = Visibility.Collapsed;
        }


        private void CompactButton_Click_Restore(object sender, RoutedEventArgs e)
        {
            Actions.DisableCompactMode();
        }

        private void CompactButton_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
