using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class GameCategoriesController : Controller
    {
        private Assignment2Context db = new Assignment2Context();

        // GET: GameCategories
        public ActionResult Index()
        {
            return View(db.GameCategories.OrderBy(c=>c.Name).ToList());
        }

        // GET: GameCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameCategory gameCategory = db.GameCategories.Find(id);
            if (gameCategory == null)
            {
                return HttpNotFound();
            }
            return View(gameCategory);
        }

        // GET: GameCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameCategories/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] GameCategory gameCategory)
        {
            if (ModelState.IsValid)
            {
                db.GameCategories.Add(gameCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameCategory);
        }

        // GET: GameCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameCategory gameCategory = db.GameCategories.Find(id);
            if (gameCategory == null)
            {
                return HttpNotFound();
            }
            return View(gameCategory);
        }

        // POST: GameCategories/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] GameCategory gameCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameCategory);
        }

        // GET: GameCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameCategory gameCategory = db.GameCategories.Find(id);
            if (gameCategory == null)
            {
                return HttpNotFound();
            }
            return View(gameCategory);
        }

        // POST: GameCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameCategory gameCategory = db.GameCategories.Find(id);
            db.GameCategories.Remove(gameCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
