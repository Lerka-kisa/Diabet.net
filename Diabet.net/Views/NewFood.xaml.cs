using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

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
            n = new NewFoodViewModel(obj,1);
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
    }
}
