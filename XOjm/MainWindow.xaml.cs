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

namespace XOjm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button[] buttons;
        public string XO = "X";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "b10")
            {
                Reset();
            }
            else
            {
                (sender as Button).Content = XO;
                (sender as Button).IsEnabled = false;
                if (Winner())
                {
                    return;
                }
                Robot();
            }

        }

        private void Robot()
        {
            Button[] buttons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            Random r = new Random();
            int pos;
            do
            {
                pos = r.Next(0, 9);
            } while (!(buttons[pos].Content == "" || buttons[pos].Content == null));
            if (XO == "X")
            {
                buttons[pos].Content = "O";
            }
            else
            {
                buttons[pos].Content = "X";
            }
            buttons[pos].IsEnabled = false;
            if (Winner())
            {
                return;
            }
        }

        private bool Winner()
        {
            buttons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            string[] lines = new string[]
            {
                b1.Content.ToString() + b2.Content.ToString() + b3.Content.ToString(),
                b4.Content.ToString() + b5.Content.ToString() + b6.Content.ToString(),
                b7.Content.ToString() + b8.Content.ToString() + b9.Content.ToString(),
                b1.Content.ToString() + b4.Content.ToString() + b7.Content.ToString(),
                b2.Content.ToString() + b5.Content.ToString() + b8.Content.ToString(),
                b3.Content.ToString() + b6.Content.ToString() + b9.Content.ToString(),
                b1.Content.ToString() + b5.Content.ToString() + b9.Content.ToString(),
                b3.Content.ToString() + b5.Content.ToString() + b7.Content.ToString()
            };

            foreach (var line in lines)
            {
                if (line == "XXX")
                {
                    MessageBox.Show("Крестик выйграл!");
                    Reset();
                    return true;
                }
                else if (line == "OOO")
                {
                    MessageBox.Show("Нолик выйграл!");
                    Reset();
                    return true;
                }
            }
            if (!buttons.Any(b => b.Content == "" || b.Content == null))
            {
                MessageBox.Show("Ничья");
                Reset();
                return true;
            }
            return false;
        }

        private void Reset()
        {
            foreach(Button b in buttons)
            {
                b.Content = "";
                b.IsEnabled = true;
            }
            Change();

        }
        private void Change()
        {
            if (XO == "X")
            {
                XO = "O";
                You.Content = "Вы: " + XO;

            }
            else
            {
                XO = "X";
                You.Content = "Вы: " + XO;
            }
        }
    }
}