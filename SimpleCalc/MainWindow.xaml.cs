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
using MahApps.Metro.Controls;

namespace SimpleCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        double var1, var2;
        private string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text == "0" && ((Button)sender).Tag.ToString() != ".")
            {
                Display.Clear();
            }
            Display.Text += ((Button)sender).Tag.ToString();
        }

        private void ChangeAppTheme_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            if (Properties.Settings.Default.appTheme == true)
            {
                dictionary.Source = new Uri("pack://application:,,,/Resources/Controls/Light.xaml", UriKind.RelativeOrAbsolute);
            }
            else
            {
                dictionary.Source = new Uri("pack://application:,,,/Resources/Controls/Dark.xaml", UriKind.RelativeOrAbsolute);
            }
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            Properties.Settings.Default.appTheme = !Properties.Settings.Default.appTheme;
            Properties.Settings.Default.Save();
        }
        
        private void Operations(object sender, RoutedEventArgs e)
        {
            var1 = double.Parse(Display.Text);
            Display.Clear();
            operation = ((Button)sender).Tag.ToString();
            if (operation == "pow")
            {
                EqualBtn_Click(sender, e);
            }
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "plus":
                    {
                        var2 = var1 + double.Parse(Display.Text);
                        break;
                    }
                case "minus":
                    {
                        var2 = var1 - double.Parse(Display.Text);
                        break;
                    }
                case "multiply":
                    {
                        var2 = var1 * double.Parse(Display.Text);
                        break;
                    }
                case "divide":
                    {
                        var2 = var1 / double.Parse(Display.Text);
                        break;
                    }
                case "pow":
                    {
                        var2 = Math.Pow(var1, 2);
                        break;
                    }
                default:
                    {
                        Display.Text = "Error";
                        break;
                    }
            }
            Display.Text = var2.ToString();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Clear();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length - 1);
        }
    }
}
