using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для UpdateSugarxaml.xaml
    /// </summary>
    public partial class UpdateSugar : Window
    {
            Update u;
            public UpdateSugar(MainPageViewModel obj)
            {
                u = new Update(obj);
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