using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            int a= Convert.ToInt32(this.num1.Text); 
            int b = Convert.ToInt32(this.num2.Text);
            char c = char.Parse(this.action1.Text);
            double ans=double.Parse(answer.Text.ToString());
            switch(c)
            {
                case '+':
                    if (ans == a + b)
                        result.Text=("correct answer");
                    else
                        result.Text=("wrong answer");
                    break;
                case '-':
                    if (ans == a - b)
                        result.Text=("correct answer");
                    else
                        result.Text=("wrong answer");
                    break;
                case '*':
                    if (ans == a * b)
                        result.Text=("correct answer");
                    else
                        result.Text=("wrong answer");
                    break;
                case '/':
                    if (ans == a / b)
                        result.Text=("correct answer");
                    else
                        result.Text=("wrong answer");
                    break;
            }
            this.num1.Text = "";
            this.num2.Text = "";
            this.action1.Text = "";
            this.answer.Text = "";


        }

        private void Start(object sender, RoutedEventArgs e)
        {
            this.num1.Text = new Random().Next(1, 10).ToString();
            this.num2.Text = new Random().Next(1, 10).ToString();
            int x=new Random().Next(1, 5);
            switch (x)
            {
                case 1:
                    this.action1.Text = "+";
                    break;
                case 2:
                    this.action1.Text = "-";
                    break;
                case 3:
                    this.action1.Text = "*";
                    break;
                case 4:
                    this.action1.Text = "/";
                    break;
            }
        }
    }
}
