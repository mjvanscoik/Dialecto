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
        public ActionResult Details(int id)
        {
            var service = new RootService();
            var model = service.GetRootById(id);
            return View(model);
        }
        //Get Delete
        public ActionResult Delete(int id)
        {
            var service = new RootService();
            var model = service.GetRootById(id);
            return View(model);
        }
        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var service = new RootService();

            service.DeleteRoot(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = new RootService();
            var detail = service.GetRootById(id);
            var model =
                new RootListItem
                {
                    Id = detail.Id,
                    RootName = detail.RootName,
                    NotesOnRoot = detail.NotesOnRoot
                };
            return View(model);
        }
        //Get Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RootListItem model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new RootService();

            if (service.UpdateRoot(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Measures(int id)
        {
            var service = new RootService();
            var model = service.GetRootById(id);
            IEnumerable<string> measures = service.GetMeasures(id);
            if(model.Measures == null)
            { model.Measures = measures; }

            return View(model);
        }
    }
   

}