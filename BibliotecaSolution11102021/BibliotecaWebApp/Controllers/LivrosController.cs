using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApp.Data;
using Teste.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BibliotecaWebApp.Controllers
{
    public class LivrosController : Controller
    {
        private readonly BibliotecaWebAppContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LivrosController(BibliotecaWebAppContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livro.Include(a => a.Autor).Include(s => s.Status).ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            var l = new Livro();
            var autores = _context.Autor.ToList();

            l.Autores = new List<SelectListItem>();

            foreach (var aut in autores)
            {
                l.Autores.Add(new SelectListItem { Text = aut.Nome, Value = aut.Id.ToString() });
            }
            
            return View(l);
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DtCadastro,ImagemLivro")] Livro livro)
        {
            int _autorId = int.Parse(Request.Form["Autor"].ToString());
            var autor = _context.Autor.FirstOrDefault(a => a.Id == _autorId);
            livro.Autor = autor;
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(livro.ImagemLivro.FileName);
                string extension = Path.GetExtension(livro.ImagemLivro.FileName);
                livro.Imagem = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await livro.ImagemLivro.CopyToAsync(fileStream);
                }
            
                //Regra de negócio do status do livro
                var status = _context.Status.FirstOrDefault(s => s.Descricao == "Disponível");
                if(status == null)
                {
                    Status novoStatus = new Status();
                    novoStatus.Descricao = "Disponível";
                    _context.Add(novoStatus);
                    status = novoStatus;
                }
                livro.Status = status;
                //Fim da regra de negócio

                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _context.Livro.Include(a => a.Autor).First(i => i.Id == id);
            var autores = _context.Autor.ToList();
            livro.Autores = new List<SelectListItem>();

            foreach (var aut in autores)
            {
                livro.Autores.Add(new SelectListItem { Text = aut.Nome, Value = aut.Id.ToString() });
            }

            livro = _context.Livro.Include(s => s.Status).First(i => i.Id == id);
            var statusList = _context.Status.ToList();
            livro.ListaStatus = new List<SelectListItem>();

            foreach (var stat in statusList)
            {
                livro.ListaStatus.Add(new SelectListItem { Text = stat.Descricao, Value = stat.Id.ToString() });
            }

            //var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DtCadastro,Imagem")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            int _autorId = int.Parse(Request.Form["Autor"].ToString());
            var autor = _context.Autor.FirstOrDefault(a => a.Id == _autorId);
            livro.Autor = autor;

            /*int _statusId = int.Parse(Request.Form["Status"].ToString());
            var status = _context.Status.FirstOrDefault(s => s.Id == _statusId);
            livro.Status = status;*/

            if (ModelState.IsValid)
            {
                try
                {
                    //Verifilivro se o nome da imagem mudou:
                    var livroCompare = _context.Livro.Find(livro.Id);

                    livro.Imagem = (livro.ImagemLivro == null) ? "" : livro.ImagemLivro.FileName;

                    if (!CompareFileName(livroCompare.Imagem, livro.Imagem))
                    {
                        //Remover Imagem anterior
                        var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", livroCompare.Imagem);
                        if (System.IO.File.Exists(imagePath))
                            System.IO.File.Delete(imagePath);

                        //Incluir nova
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(livro.ImagemLivro.FileName);
                        string extension = Path.GetExtension(livro.ImagemLivro.FileName);
                        livro.Imagem = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/image", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await livro.ImagemLivro.CopyToAsync(fileStream);
                        }
                    }

                    livroCompare.Nome = livro.Nome;
                    livroCompare.Autor = livro.Autor;
                    livroCompare.DtCadastro = livro.DtCadastro;
                    livroCompare.Imagem = string.IsNullOrEmpty(livro.Imagem) ? livroCompare.Imagem : livro.Imagem;
                    livroCompare.Status = livro.Status;

                    _context.Update(livroCompare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            return View(livro);
        }

        private bool CompareFileName(string name, string newName)
        {
            //Se não foi selecionada uma imagem nova fica a antiga. 
            if (string.IsNullOrEmpty(newName))
                return true;

            if (string.IsNullOrEmpty(name))
                return false;

            //extensão do arquivo
            var validateName = name.Split('.');
            var validateNewName = newName.Split('.');

            if (validateName[1] != validateNewName[1])
                return false;

            //Remover a data gerada
            string nameOld = validateName[0].Replace(validateName[0]
                                            .Substring(validateName[0].Length - 9, 9), "");

            if (newName == nameOld)
                return true;

            return false;
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livro.FindAsync(id);

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", livro.Imagem);

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.Id == id);
        }
    }
}
