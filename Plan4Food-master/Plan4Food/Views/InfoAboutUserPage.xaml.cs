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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plan4Food.Views
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutUserPage.xaml
    /// </summary>
    public partial class InfoAboutUserPage : Page
    {
        UserPageViewModel u;
        public InfoAboutUserPage()
        {
            u = new UserPageViewModel();
            InitializeComponent();
            DataContext = u;
        }
    }
}
