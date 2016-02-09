using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class personaController : Controller
    {
        private CNXModel db = new CNXModel();

        // GET: persona
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.tipo_documento).Include(p => p.tipo_vehiculo);
            return View(persona.ToList());
        }

        // GET: persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: persona/Create
        public ActionResult Create()
        {

            ViewBag.idTipo_Doc = new SelectList(db.tipo_documento, "idTipo_Doc", "Tipo_Documento1");
            ViewBag.id_Tipo_Vehiculo = new SelectList(db.tipo_vehiculo, "id_Tipo_vehiculo", "Tipo_vehiculo1");
       
            return View();
        }

        // POST: persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_persona,idTipo_Doc,id_Tipo_Vehiculo,Cedula,Nombre,Apellido,Nom_Pers_encontro,Ape_Pers_encontro,Lugar_encontro,Fecha_registro")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipo_Doc = new SelectList(db.tipo_documento, "idTipo_Doc", "Tipo_Documento1", persona.idTipo_Doc);
            ViewBag.id_Tipo_Vehiculo = new SelectList(db.tipo_vehiculo, "id_Tipo_vehiculo", "Tipo_vehiculo1", persona.id_Tipo_Vehiculo);
            return View(persona);
        }

        // GET: persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo_Doc = new SelectList(db.tipo_documento, "idTipo_Doc", "Tipo_Documento1", persona.idTipo_Doc);
            ViewBag.id_Tipo_Vehiculo = new SelectList(db.tipo_vehiculo, "id_Tipo_vehiculo", "Tipo_vehiculo1", persona.id_Tipo_Vehiculo);
            return View(persona);
        }

        // POST: persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_persona,idTipo_Doc,id_Tipo_Vehiculo,Cedula,Nombre,Apellido,Nom_Pers_encontro,Ape_Pers_encontro,Lugar_encontro,Fecha_registro")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipo_Doc = new SelectList(db.tipo_documento, "idTipo_Doc", "Tipo_Documento1", persona.idTipo_Doc);
            ViewBag.id_Tipo_Vehiculo = new SelectList(db.tipo_vehiculo, "id_Tipo_vehiculo", "Tipo_vehiculo1", persona.id_Tipo_Vehiculo);
            return View(persona);
        }

        // GET: persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
