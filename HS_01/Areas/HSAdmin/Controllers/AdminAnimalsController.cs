using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HS_01.Models;

namespace HS_01.Areas.HSAdmin.Controllers
{
    public class AdminAnimalsController : Controller
    {
        private HS0215DB db = new HS0215DB();

        // GET: HSAdmin/AdminAnimals
        public async Task<ActionResult> Index()
        {
            var animals = db.Animals.Include(a => a.Category).Include(a => a.City);
            return View(await animals.ToListAsync());
        }

        // GET: HSAdmin/AdminAnimals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: HSAdmin/AdminAnimals/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name");
            return View();
        }

        // POST: HSAdmin/AdminAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CategoryID,Name,Description,Photo,Price,CreateDate,featuriedAni,CityId,premiumId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", animal.CategoryID);
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name", animal.CityId);
            return View(animal);
        }

        // GET: HSAdmin/AdminAnimals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", animal.CategoryID);
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name", animal.CityId);
            return View(animal);
        }

        // POST: HSAdmin/AdminAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CategoryID,Name,Description,Photo,Price,CreateDate,featuriedAni,CityId,premiumId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", animal.CategoryID);
            ViewBag.CityId = new SelectList(db.Cities, "ID", "Name", animal.CityId);
            return View(animal);
        }

        // GET: HSAdmin/AdminAnimals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: HSAdmin/AdminAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Animal animal = await db.Animals.FindAsync(id);
            db.Animals.Remove(animal);
            await db.SaveChangesAsync();
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
