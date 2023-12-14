using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControldorTipoServicios : ControllerBase
{
    static ServicioTipoServicio? servicio;
    public ControldorTipoServicios(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioTipoServicio(conn);
    }
    [HttpGet]
    public IList<Servicios> GetAll() {
        return servicio.Listar();
    }

    [HttpGet("{id}")]
    public ActionResult<Servicios> Get(int id)
    {
            var servicio = ServicioTipoServicio.Get(id);

        if(servicio == null)
            return NotFound();

        return servicio;
    }


    [HttpPost]
    public IActionResult Create(Servicios servicio)
    {            
        ServicioTipoServicio.Add(servicio);
        return CreatedAtAction(nameof(Get), new { id = servicio.Id }, servicio);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Servicios servicio)
    {
        if (id != servicio.Id)
            return BadRequest();
            
        var ServicioExistente = ServicioTipoServicio.Get(id);
        if(ServicioExistente is null)
            return NotFound();
    
        ServicioTipoServicio.Update(servicio);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var servicio = ServicioTipoServicio.Get(id);
   
            if (servicio is null)
                return NotFound();
            
            ServicioTipoServicio.Delete(id);
        
            return NoContent();
    }
}