using Plan4Food.Models;
using Plan4Food.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Plan4Food.Views
{
    /// <summary>
    /// Логика взаимодействия для AllProductAdminPage.xaml
    /// </summary>
    public partial class AllProductAdminPage : Page
    {
        AllProductAdminViewModel a;
        public AllProductAdminPage(ObservableCollection<Ingredients> ingredients)
        {
            a = new AllProductAdminViewModel(ingredients);
            InitializeComponent();
            DataContext = a;
        }
    }
}
