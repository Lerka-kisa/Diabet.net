using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateMass.xaml
    /// </summary>
    public partial class UpdateMass : Window
    {
        Update u;
        public UpdateMass(UserPageViewModel users)
        {
            u = new Update(users);
            InitializeComponent();
            DataContext = u;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+|^[,]+");
            e.Handled = !regex.IsMatch(e.Text);
        }


    }
}
