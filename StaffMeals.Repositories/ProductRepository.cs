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
    public class ProductRepository
    {
        private string ConnectionString = "Data Source=(local);Initial Catalog=staffmeals;Integrated Security=True";
        private CategoryRepository categoryRepository;

        public ProductRepository()
        {
            categoryRepository = new CategoryRepository();
        }
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var products = conn.Query<Product>("select * from product");
                return products;
            }
        }

        public IEnumerable<FullProduct> GetProductsCategory()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var fullproducts = new List<FullProduct>();
                var products = GetProducts();
                foreach (var item in products)
                {
                    var category = categoryRepository.GetCategory(item.IdCategory);
                    var fullproduct = new FullProduct
                    {
                        Title = item.Title,
                        Price = item.Price,
                        Category = category,
                        IdProduct = item.IdProduct
                    };
                    fullproducts.Add(fullproduct);
                }
                return fullproducts;
            }
        }

        public IEnumerable<Product> GetProducts(int idCategory)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var products = conn.Query<Product>("select * from product where idcategory=@idCategory", new { idCategory });
                return products;
            }
        }

        public Product GetProduct(int idProduct)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var product = conn.Query<Product>("select * from product where idproduct=@idProduct", new { idProduct }).FirstOrDefault();
                return product;
            }
        }

        public bool CreateProduct(Product product)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("insert into product(idcategory,title,price) values (@idcategory,@title,@price)", new { product.IdCategory, product.Title, product.Price });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("UPDATE product SET idcategory=@idcategory, title=@title, price=@price WHERE idproduct=@idproduct  ", new { product.IdCategory, product.Title, product.Price, product.IdProduct });
                    return result != -1 ? true : false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteProduct(string title)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    int result = conn.Execute("DELETE product WHERE  title=@title", new { title });
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
