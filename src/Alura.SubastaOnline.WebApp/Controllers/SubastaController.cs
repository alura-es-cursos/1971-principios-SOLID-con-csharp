using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;
using System;
using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Services;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    public class SubastaController : Controller
    {
        IAdminServices _service;

        public SubastaController(IAdminServices service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var subastas = _service.ConsultaSubastas();
            return View(subastas);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Inclusión";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _service.InsertaSubasta(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Inclusión";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Edición";
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null) return NotFound();
            return View("Form", subasta);
        }

        [HttpPost]
        public IActionResult Edit(Subasta model)
        {
            if (ModelState.IsValid)
            {
                _service.ModificaSubasta(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _service.ConsultaCategorias();
            ViewData["Operacao"] = "Edición";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Borrador) return StatusCode(405);
            _service.IniciaProcesoDeSubastaConId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status != StatusSubasta.Proceso) return StatusCode(405);
            _service.FinalizaProcesoDeSubastaConId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null) return NotFound();
            if (subasta.Status == StatusSubasta.Proceso) return StatusCode(405);
            _service.EliminaSubasta(subasta);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var subastas = _service.ConsultaSubastas()
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descripcion.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descripcion.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", subastas);
        }
    }
}
