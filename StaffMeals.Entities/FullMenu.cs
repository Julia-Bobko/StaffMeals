using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMeals.Entities
{
    public class FullMenu
    {
        public int IdMenu { get; set; }
        public DateTime Date { get; set; }
        //public Product Product { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int IdProduct { get; set; }
    }
}
