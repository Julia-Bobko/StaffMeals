using StaffMeals.Entities;
using StaffMeals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffMeals.WebMvc.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        OrderRepository orderRepository;

        public OrderController()
        {
            orderRepository = new OrderRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(int idMenu)
        {
            var idClient = (int)Session["IdClient"];
            var order=new Order
            {
                IdMenu = idMenu,
                IdClient = idClient
            };
            var isOrderAdded = orderRepository.CreateOrder(order);
            return Json(isOrderAdded ? 1 : 0);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int idMenu)
        {
            var idClient = (int)Session["IdClient"]; 
            var isOrderAdded = orderRepository.DeleteOrder(idClient, idMenu);
            return Json(isOrderAdded ? 1 : 0);
        }
    }
}
