﻿using Diabet.net.View_Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
