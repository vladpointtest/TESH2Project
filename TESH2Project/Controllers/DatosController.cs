using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TESH2Project.Data;
using TESH2Project.Models;

namespace TESH2Project.Controllers
{
    public class DatosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Datos
        public ActionResult Index()
        {
            return View(db.Datos.ToList());
        }

        // GET: Datos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // GET: Datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Compania,Empleados")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Datos.Add(datos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datos);
        }

        // GET: Datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: Datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Compania,Empleados")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datos);
        }

        // GET: Datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datos datos = db.Datos.Find(id);
            db.Datos.Remove(datos);
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
