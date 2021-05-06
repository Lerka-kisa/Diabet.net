using Plan4Food.Models;
using Plan4Food.ViewModels;
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

namespace Plan4Food.Views
{
    /// <summary>D:\2 курс\курсовой_ооп\Plan4Food\Plan4Food\Models\
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
