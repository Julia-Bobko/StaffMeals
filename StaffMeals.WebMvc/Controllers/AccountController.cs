using StaffMeals.Entities;
using StaffMeals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffMeals.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        AccountRepository accountRepository;
        AdminRepository adminRepository;

        public AccountController()
        {
            accountRepository = new AccountRepository();
            adminRepository = new AdminRepository();
        }

        public ActionResult RegisterIndex()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Register(Client client)
        {
            if (!accountRepository.Register(client))
            {
                Session["Register"] = "Пользователь с таким логином уже существует";
                return RedirectToAction("RegisterIndex", "Account");
            }
            return RedirectToAction("WorkMenu", "Admin");
        }

        public ActionResult AuthorizeIndex(Client client)
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Authorize(Client client)
        {
            if (adminRepository.Authorize(client.Login, client.Password) != null)
            {
                return RedirectToAction("WorkMenu", "Admin");
            }
            var authorizedClient = accountRepository.Authorize(client.Login, client.Password);
            if (authorizedClient == null)
            {
                Session["IsAuthorized"] = "Проверьте логин или пароль";
                return RedirectToAction("AuthorizeIndex", "Account");
            }
            Session["IdClient"] = authorizedClient.IdClient;
            return RedirectToAction("Index", "Meals");
        }
    }
}
