using Diabet.net.Models;
using Diabet.net.View_Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Diabet.net.Views
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
