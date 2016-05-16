using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DateNightCleveland.Models;

namespace DateNightCleveland.Controllers
{
    public class DateModelsController : Controller
    {
        private DateNightClevelandContext db = new DateNightClevelandContext();
        //LINQ

            //Outdoors//
        public ActionResult Outdoors ()
        {
            var NedEps = from Outy in db.DateModels
                         where Outy.DateType == "Outdoors"
                         select Outy;
            return View(NedEps.ToList());
        }
        //Dinner//
        public ActionResult Dinner()
        {
            var NedEps = from DinDin in db.DateModels
                         where DinDin.DateType == "Dinner"
                         select DinDin;
            return View(NedEps.ToList());
        }
        //Indoor//
        public ActionResult Indoor()
        {
            var NedEps = from Ind in db.DateModels
                         where Ind.DateType == "Indoors"
                         select Ind;
            return View(NedEps.ToList());
        }


        //LINQ

        // GET: DateModels
        public ActionResult Index()
        {
            return View(db.DateModels.ToList());
        }

        // GET: DateModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateModel dateModel = db.DateModels.Find(id);
            if (dateModel == null)
            {
                return HttpNotFound();
            }
            return View(dateModel);
        }

        // GET: DateModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DateModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Title,DateType,Address,PhoneNum,Photo,Website,PricePerPerson")] DateModel dateModel)
        {
            if (ModelState.IsValid)
            {
                db.DateModels.Add(dateModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dateModel);
        }

        // GET: DateModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateModel dateModel = db.DateModels.Find(id);
            if (dateModel == null)
            {
                return HttpNotFound();
            }
            return View(dateModel);
        }

        // POST: DateModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Title,DateType,Address,PhoneNum,Photo,Website,PricePerPerson")] DateModel dateModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dateModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dateModel);
        }

        // GET: DateModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DateModel dateModel = db.DateModels.Find(id);
            if (dateModel == null)
            {
                return HttpNotFound();
            }
            return View(dateModel);
        }

        // POST: DateModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DateModel dateModel = db.DateModels.Find(id);
            db.DateModels.Remove(dateModel);
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
