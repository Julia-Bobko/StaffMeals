using StaffMeals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffMeals.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        MenuRepository menuRepository;

        public HomeController()
        {
            menuRepository = new MenuRepository();
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

        public ActionResult MenuView()
        {
           
       
            return View();
        }

    }
}
