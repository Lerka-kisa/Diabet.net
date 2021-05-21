using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AllRecipeAdminPage.xaml
    /// </summary>
    public partial class AllRecipeAdminPage : Page
    {
        AllRecipeAdminViewModel a;
        public AllRecipeAdminPage()
        {
            a = new AllRecipeAdminViewModel();
            InitializeComponent();
            DataContext = a;
        }
    }
}
