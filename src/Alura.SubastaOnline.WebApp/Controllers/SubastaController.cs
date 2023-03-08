using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;
using System;
using Alura.SubastaOnline.WebApp.Data;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    public class SubastaController : Controller
    {
        ISubastasDao _dao;

        public SubastaController(ISubastasDao dao)
        {
            _dao = dao;
        }
        public IActionResult Index()
        {
            var subastas = _dao.BuscarTodasLasSubastas();
            return View(subastas);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _dao.IncluirSubasta(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Edição";
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null) return NotFound();
            return View("Form", subasta);
        }

        [HttpPost]
        public IActionResult Edit(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _dao.ActualizarSubasta(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Borrador) return StatusCode(405);
            _dao.ActualizarSubasta(subasta);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Proceso) return StatusCode(405);
            subasta.Status = StatusSubasta.Finalizado;
            subasta.Termino = DateTime.Now;
            _dao.ActualizarSubasta(subasta);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status == StatusSubasta.Proceso) return StatusCode(405);
            _dao.EliminarSubasta(subasta);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _dao.BuscarTodasLasSubastas()
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descripcion.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descripcion.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
