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


    }
}