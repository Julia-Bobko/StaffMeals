using Kendo.Mvc.UI;
using StaffMeals.Entities;
using StaffMeals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
namespace StaffMeals.WebMvc.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        AdminRepository adminRepository;

        public AdminController()
        { 
            adminRepository = new AdminRepository(); 
        }

        public ActionResult WorkMenu()
        {
            return View();
        }

        public ActionResult CountOrder()
        {
            return View();
        }

        public ActionResult CountOrderRead([DataSourceRequest]DataSourceRequest request)
        {
            DateTime date = DateTime.Now.Date;   
            IQueryable<DataOrders> dataOrders =adminRepository.GetCountOrders(date).AsQueryable();
            //var fullMenu = orderRepository.GetOrder((int)Session["IdClient"], DateTime.Now.Date.Date);
            // Flatten the Category to avoid circular references during JSON serialization
            DataSourceResult result = dataOrders.ToDataSourceResult(request, m => new
            {
               m.Title,
               m.CountOrder
            });
            return Json(result);
        }

    }
}
