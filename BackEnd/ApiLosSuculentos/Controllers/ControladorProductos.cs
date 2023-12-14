using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorProductos : ControllerBase
{
    
    static ServicioProductos? servicio;
    public ControladorProductos(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioProductos(conn);
    }
    [HttpGet]
    public IList<Productos> GetProductos() {
        return servicio.Listar();
    }

    [HttpGet("{id}")]
    public ActionResult<Productos> Get(int id)
    {
            var producto = ServicioProductos.Get(id);

        if(producto == null)
            return NotFound();

        return producto;
    }


    [HttpPost]
    public IActionResult Create(Productos producto)
    {            
        ServicioProductos.Add(producto);
        return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Productos producto)
    {
        if (id != producto.Id)
            return BadRequest();
            
        var ProductoExistente = ServicioProductos.Get(id);
        if(ProductoExistente is null)
            return NotFound();
    
        ServicioProductos.Update(producto);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var producto = ServicioProductos.Get(id);
   
            if (producto is null)
                return NotFound();
            
            ServicioProductos.Delete(id);
        
            return NoContent();
    }
}