using Diabet.net.Models;
using Diabet.net.View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для NewFood.xaml
    /// </summary>
    public partial class NewFood : Window
    {
        NewFoodViewModel n;
        public NewFood(MainPageViewModel obj)
        {
            n = new NewFoodViewModel(obj);
            InitializeComponent();
            DataContext = n;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+|^[,]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
