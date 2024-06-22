using Autokuca.Model;
using Autokuca.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autokuca.WebAPI.Controllers
{
    [ApiController, Route("api/vozila")]
    public class VoziloController : Controller
    {
        private readonly IService _service;
        public VoziloController(IService service)
        {
            _service = service;
        }
        [HttpGet("")]
        public async Task<IActionResult> DohvatiVozila(
            int? id_salona,
            string? tip_vozila,
            string? proizvodac,
            string? oznaka_vozila,
            int? god_proizvodnje,
            string? snaga_motora,
            string? model_vozila,
            decimal? cijena,
            string? vrsta_vozila,
            string? mjenjac,
            string? gorivo)
        {
            try
            {
                var result = await _service.DohvatiVozila(
                    id_salona: id_salona,
                    tip_vozila: tip_vozila,
                    proizvodac: proizvodac,
                    oznaka_vozila: oznaka_vozila,
                    god_proizvodnje: god_proizvodnje,
                    snaga_motora: snaga_motora,
                    model_vozila: model_vozila,
                    cijena: cijena,
                    vrsta_vozila: vrsta_vozila,
                    mjenjac: mjenjac,
                    gorivo: gorivo);

                return (result != null) ? Ok(result) : NotFound();
            }
            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> DohvatiVozilo(int id)
        {
            try
            {

                var result = await _service.DohvatiVozilo(id);

                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPut("update")]
        public async Task<ActionResult> AzurirajVozilo([FromBody] Vozilo vozilo)
        {
            try
            {

                if (vozilo == null)
                {
                    return NotFound();
                }

                var success = await _service.AzurirajVozilo(vozilo);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> NapraviVozilo([FromBody] Vozilo vozilo)
        {
            try
            {
                if (vozilo is null)
                {
                    return NotFound(vozilo);
                }

                var success = await _service.NapraviVozilo(vozilo);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> IzbrisiVozilo(Vozilo vozilo)
        {
            try
            {
                if (vozilo is null)
                {
                    return NotFound();
                }

                var success = await _service.IzbrisiVozilo(vozilo);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
