using Dialectico.Data;
using Dialectico.Models;
using Dialectico.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dialectico.MVC.Controllers
{
    public class RootController : Controller
    {
       
        // GET: Root
        public ActionResult Index()
        {
            
            var service = new RootService();
            var model = service.GetRoots();
            return View(model);
        }
        //Get create
        public ActionResult Create()
        {
            return View();
        }
        //Post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RootCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new RootService();

            service.CreateRoot(model);

            return RedirectToAction("Index");
        }
    }
}