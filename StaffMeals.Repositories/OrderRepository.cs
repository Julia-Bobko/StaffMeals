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
    public class OrderRepository
    {
        private string ConnectionString = "Data Source=(local);Initial Catalog=staffmeals;Integrated Security=True";

        //        public static IEnumerable<Order> GetOrders(string fio, DateTime date)
        //        {
        //            using (var conn = new SqlConnection(ConnectionString))
        //            {
        //                 var products = conn.Query<Order>(@"select fio, from order O
        //                INNER JOIN client C where O.idclient=@idclient and C.idclient=@idclient
        //                INNER JOIN ", new { date,client.IdClient });
        //                return products;
        //            }
        //        }

        public bool CreateOrder(Order order)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("insert into orders(idclient,idmenu) values(@IdClient, @IdMenu)", new { @IdClient = order.IdClient, @IdMenu = order.IdMenu });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IEnumerable<FullMenu> GetOrder(int idClient, DateTime date)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //var fullMenu = conn.Query<FullMenu>("SELECT M.idmenu,M.date,P.title,P.price,P.idproduct from menu M,product P,orders O where date=@date and P.idproduct=M.idproduct and O.idclient=@idClient", new { date, idClient });
                var fullMenu = conn.Query<FullMenu>("SELECT M.idmenu,M.date,P.title,P.price,P.idproduct from orders O left join menu M ON M.idmenu=O.idmenu  left join product P  ON P.idproduct=M.idproduct where O.idclient=@idClient and M.date=@date", new { date, idClient });
                return fullMenu;
            }
        }

        public bool UpdateMenu(FullMenu menu)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("UPDATE menu SET idproduct=@idproduct, date=@date WHERE idmenu=@idmenu", new { menu.IdProduct, menu.Date });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteOrder(int idClient, int idMenu)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("DELETE from orders WHERE  idclient=@idClient and idmenu=@idMenu", new { idClient, idMenu });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public int GetOrderPrice(int idClient,DateTime date)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int price = conn.Query<int>("SELECT SUM(P.price) from orders O inner join menu M ON M.date=@date and M.idmenu=O.idmenu inner join product P ON P.idproduct=M.idproduct WHERE O.idclient=@idClient", new { idClient, date }).FirstOrDefault();
                    return price;
                }
                catch
                {
                    return -1;
                }
            }
        }
    }
}
