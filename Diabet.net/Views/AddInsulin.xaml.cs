using System.Text.RegularExpressions;
using Diabet.net.View_Models;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AddInsulin.xaml
    /// </summary>
    public partial class AddInsulin : Window
    {
        AddInsulinViewModel n;
        public AddInsulin(MainPageViewModel obj, int type)
        {
            n = new AddInsulinViewModel(obj,type);
            InitializeComponent();
            DataContext = n;
        }
        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
