using GarryBoats.Models;
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
            var model = new RepairListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}