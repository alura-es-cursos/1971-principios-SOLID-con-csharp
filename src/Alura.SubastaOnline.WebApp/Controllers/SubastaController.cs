using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Models;
using System;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    public class SubastaController : Controller
    {

        AppDbContext _context;

        public SubastaController()
        {
            _context = new AppDbContext();
        }

        public IActionResult Index()
        {
            var leiloes = _context.Subastas
                .Include(l => l.Categoria);
            return View(leiloes);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _context.Categorias.ToList();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _context.Subastas.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _context.Categorias.ToList();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _context.Categorias.ToList();
            ViewData["Operacao"] = "Edição";
            var subasta = _context.Subastas.Find(id);
            if (subasta == null) return NotFound();
            return View("Form", subasta);
        }

        [HttpPost]
        public IActionResult Edit(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _context.Subastas.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _context.Categorias.ToList();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var subasta = _context.Subastas.Find(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Borrador) return StatusCode(405);
            subasta.Status = StatusSubasta.Proceso;
            subasta.Inicio = DateTime.Now;
            _context.Subastas.Update(subasta);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var subasta = _context.Subastas.Find(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Proceso) return StatusCode(405);
            subasta.Status = StatusSubasta.Finalizado;
            subasta.Termino = DateTime.Now;
            _context.Subastas.Update(subasta);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var subasta = _context.Subastas.Find(id);
            if (subasta == null) return NotFound();
            if (subasta.Status == StatusSubasta.Proceso) return StatusCode(405);
            _context.Subastas.Remove(subasta);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _context.Subastas
                .Include(l => l.Categoria)
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descripcion.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descripcion.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
