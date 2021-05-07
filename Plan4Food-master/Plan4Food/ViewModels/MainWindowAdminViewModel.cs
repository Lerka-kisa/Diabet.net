using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Models;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
    class MainWindowAdminViewModel : ViewModelBase
    {
        private Page Main;
        private Page Approve;
        private Page AllProduct;
        private Page AllRecipe;
        private Page AddRecipe;

        public MainWindowAdminViewModel()
        {
            Main = new MainAdminPage();
            Approve = new ApproveProductAdminPage();
            AllProduct = new AllProductAdminPage(new ObservableCollection<Ingredients>());
            AllRecipe = new AllRecipeAdminPage();
            AddRecipe = new AddRicepiAdminPage();

            CurrentPage = Main;
        }
        public ICommand logout => new DelegateCommand(Logout);

        private void Logout()
        {

            AuthView _win = new AuthView();
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();
            Close();
        }


        public void Close()
        {
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                }
            }
        }
        private Page currentpage;
        public Page CurrentPage
        {
            get
            {
                return currentpage;
            }
            set
            {
                this.currentpage = value;
                RaisePropertiesChanged(nameof(CurrentPage));
            }
        }

        public ICommand open_Approve => new DelegateCommand(Open_Approve);

        private void Open_Approve()
        {
            Approve = new ApproveProductAdminPage();

            CurrentPage = Approve;
        }

        public ICommand open_AllProduct => new DelegateCommand(Open_AllProduct);

        private void Open_AllProduct()
        {
            AllProduct = new AllProductAdminPage(new ObservableCollection<Ingredients>());
            CurrentPage = AllProduct;
        }

        public ICommand open_AllRecipe => new DelegateCommand(Open_AllRecipe);

        private void Open_AllRecipe()
        {
            AllRecipe = new AllRecipeAdminPage();
            CurrentPage = AllRecipe;
        }

        public ICommand open_AddRecipe => new DelegateCommand(Open_AddRecipe);

        private void Open_AddRecipe()
        {

            CurrentPage = AddRecipe;
        }



    }
}
