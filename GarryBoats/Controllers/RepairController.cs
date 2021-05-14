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
            if (!ModelState.IsValid) return View(model);
            
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
                    RepairDescription = detail.RepairDescription,
                    RepairDetails = detail.RepairDetails,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RepairEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.RepairId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);

            }
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