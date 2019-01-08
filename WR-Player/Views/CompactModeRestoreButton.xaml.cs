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
        public CompactModeRestoreButton()
        {
            InitializeComponent();
        }

        private void Button_Click_Restore(object sender, RoutedEventArgs e)
        {
            Actions.DisableCompactMode();
        }
    }
}
