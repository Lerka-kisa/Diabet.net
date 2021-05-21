using Diabet.net.View_Models;
using System.Windows.Controls;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для ApproveProductAdminPage.xaml
    /// </summary>
    public partial class ApproveProductAdminPage : Page
    {
        ApproveAdminViewModel a;
        public ApproveProductAdminPage()
        {
            a = new ApproveAdminViewModel();
            InitializeComponent();
            DataContext = a;
        }
    }
}
