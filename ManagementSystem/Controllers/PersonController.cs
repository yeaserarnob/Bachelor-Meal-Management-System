using ManagementSystem.Models;
using ManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Controllers
{
    public class PersonController : Controller
    {
        Repository<Person> repository = new Repository<Person>();

        public ActionResult Index(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        
        public ActionResult CreateNewPerson(Person person)
        {
            if(ModelState.IsValid)
            {
                repository.Save(person);
            }
            return RedirectToAction("AddLogin", "Login");
        }
        
        public ActionResult Home(int id)
        {
            Person person = repository.Get(id);
            return View(person);
        }
    }
}