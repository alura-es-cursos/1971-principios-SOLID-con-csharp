using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Models;
using Microsoft.AspNetCore.Routing;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController()
        {
            _context = new AppDbContext();
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias
                .Include(c => c.Subastas)
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion,
                    Imagen = c.Imagen,
                    EnBorrador = c.Subastas.Where(l => l.Status == StatusSubasta.Borrador).Count(),
                    EnProceso = c.Subastas.Where(l => l.Status == StatusSubasta.Proceso).Count(),
                    Finalizados = c.Subastas.Where(l => l.Status == StatusSubasta.Finalizado).Count(),
                });
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = _context.Categorias
                .Include(c => c.Subastas)
                .First(c => c.Id == categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var termoNormalized = termo.ToUpper();
            var leiloes = _context.Subastas
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descripcion.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descripcion.ToUpper().Contains(termoNormalized));
            return View(leiloes);
        }
    }
}
