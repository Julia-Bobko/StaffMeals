using Kendo.Mvc.UI;
using StaffMeals.Entities;
using StaffMeals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Kendo.Mvc.Extensions;
namespace StaffMeals.WebMvc.Controllers
{
    public class MealsController : Controller
    {
        ClientRepository clientRepository;
        ProductRepository productRepository;
        MenuRepository menuRepository;
        OrderRepository orderRepository;

        public MealsController()
        {
            clientRepository = new ClientRepository();
            productRepository = new ProductRepository();
            menuRepository = new MenuRepository();
            orderRepository = new OrderRepository();
        }

        public ActionResult Index()
        {
            DateTime date = DateTime.Now.Date;           
            var menu1 = menuRepository.GetMenu(date, 1);
            ViewBag.Menu1 = menu1;
            var menu2 = menuRepository.GetMenu(date, 2);
            ViewBag.Menu2 = menu2;
            var menu3 = menuRepository.GetMenu(date, 3);
            ViewBag.Menu3 = menu3;
            var menu4 = menuRepository.GetMenu(date, 4);
            ViewBag.Menu4 = menu4;
            return View();
        }

        public ActionResult OrderRead([DataSourceRequest]DataSourceRequest request)
        {
            DateTime date = DateTime.Now.Date;   
            IQueryable<FullMenu> fullMenu = orderRepository.GetOrder((int)Session["IdClient"], date).AsQueryable();
            //var fullMenu = orderRepository.GetOrder((int)Session["IdClient"], DateTime.Now.Date.Date);
            // Flatten the Category to avoid circular references during JSON serialization
            DataSourceResult result = fullMenu.ToDataSourceResult(request, m => new
                {
                    m.Title,
                    m.Price,
                    m.IdMenu
                });
            return Json(result);
        }

        public ActionResult ProductsRead([DataSourceRequest]DataSourceRequest request)
        {
            DateTime date = DateTime.Now.Date;   
            var fullProducts = productRepository.GetProductsCategory();          
            DataSourceResult result = fullProducts.ToDataSourceResult(request, m => new
            {
                m.Category,
                m.Price,
                m.Title,
                m.IdProduct
            });
            return Json(result);
        }

        public ActionResult AddProductToMenu(int idProduct)
        {
            var fullMenu = new FullMenu
            {
                Date =  DateTime.Now.Date.Date,
                IdProduct = idProduct 
            };
            var result = menuRepository.CreateMenu(fullMenu);
            return Json(result ? 1 : 0);
        }

        public ActionResult EditingMenu()
        {
            return View();
        }

        public ActionResult MenuRead([DataSourceRequest]DataSourceRequest request)
        {
            DateTime date = DateTime.Now.Date.Date;
            var fullMenu = menuRepository.GetMenu(date);
            DataSourceResult result = fullMenu.ToDataSourceResult(request, m => new
            {
               m.Title,
               m.Price,
               m.IdProduct,
               m.IdMenu,
               m.Date
            });
            return Json(result);
        }

        public ActionResult DeleteProductFromMenu(int idMenu)
        {
            var result = menuRepository.DeleteMenu(idMenu);
            return Json(result ? 1 : 0);
        }

        public ActionResult GetOrderPrice()
        {
            var clientId = (int)Session["IdClient"];
            DateTime date = DateTime.Now.Date;   
            var price = orderRepository.GetOrderPrice(clientId,date);
            return Json(price);
        }

        public ActionResult ShowMenu()
        {
            return View();
        }
    }
}
