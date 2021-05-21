using Diabet.net.View_Models;
using System.Windows;

namespace Diabet.net.Views
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
