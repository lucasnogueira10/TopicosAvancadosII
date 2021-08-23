using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjAula16082021.Controllers
{
    public class DisciplinaController : Controller
    {
        // GET: Disciplina
        public ActionResult Index()
        {
            DBAula16082021Entities context = new DBAula16082021Entities();
            List<Disciplina> lstDisciplina = context.Disciplina.ToList<Disciplina>();

            return View(lstDisciplina);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                DBAula16082021Entities contextDisciplina = new DBAula16082021Entities();
                contextDisciplina.Disciplina.Add(disciplina);
                contextDisciplina.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        public ActionResult Edit(int id)
        {
            Disciplina disciplina = new Disciplina();
            disciplina = new DBAula16082021Entities().Disciplina.First(i => i.Id == id);

            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                int id = disciplina.Id;
                DBAula16082021Entities contextDisciplina = new DBAula16082021Entities();
                Disciplina updatedDisciplina = contextDisciplina.Disciplina.First(d => d.Id == id);

                updatedDisciplina.Id = disciplina.Id;
                updatedDisciplina.Descricao = disciplina.Descricao;
                updatedDisciplina.QtdAlunos = disciplina.QtdAlunos;
                updatedDisciplina.NomeProfessor = disciplina.NomeProfessor;

                contextDisciplina.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        public ActionResult Details(int id)
        {
            Disciplina disciplina = new Disciplina();
            disciplina = new DBAula16082021Entities().Disciplina.First(i => i.Id == id);

            return View(disciplina);
        }

        public ActionResult Delete(int id)
        {
            DBAula16082021Entities contextDisciplina = new DBAula16082021Entities();
            Disciplina disciplina = new Disciplina();
            disciplina = new DBAula16082021Entities().Disciplina.First(i => i.Id == id);

            return View(disciplina);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            DBAula16082021Entities contextDisciplina = new DBAula16082021Entities();
            Disciplina disciplina = new Disciplina();

            disciplina = contextDisciplina.Disciplina.First(i => i.Id == id);
            contextDisciplina.Disciplina.Remove(disciplina);
            contextDisciplina.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}