using Diabet.net.Models;
using Diabet.net.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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