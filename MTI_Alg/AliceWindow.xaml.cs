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
        private Randomer RNG = new Randomer();
        private BobWindow bobWindow;
        private Randomer rrr = new Randomer();
        public AliceWindow()
        {
            InitializeComponent();
            BobWindow win2 = new BobWindow(this);
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
            ulong Nstr = (ulong) Convert.ToInt64(n_value.Content);
            var GVal = Mops.GetPRoot(Nstr);
            g_value.Content = GVal;
            bobWindow.g_value.Content = GVal; 

        }

        private void SKGen_Click(object sender, RoutedEventArgs e)
        {
            ska_val.Content = Gener(7);
        }

        public ulong GenPrimeNumber(ulong size)
        {
            ulong min = Mops.pow(10, size - 1);
            ulong max = Mops.pow(10, size);
            ulong current;
            ulong result = 0;
            if (min == 1)
                current = min;
            else
                current = min + 1;
            int check = -1;

            if (current < 10)
            {
                current = 2;
                if (RNG.Generate() > 9)
                    return current;
                else
                    current = 3;
            }
            while (check != 1)
            {
                int innercheck = -1;
                if (current < min)
                {
                    current += 2;
                    continue;
                }
                for (ulong i = 3; i < current / 2; i += 2)
                {
                    if (Mops.mod(current, i) == 0)
                        innercheck = 1;
                }
                if ((innercheck == -1) && (RNG.Generate() > 9))
                {
                    result = current;
                    check = 1;
                }
                current = Mops.mod(current + 2 * RNG.Generate() * RNG.Generate(), max);
                if (current == 1)
                    current = 3;
            }
            return result;

        }

        private string Gener(int am)
        {
                ulong tpr1 = 0;
                ulong tpr2 = 0;
                int check = -1;
                int checkpr1 = -1;
                int checkpr2 = -1;
                while (check != 1)
                {
                    if (checkpr1 == -1)
                    {
                        tpr1 = GenPrimeNumber((ulong)Convert.ToInt64(am));
                        checkpr1 = 1;
                    }
                    else if ((checkpr1 != -1) && (checkpr2 == -1))
                    {
                        tpr2 = GenPrimeNumber((ulong)Convert.ToInt64(am));
                        checkpr2 = 1;
                        check = 1;
                    }
                }
    
                return Convert.ToString(tpr1% 10000);
            
        }

        private void PKGen_Click(object sender, RoutedEventArgs e)
        {
            pka_val.Content = Mops.powMod((ulong)Convert.ToInt64(g_value.Content), (ulong)Convert.ToInt64(ska_val.Content), (ulong)Convert.ToInt64(n_value.Content));
        }

        private void RA_Gen_Click(object sender, RoutedEventArgs e)
        {
            var limit = Convert.ToInt32(n_value.Content) - 1;
            ra_val.Content = rrr.GenLil(limit);
        }

        private void ACalc_Click(object sender, RoutedEventArgs e)
        {
            A_val.Content = Mops.powMod((ulong)Convert.ToInt64(g_value.Content), (ulong)Convert.ToInt64(ra_val.Content), (ulong)Convert.ToInt64(n_value.Content));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bobWindow.A_val.Content = A_val.Content;
        }

        private void CalcSessKey_Click(object sender, RoutedEventArgs e)
        {
            ulong Pkb = (ulong) Convert.ToInt64(pkb_val.Content);
            ulong Ra = (ulong) Convert.ToInt64(ra_val.Content);
            ulong B = (ulong) Convert.ToInt64(b_val.Content);
            ulong SKa = (ulong) Convert.ToInt64(ska_val.Content);
            ulong n = (ulong) Convert.ToInt64(n_value.Content);
            ulong lef = Mops.powMod(Pkb,Ra, n);
            ulong rig = Mops.powMod(B,SKa, n);
            ulong res = Mops.mulMod(lef,rig,n);
            SessKey.Content = res;
        }

        private void Send_PK_Click(object sender, RoutedEventArgs e)
        {
            bobWindow.pka_val.Content = pka_val.Content;
        }
    }
}
