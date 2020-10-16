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

namespace reostat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void R1_Click(object sender, RoutedEventArgs e)
        {
            if (r1.IsChecked == true) R1.IsEnabled = true;
            else R1.IsEnabled = false;
        }

        private void R2_Click(object sender, RoutedEventArgs e)
        {
            if (r2.IsChecked == true) R2.IsEnabled = true;
            else R2.IsEnabled = false;
        }

        private void R3_Click(object sender, RoutedEventArgs e)
        {
            if (r3.IsChecked == true) R3.IsEnabled = true;
            else R3.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            R1.IsEnabled = false;
            R2.IsEnabled = false;
            R3.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double R = 0;
            try
            {
                bool? v = posl.IsChecked;
                switch(v)
                {
                    case true:
                        {
                            if (R1.IsEnabled == true) R += double.Parse(R1.Text);
                            if (R2.IsEnabled == true) R += double.Parse(R2.Text);
                            if (R3.IsEnabled == true) R += double.Parse(R3.Text);
                        }
                        break;
                    case false: {
                            double RP = 0;
                            if (R1.IsEnabled == true) RP += 1/double.Parse(R1.Text);
                            if (R2.IsEnabled == true) RP += 1/double.Parse(R2.Text);
                            if (R3.IsEnabled == true) RP += 1/double.Parse(R3.Text);
                            R = 1 / RP;
                        }
                        break;
                }
                Result.Text = R.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
