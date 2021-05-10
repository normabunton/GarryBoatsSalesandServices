using GarryBoats.Models;
using GarryBoats.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarryBoats.Controllers
{
    [Authorize]
    public class RepairPersonController : Controller
    {
        // GET: RepairPerson
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairPersonService(userId);
            var model = service.GetRepairPerson();

            return View(model);
        }
        //GET METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairPersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRepairPersonService();

            if (service.CreateRepairPerson(model))
            {
                TempData["SaveResult"] = "Your Repair Person was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Repair Person could not be created");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRepairPersonService();
            var model = svc.GetRepairPersonById(id);

            return View(model);
        }


        private RepairPersonService CreateRepairPersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairPersonService(userId);
            return service;
        }


    }
}