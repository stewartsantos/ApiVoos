using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoosAPI.Services;
using VoosAPI.Models;

namespace VoosAPI.Controllers
{
    [ApiController]
    public class CiasController : ControllerBase
    {
        private readonly CiasService _ciasService;

        public CiasController(CiasService ciasService)
        {
            _ciasService = ciasService;
        }

        [HttpGet]
        [Route("/cias")]
        public ActionResult<List<Cia>> Get() =>
            _ciasService.Get();

        [Route("/cias/GetCia")]
        public ActionResult<Cia> Get(string id)
        {
            var cia = _ciasService.Get(id);
            
            if(cia == null) 
            {
                return NotFound();
            }
                       
            return cia;
        }

        [HttpPost]
        [Route("/cias")]
        public ActionResult<Cia> Create(Cia cia)
        {
            _ciasService.Create(cia);

            return CreatedAtRoute("GetCia", new { id = cia.Id.ToString() }, cia);
        }

        [HttpPut]
        [Route("/cias/{id}")]
        public IActionResult Update(string id, Cia ciaIn)
        {
            var cia = _ciasService.Get(id);
            if(cia == null)
            {
                return NotFound();
            }
            _ciasService.Update(id, ciaIn);
            return NoContent();
        }
        [HttpDelete]
        [Route("/cias/{id}")]
        public IActionResult Delete(string id)
        {
            var cia = _ciasService.Get(id);

            if(cia == null)
            {
                return NotFound();
            }

            _ciasService.Remove(cia.Id);

            return NoContent();
        }

    }
}
