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
    public class TransactionController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            var model = service.GetTransaction();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTransactionService();

            if (service.CreateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was posted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "transaction could not be posted.");

            return View(model);
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionById(id);
            var model =
                new TransactionEdit
                {

                };
            return View(model);
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransactionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["SaveResult"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your transaction could not be updated.");
            return View(model);
        }

        [System.Web.Http.ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "Your transaction was deleted";

            return RedirectToAction("Index");
        }
    }
}


