using GarryBoats.Data;
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
    public class RepairController : Controller
    {
        // GET: Repair
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairService(userId);
            var model = service.GetRepairs();

            return View(model);
        }

        //GET method : we are making a request to get the create view
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairCreate model)
        {
            if (!ModelState.IsValid) 
                
                return View(model);
            
                var service = CreateRepairService();

                if (service.CreateRepair(model))
                {
                TempData["SaveResult"] = "Your Repair was created";
                return RedirectToAction("Index");
                };
            ModelState.AddModelError("", "Repair could not be created");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRepairService();
            var model = svc.GetRepairById(id);
           
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRepairService();
            var detail = service.GetRepairById(id);
            var model =
                new RepairEdit
                {
                    RepairId = detail.RepairID,
                    RepairDescription = detail.RepairDescription,
                    RepairDetails = detail.RepairDetails,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepairEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateRepairService();
            if (service.UpdateRepair(model))
            {
                TempData["SaveResult"] = "Your Repair was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your repair could not be updated");
            return View();
        }
        private RepairService CreateRepairService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRepairService();
            var model = svc.GetRepairById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRepairService();
            service.DeleteRepair(id);
            TempData["Save Result"] = "Your Repair Was Deleted";
            return RedirectToRoute("Index");
        }
    }
}