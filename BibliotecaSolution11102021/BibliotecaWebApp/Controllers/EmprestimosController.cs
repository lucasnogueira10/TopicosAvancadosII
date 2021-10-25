using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApp.Data;
using Teste.Models;

namespace BibliotecaWebApp.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly BibliotecaWebAppContext _context;

        public EmprestimosController(BibliotecaWebAppContext context)
        {
            _context = context;
        }

        // GET: Emprestimos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emprestimo.Include(l => l.Livro).Include(c => c.Cliente).ToListAsync());
        }

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
        {
            var e = new Emprestimo();
            var livros = _context.Livro.Include(s => s.Status).ToList();
            var clientes = _context.Cliente.ToList();

            e.Livros = new List<SelectListItem>();
            e.Clientes = new List<SelectListItem>();

            foreach (var liv in livros)
            {
                if (liv.Status.Descricao != "Emprestado")
                    e.Livros.Add(new SelectListItem { Text = liv.Nome, Value = liv.Id.ToString() });
            }
            
            foreach (var cli in clientes)
            {
                e.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }

            return View(e);
        }

        // POST: Emprestimos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DtEmprestimo,DtDevolucao")] Emprestimo emprestimo)
        {
            int _livroId = int.Parse(Request.Form["Livro"].ToString());
            var livro = _context.Livro.FirstOrDefault(l => l.Id == _livroId);

            //Regra de negócio do status do livro
            var status = _context.Status.FirstOrDefault(s => s.Descricao == "Emprestado");
            if (status == null)
            {
                Status novoStatus = new Status();
                novoStatus.Descricao = "Emprestado";
                _context.Add(novoStatus);
                status = novoStatus;
            }
            livro.Status = status;
            //Fim da regra de negócio

            //Regra de negócio da data de devolução
            emprestimo.DtDevolucao = emprestimo.DtEmprestimo.AddDays(7);
            //Fim da regra de negócio

            emprestimo.Livro = livro;

            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            emprestimo.Cliente = cliente;

            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = _context.Emprestimo.Include(l => l.Livro).First(e => e.Id == id);
            var livros = _context.Livro.ToList();
            emprestimo.Livros = new List<SelectListItem>();

            foreach (var liv in livros)
            {
                emprestimo.Livros.Add(new SelectListItem { Text = liv.Nome, Value = liv.Id.ToString() });
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////

            emprestimo = _context.Emprestimo.Include(c => c.Cliente).First(e => e.Id == id);
            var clientes = _context.Cliente.ToList();
            emprestimo.Clientes = new List<SelectListItem>();

            foreach (var cli in clientes)
            {
                emprestimo.Clientes.Add(new SelectListItem { Text = cli.Nome, Value = cli.Id.ToString() });
            }

            //var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DtEmprestimo,DtDevolucao")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            int _livroId = int.Parse(Request.Form["Livro"].ToString());
            var livro = _context.Livro.FirstOrDefault(l => l.Id == _livroId);
            emprestimo.Livro = livro;

            int _clienteId = int.Parse(Request.Form["Cliente"].ToString());
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == _clienteId);
            emprestimo.Cliente = cliente;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
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
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            //Regra de negócio devolver status "Disponível" para o livro
            var ListaEmprestimos = await _context.Emprestimo.Include(l => l.Livro).Include(c => c.Cliente).ToListAsync();
            var emprestimo = ListaEmprestimos.FirstOrDefault(e => e.Id == id);
            int _livroId = emprestimo.Livro.Id;
            var ListaLivros = await _context.Livro.Include(s => s.Status).Include(a => a.Autor).ToListAsync();
            var livro = ListaLivros.FirstOrDefault(e => e.Id == _livroId);
            var statusDisponivel = _context.Status.FirstOrDefault(s => s.Descricao == "Disponível");
            livro.Status = statusDisponivel;
            //Fim da regra de negócio
            _context.Emprestimo.Remove(emprestimo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimo.Any(e => e.Id == id);
        }
    }
}
