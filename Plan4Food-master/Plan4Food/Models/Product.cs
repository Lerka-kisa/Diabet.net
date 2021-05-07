using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan4Food.Models
{
   public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Calorific { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Carbs { get; set; }
        public string Description { get; set; }
    }
}
