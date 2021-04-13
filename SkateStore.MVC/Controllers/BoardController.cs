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
        public class BoardController : Controller
        {
            
            public ActionResult Index()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new BoardService(userId);
                var model = service.GetBoards();

                return View(model);
            }

            public ActionResult Create()
            {
                return View();
            }

            [System.Web.Http.HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(BoardCreate model)
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateBoardService();

                if (service.CreateBoard(model))
                {
                    TempData["SaveResult"] = "Your board was posted.";
                    return RedirectToAction("Index");
                };

                ModelState.AddModelError("", "Board could not be posted.");

                return View(model);
            }

            private BoardService CreateBoardService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new BoardService(userId);
                return service;
            }

            public ActionResult Details(int id)
            {
                var svc = CreateBoardService();
                var model = svc.GetBoardById(id);

                return View(model);
            }

            public ActionResult Edit(int id)
            {
                var service = CreateBoardService();
                var detail = service.GetBoardById(id);
                var model =
                    new BoardEdit
                    {
                        BoardId = detail.BoardId,
                        Name = detail.Name,
                        Description = detail.Description
                    };
                return View(model);
            }

            [System.Web.Http.HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, BoardEdit model)
            {
                if (!ModelState.IsValid) return View(model);

                if (model.BoardId != id)
                {
                    ModelState.AddModelError("", "Id Mismatch");
                    return View(model);
                }

                var service = CreateBoardService();

                if (service.UpdateBoard(model))
                {
                    TempData["SaveResult"] = "Your Board was updated.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Your Board could not be updated.");
                return View(model);
            }

            [System.Web.Http.ActionName("Delete")]
            public ActionResult Delete(int id)
            {
                var svc = CreateBoardService();
                var model = svc.GetBoardById(id);

                return View(model);
            }

            [System.Web.Http.HttpPost]
            [System.Web.Http.ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteBoard(int id)
            {
                var service = CreateBoardService();

                service.DeleteBoard(id);

                TempData["SaveResult"] = "Your board was deleted";

                return RedirectToAction("Index");
            }
        }
}
