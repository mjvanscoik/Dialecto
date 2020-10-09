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
            bool isRootInDb = service.RootIsInDb(model);
            if (isRootInDb == true)
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
                    WordName = detail.WordName,
                    RootName = detail.RootName,
                    Notes = detail.Notes
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

        public ActionResult CreateMeaning(int id)
        {
            var service = new WordService();
            var word = service.GetWordById(id);
            var meaning = new MeaningCreate
            {
                WordName = word.WordName,
            };
            return View(meaning);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMeaning(int id, MeaningCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            //if(is null)
            // { return View(model); }

            var serviceMeaning = new MeaningService();
            var serviceWord = new WordService();
            var word = serviceWord.GetWordById(id);

            //Need to add new meanings to the meaninglist propery in word.

            serviceMeaning.CreateMeaning(word, model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = new WordService();
            var model = svc.GetWordById(id);


            return View(model);
        }
        public ActionResult MeaningIndex(int id)
        {
            var service = new MeaningService();
            var model = service.GetMeaningsById(id);
            return View(model);
        }

        public ActionResult EditMeaning(int id)
        {
            var service = new MeaningService();
            var oldMeaning = service.GetMeaningById(id);
            return View(oldMeaning);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMeaning(MeaningListItem oldMeaning)
        {
            var service = new MeaningService();
            var update = service.UpdateMeaning(oldMeaning);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMeaning(int id)
        {
            var service = new MeaningService();
            var meaningToDelete = service.GetMeaningById(id);
            return View(meaningToDelete);
        }

        [HttpPost]
        [ActionName("DeleteMeaning")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeaningWId(int id)
        {
            var service = new MeaningService();
            service.DeleteMeaning(id);
            return RedirectToAction("Index");

        }

        //////------RATING
        public ActionResult DisplayComments(int id)
        {
            var service = new MeaningService();
            var model = service.GetMeaningById(id);
            return View(model);
        }

        public ActionResult CreateRating(int id)
        {
            var service = new MeaningService();
            var model = service.GetMeaningById(id);
            var rating = new RatingCreate()
            {
                MeaningId = model.MeaningId,
            };
            return View(rating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRating(int id, RatingCreate ratingModel)
        {
            var serviceRating = new RatingService();
            var serviceMeaning = new MeaningService();
            var meaning = serviceMeaning.GetMeaningById(id);

            serviceRating.CreateRating(id, ratingModel);

            return RedirectToAction("DisplayComments", "Word", new { id = meaning.MeaningId });
        }

        public ActionResult EditRating(int id)
        {
            var service = new RatingService();
            var oldRating = service.GetRatingById(id);
            return View(oldRating);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRating(RatingListItem oldRating)
        {
            var service = new RatingService();
            service.UpdateRating(oldRating);

           

            return RedirectToAction("DisplayComments", "Word", new { id = oldRating.MeaningId });
        }
    }
}
//