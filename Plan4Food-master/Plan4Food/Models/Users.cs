using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan4Food.Models
{
    public class Users
    {
        public int Id_user { get; set; }
        public string Login { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public short Daily_Calories { get; set; }
        public short Age { get; set; }
        public string Gender { get; set; } //0-male, 1 - female
        public string Activity { get; set; }
        public string Purpose_of_Use { get; set; } //0-похудеть, 1 - держать вес, 2- набрать вес

      
    
    }
}

//public Users(int Id_user, string Login, string Password, string LastName, string FirstName, bool IsAdmin, float Heught, float Weight, float TheGoalsWeight,
//                    short Daily_Calories, DateTime Date_of_Birth, bool Gender, float Activity, short Purpose_of_Use)
      