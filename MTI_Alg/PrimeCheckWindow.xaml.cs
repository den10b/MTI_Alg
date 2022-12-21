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
    /// Логика взаимодействия для PrimeCheckWindow.xaml
    /// </summary>
    public partial class PrimeCheckWindow : Window
    {
        public PrimeCheckWindow(int old)
        {
            InitializeComponent();
            Box1.Visibility = Visibility.Hidden;
            Box2.Visibility = Visibility.Hidden;
            Box3.Visibility = Visibility.Hidden;
            Box4.Visibility = Visibility.Hidden;
            Box5.Visibility = Visibility.Hidden;
            Box6.Visibility = Visibility.Hidden;
            MyNum.Items.Add(old);
            string[] PrimeNumbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            foreach (string number in PrimeNumbers)
            {
                PrimeDiv.Items.Add(number);
            }




        }
        private int check1 = 0;
        private int check2 = 0;
        private int fermam = 0;
        private ulong signpr1;
        private ulong signpr2;
        private ulong encryptpr1;
        private ulong encryptpr2;
        private List<ulong> basis = new List<ulong>();
        public void SetInitNumbers(ulong tpr1, ulong tpr2, ulong tpr11, ulong tpr22)
        {
            signpr1 = tpr1;
            signpr2 = tpr2;
            encryptpr1 = tpr11;
            encryptpr2 = tpr22;
        }
        public ulong Pow(ulong number, int stepen)
        {
            ulong result = 1;
            for (int i = 0; i < stepen; i++)
            {
                result = result * number;
            }
            return result;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string? s = (sender as RadioButton).Content.ToString();
            int num = 0;
            try
            {
                num = Convert.ToInt32(s);
            }
            catch
            {
                return;
            }
            switch (num)
            {
                case 1:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Hidden;
                    Box3.Visibility = Visibility.Hidden;
                    Box4.Visibility = Visibility.Hidden;
                    Box5.Visibility = Visibility.Hidden;
                    Box6.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Visible;
                    Box3.Visibility = Visibility.Hidden;
                    Box4.Visibility = Visibility.Hidden;
                    Box5.Visibility = Visibility.Hidden;
                    Box6.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Visible;
                    Box3.Visibility = Visibility.Visible;
                    Box4.Visibility = Visibility.Hidden;
                    Box5.Visibility = Visibility.Hidden;
                    Box6.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Visible;
                    Box3.Visibility = Visibility.Visible;
                    Box4.Visibility = Visibility.Visible;
                    Box5.Visibility = Visibility.Hidden;
                    Box6.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Visible;
                    Box3.Visibility = Visibility.Visible;
                    Box4.Visibility = Visibility.Visible;
                    Box5.Visibility = Visibility.Visible;
                    Box6.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    Box1.Visibility = Visibility.Visible;
                    Box2.Visibility = Visibility.Visible;
                    Box3.Visibility = Visibility.Visible;
                    Box4.Visibility = Visibility.Visible;
                    Box5.Visibility = Visibility.Visible;
                    Box6.Visibility = Visibility.Visible;
                    break;
            }
            this.fermam = num;

            string[] InitialNumbers = { Convert.ToString(signpr1), Convert.ToString(signpr2), Convert.ToString(encryptpr1), Convert.ToString(encryptpr2) };
            if (((signpr1 == 0) && (signpr2 == 0)) && ((encryptpr1 == 0) && (encryptpr2 == 0)))
            {
                InitialNumbers[0] = "";
                InitialNumbers[1] = "";
                InitialNumbers[2] = "";
                InitialNumbers[3] = "";
            }
            if (((signpr1 != 0) && (signpr2 != 0)) && ((encryptpr1 == 0) && (encryptpr2 == 0)))
            {
                InitialNumbers[2] = "";
                InitialNumbers[3] = "";
            }
            if (((signpr1 == 0) && (signpr2 == 0)) && ((encryptpr1 != 0) && (encryptpr2 != 0)))
            {
                InitialNumbers[0] = "";
                InitialNumbers[1] = "";
            }
        }

        
        private int PrimeCheck()
        {
            int check = 1;
            ulong pr = 1;
            pr = Convert.ToUInt32(MyNum.Text);
            int c = Convert.ToInt32(PrimeDiv.Text);
            if (((pr % 2) == 0) && (pr != 2))
            {
                Result.Content = "Число " + Convert.ToString(pr) + " составное. Оно делится на 2";
                check = -1;
            }
            ulong k = 1;
            for (ulong i = 1; i < Convert.ToUInt32(c); i++)
            {
                k = i * 2 + 1;
                if (k >= pr)
                    break;
                if ((pr % k) == 0)
                {

                    Result.Content = "Число " + Convert.ToString(pr) + " составное. Оно делится на " + Convert.ToString(k);
                    check = -1;
                }
            }
            if (check == 1)
            {

                Result.Content = "Число " + Convert.ToString(pr) + " простое";
                return check;
            }
            if (check == -1)
                Result.Content = "Число " + Convert.ToString(pr) + " составное. Оно делится на " + Convert.ToString(k);
            return -1;
        }
        private void FermCheck()
        {
            if (Box1.Visibility==Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box1.Text));
            if (Box2.Visibility == Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box2.Text));
            if (Box3.Visibility == Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box3.Text));
            if (Box4.Visibility == Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box4.Text));
            if (Box5.Visibility == Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box5.Text));
            if (Box6.Visibility == Visibility.Visible)
                basis.Add(Convert.ToUInt32(Box6.Text));
            ulong pr = Convert.ToUInt32(MyNum.Text);


            foreach (ulong it in basis)
            {
                ulong numb = Pow(it, Convert.ToInt32(pr - 1)) % pr;
                if (numb == 1)
                {
                    Result.Content = "Число " + Convert.ToString(pr) + " составное. Тест Ферма.";
                    return;
                }
                Result.Content = "Число " + Convert.ToString(pr) + " простое.";
                return;
            }
            Result.Content = "Число " + Convert.ToString(pr) + " простое.";

        }
   

        private void TheButton_Click(object sender, RoutedEventArgs e)
        {
            if (((bool)LilFerma.IsChecked) && ((bool)PrimeDivCh.IsChecked))
            {
                if (PrimeCheck() == 1)
                    FermCheck();
            }
            else
            if ((bool)PrimeDivCh.IsChecked)
            {
                PrimeCheck();
            }
            else
            if ((bool)LilFerma.IsChecked)
            {
                FermCheck();
            }
            Result.Visibility = Visibility.Visible;
            basis.Clear();
        }
    }
}


