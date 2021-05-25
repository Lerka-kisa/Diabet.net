using DevExpress.Mvvm;
using Diabet.net.DB;
using Diabet.net.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Diabet.net.View_Models
{
    class AuthViewModel : ViewModelBase
    {
        public string login { get; set; }

        public string password { get; set; }

        bool flag = false;

        bool canreg = true;

        public AuthViewModel()
        {

        }

        public ICommand registration => new DelegateCommand(Reg);
        public void Reg()
        {
            RegistrationWindow r = new RegistrationWindow();
            r.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            r.Show();
            Close();
        }

        public ICommand auth => new DelegateCommand(Auth);
        public void Auth()
        {
            bool fl = true;
            bool IsDone = true;
            ErrorMes = "";
            flag = true;
            login += " ";
            int x1 = login.Length - 1;
            login = login.Substring(0, x1);
            if (login == null || password == null || login == String.Empty)
                ErrorMes = Properties.Resources.emptyfield;
            else
            {
                if (fl && canreg)
                {
                    DataBaseUser spam = new DataBaseUser();
                    string Pass = DB.DB.Hash(password).ToString();
                    IsDone = spam.GiveUserByLoginAndPassword(login, Pass);
                    if (IsDone)
                    {
                        Properties.Settings.Default.User = login;
                        Properties.Settings.Default.IdUser = spam.GetIdUserByLogin(login);
                        Properties.Settings.Default.Save();
                        bool isAdmin;
                        isAdmin = spam.GetIsAdminUser(Properties.Settings.Default.IdUser);

                        if (isAdmin)
                        {
                            AdminWindow sp = new AdminWindow();
                            sp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            sp.Show();
                            Close();
                        }
                        else
                        {
                            MainWindow sp = new MainWindow();
                            sp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            sp.Show();
                            Close();
                        }

                    }
                }
                if (!IsDone)
                {
                    ErrorMes = Properties.Resources.nosuchuser;
                }

                flag = false;
                canreg = true;
            }
        }

        public string Error => throw new NotImplementedException();
        private string errorMes;
        public string ErrorMes
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                RaisePropertiesChanged(nameof(ErrorMes));
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
        public ICommand exit => new DelegateCommand(Exit);
        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
