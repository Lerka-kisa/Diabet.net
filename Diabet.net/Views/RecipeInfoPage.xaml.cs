using Diabet.net.Models;
using Diabet.net.View_Models;
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
