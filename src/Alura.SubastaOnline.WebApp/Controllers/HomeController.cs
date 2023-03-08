using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;
using Microsoft.AspNetCore.Routing;
using Alura.SubastaOnline.WebApp.Data.EFCore;
using Alura.SubastaOnline.WebApp.Services;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductoServices _service;

        public HomeController(IProductoServices service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categorias = _service.ConsultaCategoriasTotalPorStatus();
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
            var categ = _service.ConsultaCategoriaPorIdConSubastas(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termino)
        {
            ViewData["termo"] = termino;
            var subastas = _service.BusquedaSubastasPorTermino(termino);
            return View(subastas);
        }
    }
}
