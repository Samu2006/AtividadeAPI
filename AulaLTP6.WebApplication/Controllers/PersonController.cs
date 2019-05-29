using AulaLTP6.Domain.Entities;
using AulaLTP6.WebApplication.Services.APIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaLTP6.WebApplication.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonService _service;

        public PersonController(PersonService service)
        {
            _service = service;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View(_service.List("Person"));
        }

        public ActionResult Details(int id)
        {
            return View(_service.Get($"Person/{id}"));
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            var response = _service.Post("Person", person);
            if (response == true)
                return RedirectToAction("Index", _service.List("Person"));
            return View("Create", person);
        }

        public ActionResult Edit(int id)
        {
            return View(_service.Get($"Person/{id}"));
        }
        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            var response = _service.Put($"Person/{id}", person);
            if (response == true)
                return RedirectToAction("Index", _service.List("Person"));
            return View("Edit", person);
        }
        public ActionResult Delete(int id)
        {
            return View(_service.Get($"Person/{id}"));
        }
        [HttpPost]
        public ActionResult ConfirmeDelete(int id)
        {
            var response = _service.Delete($"Person/{id}");
            return RedirectToAction("Index", _service.List("Person"));
        }

    }
}