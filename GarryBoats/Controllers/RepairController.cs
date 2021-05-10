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

        private RepairService CreateRepairService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RepairService(userId);
            return service;
        }
    }
}