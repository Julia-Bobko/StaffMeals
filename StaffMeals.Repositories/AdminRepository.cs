using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using StaffMeals.Entities;
using StaffMeals.Helpers;
using System.Data.SqlClient;
namespace StaffMeals.Repositories
{
    public class AdminRepository
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["smdb"].ConnectionString;

        public Admin Authorize(string login, string password)
        {
            var passwordHash = Decripting.GetMD5Hash(password);
            var sql = @"SELECT * FROM admin WHERE login = @Login AND Password = @passwordHash";
            using (var conn = new SqlConnection(ConnectionString))
            {
                var admin = conn.Query<Admin>(sql, new { login, passwordHash }).FirstOrDefault();
                return admin;
            }
        }

        public IEnumerable<DataOrders> GetCountOrders(DateTime data)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var countOrders = conn.Query<DataOrders>(@"select title, COUNT(o.idmenu) as CountOrder from product P left join menu M ON M.idproduct=P.idproduct
                                                   left join orders O ON O.idmenu=M.idmenu where date=@data
                                                   group by title", new { data});
                return countOrders;
            }
        }


    }
}
