using Microsoft.AspNetCore.Mvc;
using Alura.SubastaOnline.WebApp.Models;
using Alura.SubastaOnline.WebApp.Data;
using Alura.SubastaOnline.WebApp.Services;

namespace Alura.SubastaOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/subastas")]
    public class SubastaApiController : ControllerBase
    {

        IAdminServices _service;

        public SubastaApiController(IAdminServices service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult EndpointGetSubastas()
        {
            var subastas = _service.ConsultaSubastas();
            return Ok(subastas);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetSubastaById(int id)
        {
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null)
            {
                return NotFound();
            }
            return Ok(subasta);
        }

        [HttpPost]
        public IActionResult EndpointPostSubasta(Subasta subasta)
        {
            _service.InsertaSubasta(subasta);
            return Ok(subasta);
        }

        [HttpPut]
        public IActionResult EndpointPutSubasta(Subasta subasta)
        {
            _service.ModificaSubasta(subasta);
            return Ok(subasta);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteSubasta(int id)
        {
            var subasta = _service.ConsultaSubastaPorId(id);
            if (subasta == null)
            {
                return NotFound();
            }
            _service.EliminaSubasta(subasta);
            return NoContent();
        }


    }
}
