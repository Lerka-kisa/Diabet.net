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

namespace Plan4Food.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdatePurpose.xaml
    /// </summary>
    public partial class UpdatePurpose : Window
    {
        Update u;
        public UpdatePurpose(UserPageViewModel users)
        {
            u = new Update(users);
            InitializeComponent();
            DataContext = u;

        }
    }
}
