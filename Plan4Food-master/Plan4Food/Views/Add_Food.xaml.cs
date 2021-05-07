using Plan4Food.ViewModels;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Plan4Food.Models;
using System.Text.RegularExpressions;

namespace Plan4Food.Views
{
    /// <summary>
    /// Логика взаимодействия для New_Food.xaml
    /// </summary>
    public partial class Add_Food : Window
    {
        AddFoodViewModel a;
        public Add_Food(  MainPageViewModel obj)
        {
            a = new AddFoodViewModel(  obj);
           
            InitializeComponent();
            DataContext = a;

            
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
