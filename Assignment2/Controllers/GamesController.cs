using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class GamesController : Controller
    {
        private Assignment2Context db = new Assignment2Context();

        // GET: Games
        public ActionResult Index(string GameCategory, string search, string sortOrder)
        {
            var games = db.Games.Include(g => g.GameCategory);
            var gamecategories = games.OrderBy(g => g.GameCategory.Name).Select(g => g.GameCategory.Name).Distinct();
            if (!string.IsNullOrEmpty(GameCategory))
            {
                games = games.Where(g => g.GameCategory.Name == GameCategory);
            }

            if (!String.IsNullOrEmpty(search))
            {
                games = games.Where(g => g.Name.Contains(search));
                ViewBag.Search = search;
            }

            switch (sortOrder)
            {
                case "price_desc":
                    games = games.OrderByDescending(g => g.price);
                    break;
                case "price_asc":
                    games = games.OrderBy(g => g.price);
                    break;
                default:
                    games = games.OrderBy(g => g.Id); 
                    break;
            }

            ViewBag.SelectedGameCategory = GameCategory;
            ViewBag.SortOrder = sortOrder;

            
            ViewBag.GameCategory = new SelectList(gamecategories);

            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.GameCategories, "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,price,ImageUrl,Evaluation,VideoUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.GameCategories, "Id", "Name", game.CategoryId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.GameCategories, "Id", "Name", game.CategoryId);
            return View(game);
        }

        // POST: Games/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,price,ImageUrl,Evaluation,VideoUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.GameCategories, "Id", "Name", game.CategoryId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
