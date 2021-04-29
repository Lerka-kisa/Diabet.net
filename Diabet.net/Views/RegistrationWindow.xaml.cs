﻿using Diabet.net.View_Models;
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
    /// Логика взаимодействия для RegistrView.xaml
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
        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+|^[,]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

    }
}
