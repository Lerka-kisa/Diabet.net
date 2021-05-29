using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для NewFoodAdmin.xaml
    /// </summary>
    public partial class NewFoodAdmin : Window
    {
        NewFoodViewModel n;
        public NewFoodAdmin(MainPageViewModel obj)
        {
            n = new NewFoodViewModel(obj,2);
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
