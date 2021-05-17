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

        public ActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairPersonCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateRepairPersonsService();

            if (service.CreateRepairPerson(model))
            {
                TempData["SaveResult"] = "Your Repair Person was created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Repair Person could not be created");
            //service.CreateRepairPerson(model);

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateRepairPersonsService();
            var model = svc.GetRepairPersonById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepairPersonsService();
            var detail = service.GetRepairPersonById(id);
            var model =
                new RepairPersonEdit
                {
                    RepairPersonId = detail.RepairPersonID,
                    RepairPersonName = detail.RepairPersonName,
                    RepairPersonLocation = detail.RepairPersonLocation
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (RepairPersonEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateRepairPersonsService();
            if (service.UpdateRepairPerson(model))
            {
                TempData["SaveResult"] = "Your RepairPerson was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your RepairPerson could not be updated");
            return View();
        }
              
        private RepairPersonService CreateRepairPersonsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairPersonService(userId);
            return service;
        }

        [ActionName ("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRepairPersonsService();
            var model = svc.GetRepairPersonById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRepairPersonPost(int id)
        {
            var service = CreateRepairPersonsService();
            service.DeleteRepairPerson(id);
            TempData["Save Result"] = "Your Repair Person Was Deleted";
            return RedirectToRoute("Index");
        }
    }
}