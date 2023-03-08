using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.SubastaOnline.WebApp.Models;
using Alura.SubastaOnline.WebApp.Data;
using System.Linq;
using System.Collections.Generic;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/subastas")]
    public class SubastaApiController : ControllerBase
    {

        SubastasDao _dao;

        public SubastaApiController()
        {
            _dao = new SubastasDao();
        }
        [HttpGet]
        public IActionResult EndpointGetSubastas()
        {
            var subastas = _dao.BuscarTodasLasSubastas();
            return Ok(subastas);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetSubastaById(int id)
        {
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }

        [HttpPost]
        public IActionResult EndpointPostSubasta(Subasta subasta)
        {
            _dao.IncluirSubasta(subasta);
            return Ok(subasta);
        }

        [HttpPut]
        public IActionResult EndpointPutSubasta(Subasta subasta)
        {
            _dao.ActualizarSubasta(subasta);
            return Ok(subasta);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteSubasta(int id)
        {
            var subasta = _dao.BuscarSubastaPorId(id);
            if (subasta == null)
            {
                return NotFound();
            }
            _dao.EliminarSubasta(subasta);
            return NoContent();
        }


    }
}
