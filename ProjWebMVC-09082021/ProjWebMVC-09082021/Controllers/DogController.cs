using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjWebMVC_09082021.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var lst = this.Crud().Select();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                this.Crud().Insert(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Edit(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                this.Crud().Update(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Details(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog);
        }

        public ActionResult Delete(int id)
        {
            var dog = this.Crud().SelectById(id);
            return View(dog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            this.Crud().Delete(id);
            return RedirectToAction("Index");
        }

        private IDogDB Crud()
        {
            return new DogDB();
        }
    }
}