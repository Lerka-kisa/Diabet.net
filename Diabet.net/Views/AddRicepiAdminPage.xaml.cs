﻿using Diabet.net.View_Models;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diabet.net.Views
{
    /// <summary>
    /// Логика взаимодействия для AddRicepiAdminPage.xaml
    /// </summary>
    public partial class AddRicepiAdminPage : Page
    {
        AddRecipeAdminViewModel a;
        public AddRicepiAdminPage()
        {
            a = new AddRecipeAdminViewModel();
            InitializeComponent();
            DataContext = a;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+|^[,]+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
