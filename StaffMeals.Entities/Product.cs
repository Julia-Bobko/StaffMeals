using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMeals.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

    }
}
