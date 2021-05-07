using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using Plan4Food.DB;
using System.Collections.ObjectModel;
using Plan4Food.Models;
using Plan4Food.Views;
using System.Windows;
using System.Windows.Controls;

namespace Plan4Food.ViewModels
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
        public ICommand close => new DelegateCommand(Close);
        #region 
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

            AuthView _win = new AuthView();
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
        #endregion
        public ICommand open_Stat => new DelegateCommand(Open_Stat);

        private void Open_Stat()
        {
            Statictic = new StatisticsPage();
            CurrentPage = Statictic;
        }

    }
}
