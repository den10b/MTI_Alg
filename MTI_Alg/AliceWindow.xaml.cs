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

namespace MTI_Alg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AliceWindow : Window
    {
        private BobWindow bobWindow;
        public AliceWindow()
        {
            InitializeComponent();
            BobWindow win2 = new BobWindow();
            bobWindow = win2;
            bobWindow.Show();
        }

        private void NGen_Click(object sender, RoutedEventArgs e)
        {
            PrimeNumGen win = new PrimeNumGen(this,bobWindow);
            win.Show();
        }

        private void GGen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
