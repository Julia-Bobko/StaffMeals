using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMeals.Entities
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public DateTime Date { get; set; }
        public int IdProduct { get; set; }
    }
}
