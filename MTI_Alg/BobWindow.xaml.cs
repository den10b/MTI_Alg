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
using System.Windows.Shapes;

namespace MTI_Alg
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class BobWindow : Window
    {
        AliceWindow mom;
        public BobWindow(AliceWindow mom)
        {
            InitializeComponent();
            this.mom = mom; 
        }




        private Randomer RNG = new Randomer();

        private Randomer rrr = new Randomer();



        private void SKGen_Click(object sender, RoutedEventArgs e)
        {
            skb_val.Content = Gener(6);
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

            return Convert.ToString(tpr1%10000);

        }

        private void PKGen_Click(object sender, RoutedEventArgs e)
        {
            pkb_val.Content = Mops.powMod((ulong)Convert.ToInt64(g_value.Content), (ulong)Convert.ToInt64(skb_val.Content), (ulong)Convert.ToInt64(n_value.Content));
        }

        private void RA_Gen_Click(object sender, RoutedEventArgs e)
        {
            var limit = Convert.ToInt32(n_value.Content) - 1;
            rb_val.Content = rrr.GenLil(limit);
        }

        private void ACalc_Click(object sender, RoutedEventArgs e)
        {
            B_val.Content = Mops.powMod((ulong)Convert.ToInt64(g_value.Content), (ulong)Convert.ToInt64(rb_val.Content), (ulong)Convert.ToInt64(n_value.Content));
        }



        private void CalcSessKey_Click(object sender, RoutedEventArgs e)
        {
            ulong Pka = (ulong) Convert.ToInt64(pka_val.Content);
            ulong Rb = (ulong) Convert.ToInt64(rb_val.Content);
            ulong A = (ulong) Convert.ToInt64(A_val.Content);
            ulong SKb = (ulong) Convert.ToInt64(skb_val.Content);
            ulong n = (ulong) Convert.ToInt64(n_value.Content);
            //var res = Mod.mod((Pow(Pka, Rb) * Pow(A, SKb)), n);
            ulong lef = Mops.powMod(Pka,Rb, n);
            ulong rig = Mops.powMod(A,SKb, n);
            ulong res = Mops.mulMod(lef,rig,n);
            SessKey.Content = res;
        }














        private void Send_PK_Click(object sender, RoutedEventArgs e)
        {
            mom.pkb_val.Content = pkb_val.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mom.b_val.Content = B_val.Content;
        }
    }
}
