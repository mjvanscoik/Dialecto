using Dialectico.Models;
using Dialectico.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dialectico.MVC.Controllers
{
    public class MeaningController : Controller
    {
        // GET: Meaning
        public ActionResult Index()
        {
            var service = new MeaningService();
            var model = service.GetAllMeanings();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeaningCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new MeaningService();
            //service.CreateMeaning(model);
            return RedirectToAction("index");
        }


        //Get Edit
        public ActionResult MeaningEdit(int id)
        {
            var service = new MeaningService();
            var detail = service.GetMeaningById(id);
            
            return View(detail);
        }
        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MeaningListItem model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MeaningId != id)
            {
                ModelState.AddModelError("", "Word is null");
                return View(model);
            }

            var service = new MeaningService();

            

            if (service.UpdateMeaning(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your meaning could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = new MeaningService();
            var model = service.GetMeaningById(id);
            return View(model);
        }
        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeaning(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var service = new MeaningService();

            service.DeleteMeaning(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

    }
}