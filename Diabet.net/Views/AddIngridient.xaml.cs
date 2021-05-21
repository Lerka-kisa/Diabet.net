using Diabet.net.Models;
using Diabet.net.View_Models;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Windows;

namespace Diabet.net.Views
{
    /// <summary>D:\2 курс\курсовой_ооп\Diabet.net\Diabet.net\Models\
    /// Логика взаимодействия для AddIngridient.xaml
    /// </summary>
    public partial class AddIngridient : Window
    {
        AllProductAdminViewModel a;
        public AddIngridient(ObservableCollection<Ingredients> ingredients)
        {
            a = new AllProductAdminViewModel(ingredients);
            InitializeComponent();
            DataContext = a;
        }

        private void TextBox_PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
