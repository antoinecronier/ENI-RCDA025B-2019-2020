using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TPModule6_1.Data;
using TPModule6_1.Models;

namespace TPModule6_1.Controllers
{
    public class SamouraisController : Controller
    {
        private TPModule6_1Context db = new TPModule6_1Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel vm = new SamouraiViewModel();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.IdSelectedArme != null)
                {
                    var samouraisAvecMonArme = db.Samourais.Where(x => x.Arme.Id == vm.IdSelectedArme).ToList();

                    foreach (var item in samouraisAvecMonArme)
                    {
                        item.Arme = null;
                        db.Entry(item).State = EntityState.Modified;
                    }

                    vm.Samourai.Arme = db.Armes.Find(vm.IdSelectedArme);
                }
                
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.Armes = db.Armes.ToList();

            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamouraiViewModel vm = new SamouraiViewModel();
            vm.Samourai = db.Samourais.Find(id);
            if (vm.Samourai == null)
            {
                return HttpNotFound();
            }

            vm.Armes = db.Armes.ToList();

            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var currentSamourai = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == vm.Samourai.Id);
                currentSamourai.Force = vm.Samourai.Force;
                currentSamourai.Nom = vm.Samourai.Nom;

                if (vm.IdSelectedArme != null)
                {
                    var samouraisAvecMonArme = db.Samourais.Where(x => x.Arme.Id == vm.IdSelectedArme).ToList();

                    Arme arme = null;
                    foreach (var item in samouraisAvecMonArme)
                    {
                        arme = item.Arme;
                        item.Arme = null;
                        db.Entry(item).State = EntityState.Modified;
                    }

                    if (arme == null)
                    {
                        currentSamourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme);
                    }
                    else
                    {
                        currentSamourai.Arme = arme;
                    }
                }
                else
                {
                    currentSamourai.Arme = null;
                }

                db.Entry(currentSamourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
