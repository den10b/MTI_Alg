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

        }
        private int check1 = 0;
        private int check2 = 0;
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
            int num=0;
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

        }

        private void SimpDivCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LilFerma_Checked(object sender, RoutedEventArgs e)
        {

        }
        /*private int PrimeCheck()
{
int check = 1;
ulong pr = 1;
pr = Convert.ToUInt32(comboBox1.Text);
int c = Convert.ToInt32(comboBox2.Text);
if (((pr % 2) == 0) && (pr != 2))
{
label9.Text = "Number " + Convert.ToString(pr) + " is not prime. It divides by 2";
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

label9.Text = "Number " + Convert.ToString(pr) + " is not prime. It divides by " + Convert.ToString(k);
check = -1;
}
}
if (check == 1)
{

label9.Text = "Number " + Convert.ToString(pr) + " is prime";
return check;
}
if (check == -1)
label9.Text = "Number " + Convert.ToString(pr) + " is not prime. It divides by " + Convert.ToString(k);
return -1;
}
private void FermCheck()
{
if (textBox1.Visible)
basis.Add(Convert.ToUInt32(textBox1.Text));
if (textBox2.Visible)
basis.Add(Convert.ToUInt32(textBox2.Text));
if (textBox3.Visible)
basis.Add(Convert.ToUInt32(textBox3.Text));
if (textBox4.Visible)
basis.Add(Convert.ToUInt32(textBox4.Text));
if (textBox5.Visible)
basis.Add(Convert.ToUInt32(textBox5.Text));
ulong pr = 1;
ulong k = 1;
pr = Convert.ToUInt32(comboBox1.Text);
int c = Convert.ToInt32(comboBox3.Text);

for (int i = 0; i < basis.Count; i++)
{
ulong numb = Pow(basis[i], Convert.ToInt32(pr - 1)) % pr;
if (numb == 1)
{
label9.Text = "Number " + Convert.ToString(pr) + " is not prime. Ferma check";
return;
}
label9.Text = "Number " + Convert.ToString(pr) + " is prime.";
return;
}
label9.Text = "Number " + Convert.ToString(pr) + " is prime.";

}
private void button1_Click(object sender, EventArgs e)
{
if ((checkBox1.Checked) && (checkBox2.Checked))
{
if (PrimeCheck() == 1)
FermCheck();
}
else
if (checkBox1.Checked)
{
PrimeCheck();
}
else
if (checkBox2.Checked)
{
FermCheck();
}
label9.Visible = true;
basis.Clear();
}

private void CheckPrimeNumbers_Load(object sender, EventArgs e)
{
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
string[] PrimeNumbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
string[] BasisNumbers = { "1", "2", "3", "4", "5" };
comboBox1.Items.AddRange(InitialNumbers);
comboBox2.Items.AddRange(PrimeNumbers);
comboBox3.Items.AddRange(BasisNumbers);
textBox1.Text = "3";
textBox2.Text = "5";
textBox3.Text = "7";
textBox4.Text = "11";
textBox5.Text = "13";
comboBox2.Visible = false;
comboBox3.Visible = false;
label2.Visible = false;
label3.Visible = false;
label4.Visible = false;
label5.Visible = false;
label6.Visible = false;
label7.Visible = false;
label8.Visible = false;
label9.Visible = false;
textBox1.Visible = false;
textBox2.Visible = false;
textBox3.Visible = false;
textBox4.Visible = false;
textBox5.Visible = false;

}

private void label5_Click(object sender, EventArgs e)
{

}

private void checkBox2_CheckedChanged(object sender, EventArgs e)
{
if (comboBox3.Visible == false)
{
comboBox3.Visible = true;
label3.Visible = true;
check2 = 1;
}
else
{
comboBox3.Text = "";
comboBox3.Visible = false;
label3.Visible = false;
textBox1.Visible = false;
textBox2.Visible = false;
textBox3.Visible = false;
textBox4.Visible = false;
textBox5.Visible = false;
label4.Visible = false;
label5.Visible = false;
label6.Visible = false;
label7.Visible = false;
label8.Visible = false;
}
}

private void checkBox1_CheckedChanged(object sender, EventArgs e)
{
if (comboBox2.Visible == false)
{
comboBox2.Visible = true;
label2.Visible = true;
check1 = 1;
}
else
{
comboBox2.Visible = false;
label2.Visible = false;

}
}

private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
{
int choice = Convert.ToInt32(comboBox3.Text);
if (choice == 1)
{
textBox1.Visible = true;
textBox2.Visible = false;
textBox3.Visible = false;
textBox4.Visible = false;
textBox5.Visible = false;
label4.Visible = true;
label5.Visible = false;
label6.Visible = false;
label7.Visible = false;
label8.Visible = false;
}
if (choice == 2)
{
textBox1.Visible = true;
textBox2.Visible = true;
textBox3.Visible = false;
textBox4.Visible = false;
textBox5.Visible = false;
label4.Visible = true;
label5.Visible = true;
label6.Visible = false;
label7.Visible = false;
label8.Visible = false;
}
if (choice == 3)
{
textBox1.Visible = true;
textBox2.Visible = true;
textBox3.Visible = true;
textBox4.Visible = false;
textBox5.Visible = false;
label4.Visible = true;
label5.Visible = true;
label6.Visible = true;
label7.Visible = false;
label8.Visible = false;
}
if (choice == 4)
{
textBox1.Visible = true;
textBox2.Visible = true;
textBox3.Visible = true;
textBox4.Visible = true;
textBox5.Visible = false;
label4.Visible = true;
label5.Visible = true;
label6.Visible = true;
label7.Visible = true;
label8.Visible = false;
}
if (choice == 5)
{
textBox1.Visible = true;
textBox2.Visible = true;
textBox3.Visible = true;
textBox4.Visible = true;
textBox5.Visible = true;
label4.Visible = true;
label5.Visible = true;
label6.Visible = true;
label7.Visible = true;
label8.Visible = true;
}
}*/
    }
}

