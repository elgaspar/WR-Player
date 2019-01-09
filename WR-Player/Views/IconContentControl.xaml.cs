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
    /// Interaction logic for IconContentControl.xaml
    /// </summary>
    public partial class IconContentControl : ContentControl
    {
        public IconContentControl()
        {
            InitializeComponent();
        }

        public string DataPath
        {
            get { return (string)GetValue(DataPathProperty); }
            set { SetValue(DataPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataPathProperty =
            DependencyProperty.Register("DataPath", typeof(string), typeof(IconContentControl), new PropertyMetadata(string.Empty));

    }
}
