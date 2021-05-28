using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        RegistrViewModel reg = new RegistrViewModel();
        public RegistrationWindow()
        {
            InitializeComponent();
            DataContext = reg;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            reg.password = password_textbox.Password;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
