using Diabet.net.View_Models;
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

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        AuthViewModel a = new AuthViewModel();
        public AuthorizationWindow()
        {
            InitializeComponent();
            DataContext = a;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            a.password = password_textbox.Password;
        }


    }
}
