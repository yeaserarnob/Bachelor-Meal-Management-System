using ManagementSystem.Models;
using ManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        Repository<User> repository = new Repository<Models.User>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpPost, ActionName("Index")]
        public ActionResult Validate(User user)
        {
            if(ModelState.IsValid)
            {
                user = repository.CheckValidLogin(user);
                if (user.IsValid)
                {
                    return RedirectToAction("Home", "Person", new { id = user.Id });
                }

                else return View("Index", user);
            }

            else return View("Index", user);
        }

        [HttpGet]
        public ActionResult AddLogin()
        {
            return View();
        }

        [HttpPost, ActionName("AddLogin")]
        public ActionResult AfterAddLogin(User user)
        {
            user.IsValid = true;
            repository.Save(user);
            return RedirectToAction("Index");
        }
    }
}