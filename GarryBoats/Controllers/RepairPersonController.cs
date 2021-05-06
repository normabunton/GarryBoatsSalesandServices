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
            var model = new RepairPersonController[0];
            return View(model);
        }
        //GET METHOD
        public ActionResult Create()
        {
            return View();
        }

    }
}