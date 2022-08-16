using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio.Models;

namespace Desafio.Controllers
{
    public class IfesController : Controller
    {
        private context db = new context();

        // GET: Ifes
        public ActionResult Index()
        {
            return View(db.Fundacoes.ToList());
        }

        // GET: Ifes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifes ifes = db.Fundacoes.Find(id);
            if (ifes == null)
            {
                return HttpNotFound();
            }
            return View(ifes);
        }

        // GET: Ifes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ifes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cnpj,nome,email,telefone")] Ifes ifes)
        {
            if (ModelState.IsValid)
            {
                db.Fundacoes.Add(ifes);
                try
                {
                    db.SaveChanges();
                }
                catch { return RedirectToAction("Shared/Error"); }
                return RedirectToAction("Index");
            }

            return View(ifes);
        }

        // GET: Ifes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifes ifes = db.Fundacoes.Find(id);
            if (ifes == null)
            {
                return HttpNotFound();
            }
            return View(ifes);
        }

        public ActionResult Search(string id)
        {
            id = "123";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifes ifes = db.Fundacoes.Find(id);
            if (ifes == null)
            {
                return HttpNotFound();
            }
            return View(ifes);
        }


        // POST: Ifes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cnpj,nome,email,telefone")] Ifes ifes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ifes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ifes);
        }

        // GET: Ifes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifes ifes = db.Fundacoes.Find(id);
            if (ifes == null)
            {
                return HttpNotFound();
            }
            return View(ifes);
        }

        // POST: Ifes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ifes ifes = db.Fundacoes.Find(id);
            db.Fundacoes.Remove(ifes);
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
