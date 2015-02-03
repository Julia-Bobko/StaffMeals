using StaffMeals.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace StaffMeals.Repositories
{
    public class CategoryRepository
    {
        private string ConnectionString = "Data Source=(local);Initial Catalog=staffmeals;Integrated Security=True";

        public Category GetCategory(int idCategory)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var category = conn.Query<Category>("SELECT * FROM category where  idcategory = @idCategory", new { idCategory }).FirstOrDefault();
                return category;
            }
        }
    }
}
