using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMeals.Entities
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Fio { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
