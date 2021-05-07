using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan4Food.Models
{
   public class Ingredients
    {
        public int ID_Recipe { get; set; }
        public int ID_Product { get; set; }
        public string Mass { get; set; }
        public string Name_Product { get; set; }
    }
}
