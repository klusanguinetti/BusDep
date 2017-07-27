using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusDep.Web.Controllers
{
    public class EntitiesController : Controller
    {
        // GET: Entities
        public ActionResult Index()
        {
            return View();
        }

        // GET: Entities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entities/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
