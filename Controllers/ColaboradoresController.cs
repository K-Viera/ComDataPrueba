using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComDataPrueba.Models;

namespace ComDataPrueba.Controllers
{
    public class ColaboradoresController : Controller
    {
        private ComDataEntities db = new ComDataEntities();

        // GET: Colaboradores
        public ActionResult Index()
        {
            return View(db.Colaboradores.ToList());
        }

        // GET: Colaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumeroIdentificacion,Nombres,Apellidos,Direccion,Email,Telefono,Salario,Ingreso,Sexo,Area")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Colaboradores.Add(colaboradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumeroIdentificacion,Nombres,Apellidos,Direccion,Email,Telefono,Salario,Ingreso,Sexo,Area")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaboradores colaboradores = db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaboradores);
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
