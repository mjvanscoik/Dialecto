using Dialectico.Models;
using Dialectico.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dialectico.MVC.Controllers
{
    public class WordController : Controller
    {
        // GET: Word
        public ActionResult Index()
        {
            var service = new WordService();
            var model = service.GetWords();
            return View(model);
        }

        //Get Create
        public ActionResult Create()
        {
            return View();
        }
        //Post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WordCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.RootName is null)
            { return View(model); }

            var service = new WordService();
            bool isRootChecked = service.RootIsNotInDb(model);
            if (isRootChecked == false)
            {
                service.CreateWord(model);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "The root you are trying to add does not seem to be in the database. Please enter the root seperately and return to add the word here.");
                return View(model);
            }

        }
        public ActionResult Edit(int id)
        {
            var service = new WordService();
            var detail = service.GetWordById(id);
            var model =
                new WordListItem
                {
                    WordId = detail.WordId,
                    WordName = detail.WordName,
                    RootName = detail.RootName,
                    RootId = detail.RootId,
                };
            return View(model);
        }
        //Get Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WordListItem model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WordId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new WordService();

            if (service.UpdateWord(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = new WordService();
            var model = service.GetWordById(id);
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
            var service = new WordService();

            service.DeleteWord(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}
//