using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;
using Alura.SubastaOnline.WebApp.Data;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/subastas")]
    public class SubastaApiController : ControllerBase
    {
        AppDbContext _context;

        public SubastaApiController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult EndpointGetSubastas()
        {
            var subastas = _context.Subastas
                .Include(l => l.Categoria);
            return Ok(subastas);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetSubastaById(int id)
        {
            var subasta = _context.Subastas.Find(id);
            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }

        [HttpPost]
        public IActionResult EndpointPostSubasta(Subasta subasta)
        {
            _context.Subastas.Add(subasta);
            _context.SaveChanges();
            return Ok(subasta);
        }

        [HttpPut]
        public IActionResult EndpointPutSubasta(Subasta subasta)
        {
            _context.Subastas.Update(subasta);
            _context.SaveChanges();
            return Ok(subasta);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteSubasta(int id)
        {
            var subasta = _context.Subastas.Find(id);
            if (subasta == null)
            {
                return NotFound();
            }
            _context.Subastas.Remove(subasta);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
