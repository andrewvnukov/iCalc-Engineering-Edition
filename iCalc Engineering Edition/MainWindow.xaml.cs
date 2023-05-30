using NCalc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

namespace iCalc_Engineering_Edition
{

    public partial class MainWindow : Window
    {
        const string numbers = "1234567890";
        const string sign = "/*-+=";
        const string characters = numbers + sign;
        string []arr = {"sin","cos", "tg", "ctg", "arcsin", "arccos", "arctg", "arcctg", "Sqrt"};

        string input = "";

        bool isLabelUsed = false;
        bool isFromArr = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Button button = (Button)sender;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            string inputted_button = button.Content.ToString();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            if (inputted_button == "=")
            {
                try
                {
                    //input = input.Replace("sin", "Math.Sin").Replace("cos", "Math.Cos").Replace("tg", "Math.Tan");
                    var result = new DataTable().Compute(input, null);
                    box.Text = result.ToString();
                    label.Content = "";
                }catch(Exception) {
                    label.Content = "";
                    box.Text = "Error";
                }
            }
            else if (characters.Contains(inputted_button))
            {
                if (numbers.Contains(inputted_button))
                {
                    input += inputted_button;
                    box.Text += inputted_button;
                }
                if (sign.Contains(inputted_button))
                {
                    if (!isLabelUsed)
                    {
                        isLabelUsed = true;
                        label.Content = "";
                    }
                    input += inputted_button;
                    box.Text += inputted_button;
                    if (!isFromArr)
                    {
                        label.Content += box.Text;
                        box.Text = "";
                    }
                }
            }
            else if (arr.Contains(inputted_button))
            {
                box.Text += inputted_button + '(';
                input += inputted_button;
                isFromArr = true;
            }
            else if (inputted_button == "^")
            {
                box.Text += inputted_button;
                input += inputted_button;
            }
            else if (inputted_button == ")")
            {
                box.Text += inputted_button;

            }

        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            box.Text = "";
            label.Content = "";
            input = "";
        }
    }
}
