using GarryBoats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarryBoats.Controllers
{
    public class ProductController : Controller
    {
        private ProductDbContext _db = new ProductDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}