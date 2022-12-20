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
    /// Логика взаимодействия для PrimeNumGen.xaml
    /// </summary>
    public partial class PrimeNumGen : Window
    {
        public PrimeNumGen()
        {
            InitializeComponent();
        }
        private ulong pr1;
        private ulong pr2;
        private Randomer RNG = new Randomer();
        private Mod M = new Mod();
        public string request = "";

        private void PrimeNumGen_Load(object sender, EventArgs e)
        {
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8" };
            foreach (string number in numbers)
            {
                NumDigts.Items.Add(number);
            }

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
        public ulong GenPrimeNumber(int size)
        {
            ulong min = Pow(10, size - 1);
            ulong max = Pow(10, size);
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
                    if (M.mod(current, i) == 0)
                        innercheck = 1;
                }
                if ((innercheck == -1) && (RNG.Generate() > 9))
                {
                    result = current;
                    check = 1;
                }
                current = M.mod(current + 2 * RNG.Generate() * RNG.Generate(), max);
                if (current == 1)
                    current = 3;
            }
            return result;

        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            if (NumDigts.Text != "")
            {
                try{ var kkk = Convert.ToInt32(NumDigts.Text); }
                catch{ return; }

                ulong tpr1 = 0;
                ulong tpr2 = 0;
                int check = -1;
                int checkpr1 = -1;
                int checkpr2 = -1;
                while (check != 1)
                {
                    if (checkpr1 == -1)
                    {
                        tpr1 = GenPrimeNumber(Convert.ToInt32(NumDigts.Text));
                        checkpr1 = 1;
                    }
                    else if ((checkpr1 != -1) && (checkpr2 == -1))
                    {
                        tpr2 = GenPrimeNumber(Convert.ToInt32(NumDigts.Text));
                        checkpr2 = 1;
                        check = 1;
                    }
                }
                pr1 = tpr1;
                pr2 = tpr2;
                Result.Content = Convert.ToString(pr1);
                }
        }

        private void PrimeCheck_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
