using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMeals.Entities
{
   public  class Order
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public int IdMenu { get; set; }
    }
}
