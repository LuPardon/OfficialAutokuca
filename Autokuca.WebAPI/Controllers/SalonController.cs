using Autokuca.Model;
using Autokuca.Service;
using Autokuca.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autokuca.WebAPI.Controllers;

[ApiController, Route("api/saloni")]
public class SalonController : Controller
{
    private IService _service { get; set; }
    public SalonController(IService service)
    {
        _service = service;
    }
    [HttpGet("")]
    public async Task<IActionResult> DohvatiSalone(string? naziv = "")
    {
        try
        {
            var result = await _service.GetAll(naziv);
            return (result != null) ? Ok(result) : NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> DohvatiSalon(int id)
    {
        try
        {

            var result = await _service.DohvatiSalon(id);

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Authorize]
    [HttpPut("update")]
    public async Task<ActionResult> AzurirajSalon([FromBody] Salon salon)
    {
        try
        {

            if (salon == null)
            {
                return NotFound();
            }

            var success = await _service.AzurirajSalon(salon);
            return Ok(success);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> NapraviSalon([FromBody] Salon salon)
    {
        try
        {
            if (salon is null)
            {
                return NotFound(salon);
            }

            var success = await _service.NapraviSalon(salon);
            return Ok(success);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> IzbrisiSalon(Salon salon)
    {
        try
        {
            if (salon is null)
            {
                return NotFound();
            }

            var success = await _service.IzbrisiSalon(salon);
            return Ok(success);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

