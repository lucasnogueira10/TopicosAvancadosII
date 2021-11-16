using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoMVC.Data;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class TurmasController : Controller
    {
        private readonly CursoMVCContext _context;

        public TurmasController(CursoMVCContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turma.Include(c => c.Aluno).Include(l => l.Professor).ToListAsync());
        }
            
        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {

            var p = new Turma();

            var aluno = _context.Aluno.ToList();

            p.Alunoes = new List<SelectListItem>();
            foreach (var cli in aluno)
            {
                p.Alunoes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }
            //////
            var professor = _context.Professor.ToList();

            p.Professors = new List<SelectListItem>();
            foreach (var lan in professor)
            {
                p.Professors.Add(new SelectListItem { Text = lan.Nome, Value = lan.Id.ToString() });
            }
            //////
            return View(p);
            //return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,codTurma,Semestre,Ano")] Turma turma)
        {

            int _alunoId = int.Parse(Request.Form["Aluno"].ToString());
            var aluno = _context.Aluno.FirstOrDefault(d => d.Id == _alunoId);
            turma.Aluno = aluno;

            int _professorId = int.Parse(Request.Form["Professor"].ToString());
            var professor = _context.Professor.FirstOrDefault(d => d.Id == _professorId);
            turma.Professor = professor;

            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,codTurma,Semestre,Ano")] Turma turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turma.FindAsync(id);
            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.Id == id);
        }
    }
}
