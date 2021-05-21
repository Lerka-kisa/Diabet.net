using Diabet.net.Models;
using Diabet.net.View_Models;
using System.Windows.Controls;


namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipeInfoPage.xaml
    /// </summary>
    public partial class RecipeInfoPage : Page
    {
        RecipeInfoViewModel r;
        public RecipeInfoPage(Product obj, RecipePageViewModel obj2)
        {
            r = new RecipeInfoViewModel(obj, obj2);
            InitializeComponent();
            DataContext = r;
        }
    }
}
