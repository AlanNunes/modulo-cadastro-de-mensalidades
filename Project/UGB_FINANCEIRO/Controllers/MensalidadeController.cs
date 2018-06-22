using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGB_FINANCEIRO.Models;

namespace UGB_FINANCEIRO.Controllers
{
    public class MensalidadeController : Controller
    {
        private DBFinanceiroModel db = new DBFinanceiroModel();

        // GET: Mensalidade
        public ActionResult Index()
        {
            var mensalidade = db.Mensalidade.Include(m => m.Curso);
            return View(mensalidade.ToList());
        }

        // GET: Mensalidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidade.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            return View(mensalidade);
        }

        // GET: Mensalidade/Create
        public ActionResult Create()
        {
            ViewBag.Curso_idCurso = new SelectList(db.Curso, "idCurso", "NomeCurso");
            return View();
        }

        // POST: Mensalidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMensalidade,ValorMensalidade,DataVencimento,JurosAoDia,PercentualBolsa,Curso_idCurso")] Mensalidade mensalidade)
        {
            if (ModelState.IsValid)
            {
                db.Mensalidade.Add(mensalidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Curso_idCurso = new SelectList(db.Curso, "idCurso", "NomeCurso", mensalidade.Curso_idCurso);
            return View(mensalidade);
        }

        // GET: Mensalidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidade.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.Curso_idCurso = new SelectList(db.Curso, "idCurso", "NomeCurso", mensalidade.Curso_idCurso);
            return View(mensalidade);
        }

        // POST: Mensalidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMensalidade,ValorMensalidade,DataVencimento,JurosAoDia,PercentualBolsa,Curso_idCurso")] Mensalidade mensalidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensalidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Curso_idCurso = new SelectList(db.Curso, "idCurso", "NomeCurso", mensalidade.Curso_idCurso);
            return View(mensalidade);
        }

        // GET: Mensalidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidade.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            return View(mensalidade);
        }

        // POST: Mensalidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensalidade mensalidade = db.Mensalidade.Find(id);
            db.Mensalidade.Remove(mensalidade);
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
