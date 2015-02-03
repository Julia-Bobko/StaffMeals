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
    public class MenuRepository
    {
        private string ConnectionString = "Data Source=(local);Initial Catalog=staffmeals;Integrated Security=True";

        ProductRepository productRepository;

        public MenuRepository()
        {
            productRepository = new ProductRepository();
        }

        //public IEnumerable<FullMenu> GetMenu(DateTime date)
        //{
        //    var fullMenus = new List<FullMenu>();
        //    using (var conn = new SqlConnection(ConnectionString))
        //    {
        //        var menu = conn.Query<Menu>("select * from menu date=@date", new { date });
        //        foreach (var item in menu)
        //        {
        //            var product = productRepository.GetProduct(item.IdProduct);
        //            var fullMenu = new FullMenu
        //            {
        //                Date = item.Date,
        //                IdMenu = item.IdMenu,
        //                Product = product
        //            };
        //            fullMenus.Add(fullMenu);
        //        }
        //        return fullMenus;
        //    }
        //}

        public IEnumerable<FullMenu> GetMenu(DateTime date, int idCategory)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var menu = conn.Query<FullMenu>("select M.idmenu,M.date,P.title,P.price,P.idproduct from menu M,product P where date=@date and P.idproduct=M.idproduct and P.idcategory = @idCategory", new { date, idCategory });
                return menu;
            }
        }

        public IEnumerable<FullMenu> GetMenu(DateTime date)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var menu = conn.Query<FullMenu>("select M.idmenu,M.date,P.title,P.price,P.idproduct from menu M,product P where date=@date and P.idproduct=M.idproduct", new { date });
                return menu;
            }
        }

        public bool CreateMenu(FullMenu menu)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("insert into menu(idproduct,date) values (@IdProduct,@Date)", new { menu.IdProduct, menu.Date });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
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

        public bool DeleteMenu(string date)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("DELETE from menu WHERE  date=@date", new { date });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteMenu(int idMenu)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("DELETE from menu WHERE  idmenu=@idMenu", new { idMenu });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
