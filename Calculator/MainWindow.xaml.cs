using System;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement element in MainGrid.Children) /*нахождение кнопок среди элементов MainGrid и присвоение им метода Button_Click*/
            {
                if(element is Button)
                {
                    ((Button) element).Click += Button_Click; 
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = (string)((Button)e.OriginalSource).Content; //C помощью пространства имён System.Data определяем функцию кнопки

            if (text == "AC")
                calculator_text.Text = "";
            else if(text == "=")
            {
                try
                {
                    string result = new DataTable().Compute(calculator_text.Text, null).ToString(); //Результат
                    calculator_text.Text = result;
                }
                catch(System.Data.SyntaxErrorException) //Недопустимое значение result
                {
                    MessageBox.Show("Ошибка");
                    calculator_text.Text = "";
                }
                catch (System.Data.EvaluateException) //Невозможно найти свойство Expression класса DataColumn
                {
                    MessageBox.Show("Ошибка");
                    calculator_text.Text = "";
                }
            }
            else
                calculator_text.Text += text;
        }
    }
}
