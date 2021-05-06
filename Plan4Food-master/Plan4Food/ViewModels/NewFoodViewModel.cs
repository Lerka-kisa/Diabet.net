using DevExpress.Mvvm;
using Plan4Food.DB;
using Plan4Food.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Plan4Food.ViewModels
{
    public class NewFoodViewModel: ViewModelBase
    {
        MainPageViewModel Obj;
        DB_NewFood dB_NewFood = new DB_NewFood();
        public NewFoodViewModel(MainPageViewModel obj)
        {
            Obj = obj;
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

        public ICommand back => new DelegateCommand(Back);

        public void Back()
        {
            Add_Food win = new Add_Food(Obj);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            Close();
        }

        public ICommand clear => new DelegateCommand(Clear);

        public void Clear()
        {
            Name_Product = "";
            Cal_Product = "";
            Protein_Product = "";
            Fat_Product = "";
            Carb_Product = "";
        }

        public ICommand add => new DelegateCommand(Add);

        public void Add()
        {
            if (Name_Product == String.Empty || Name_Product == null || Cal_Product == String.Empty || Cal_Product == null || Protein_Product == String.Empty || Protein_Product == null
                                             || Fat_Product == String.Empty || Fat_Product == null || Carb_Product == String.Empty || Carb_Product == null)

                ErrorMes = Properties.Resources.emptyfield;

            else { 
                dB_NewFood.AddProductInApproval(Name_Product, Cal_Product, Protein_Product, Fat_Product, Carb_Product);
                Clear();
                ErrorMes = Properties.Resources.approve;
            }
        }


        private string name_product;
        public string Name_Product
        {
            get
            {
                return name_product;
            }
            set
            {
                this.name_product = value;
                RaisePropertiesChanged(nameof(Name_Product));
            }
        }

        private string cal_product;
        public string Cal_Product
        {
            get
            {
                return cal_product;
            }
            set
            {
                this.cal_product = value;
                RaisePropertiesChanged(nameof(Cal_Product));
            }
        }

        private string protein_product;
        public string Protein_Product
        {
            get
            {
                return protein_product;
            }
            set
            {
                this.protein_product = value;
                RaisePropertiesChanged(nameof(Protein_Product));
            }
        }

        private string fat_product;
        public string Fat_Product
        {
            get
            {
                return fat_product;
            }
            set
            {
                this.fat_product = value;
                RaisePropertiesChanged(nameof(Fat_Product));
            }
        }

        private string carb_product;
        public string Carb_Product
        {
            get
            {
                return carb_product;
            }
            set
            {
                this.carb_product = value;
                RaisePropertiesChanged(nameof(Carb_Product));
            }
        }

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

    }
}
