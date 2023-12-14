using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorTipoProductos : ControllerBase
{

    static ServicioTipoProducto? servicio;
    public ControladorTipoProductos(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioTipoProducto(conn);
    }
    [HttpGet]
    public IList<TipoProducto> GetTipoProductos(){
        return servicio.Listar();
    }

    [HttpGet("{id}")]
    public ActionResult<TipoProducto> Get(int id)
    {
            var tipoProducto = ServicioTipoProducto.Get(id);

        if(tipoProducto == null)
            return NotFound();

        return tipoProducto;
    }


    [HttpPost]
    public IActionResult Create(TipoProducto tipoProducto)
    {            
        ServicioTipoProducto.Add(tipoProducto);
        return CreatedAtAction(nameof(Get), new { id = tipoProducto.Id }, tipoProducto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TipoProducto tipoProducto)
    {
        if (id != tipoProducto.Id)
            return BadRequest();
            
        var TipoProductoExistente = ServicioTipoProducto.Get(id);
        if(TipoProductoExistente is null)
            return NotFound();
    
        ServicioTipoProducto.Update(tipoProducto);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var tipoProducto = ServicioTipoProducto.Get(id);
   
            if (tipoProducto is null)
                return NotFound();
            
            ServicioTipoProducto.Delete(id);
        
            return NoContent();
    }
}
