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
            var model = service.GetRepairPersons();

            return View(model);
        }
        //GET METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairPersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRepairPersonsService();

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
            var svc = CreateRepairPersonsService();
            var model = svc.GetRepairPersonById(id);

            return View(model);
        }


        private RepairPersonService CreateRepairPersonsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairPersonService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepairPersonsService();
            var detail = service.GetRepairPersonById(id);
            var model =
                new RepairPersonEdit
                {
                    RepairPersonName = detail.RepairPersonName,
                    RepairPersonLocation = detail.RepairPersonLocation
                };
            return View(model);
        }
    }
}