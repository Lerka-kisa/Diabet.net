using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using Diabet.net.DB;
using System.Collections.ObjectModel;
using Diabet.net.Models;
using Diabet.net.Views;
using System.Windows;
using System.Windows.Controls;

namespace Diabet.net.View_Models
{
    public class MainViewModel : ViewModelBase
    {
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

        public ICommand close => new DelegateCommand(Close);
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

        public MainViewModel()
        {
            Main = new MainPage();
            UserInfo = new InfoAboutUserPage();
            Recipe = new RecipePage();
            Statictic = new StatisticsPage();

            CurrentPage = Main;
        }
        private Page Main;
        private Page UserInfo;
        private Page Recipe;
        private Page Statictic;

        public ICommand logout => new DelegateCommand(Logout);
        private void Logout()
        { 
            AuthorizationWindow _win = new AuthorizationWindow();
            _win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _win.Show();
            Close();
        }

        public ICommand open_Recipe => new DelegateCommand(Open_Recipe);
        private void Open_Recipe()
        {
            CurrentPage = Recipe;
        }

        public ICommand open_InfoUser => new DelegateCommand(Open_InfoUser);
        private void Open_InfoUser()
        {
            CurrentPage = UserInfo;
        }

        public ICommand open_Main => new DelegateCommand(Open_Main);
        private void Open_Main()
        {
            Page Main = new MainPage();
            CurrentPage = Main;
        }

        public ICommand open_Stat => new DelegateCommand(Open_Stat);
        private void Open_Stat()
        {
            Statictic = new StatisticsPage();
            CurrentPage = Statictic;
        }

    }
}
