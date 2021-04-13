using Microsoft.AspNet.Identity;
using SkateStore.Models;
using SkateStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SkateStore.MVC.Controllers
{
    [System.Web.Http.Authorize]
    public class RatingController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRatings();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRatingService();

            if (service.CreateRating(model))
            {
                TempData["SaveResult"] = "Your rating was posted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "rating could not be posted.");

            return View(model);
        }

        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    
                };
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Your rating was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your rating could not be updated.");
            return View(model);
        }

        [System.Web.Http.ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRatingService();

            service.DeleteRating(id);

            TempData["SaveResult"] = "Your rating was deleted";

            return RedirectToAction("Index");
        }
    }
}
