using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorDetalleCompras : ControllerBase
{
    static ServicioDetalleCompra? servicio;
    public ControladorDetalleCompras(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioDetalleCompra(conn);
    }
    [HttpGet]
    public IList<DetalleCompra> GetAll() {
        return servicio.Listar();
    }

    [HttpGet("{id}")]
    public ActionResult<DetalleCompra> Get(int id)
    {
            var detallecompra = ServicioDetalleCompra.Get(id);

        if(detallecompra == null)
            return NotFound();

        return detallecompra;
    }


    [HttpPost]
    public IActionResult Create(DetalleCompra detallecompra)
    {            
        ServicioDetalleCompra.Add(detallecompra);
        return CreatedAtAction(nameof(Get), new { id = detallecompra.Id_det_compras }, detallecompra);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, DetalleCompra detallecompra)
    {
        if (id != detallecompra.Id_det_compras)
            return BadRequest();
            
        var DetalleCompraExistente = ServicioDetalleCompra.Get(id);
        if(DetalleCompraExistente is null)
            return NotFound();
    
        ServicioDetalleCompra.Update(detallecompra);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var detallecompra = ServicioDetalleCompra.Get(id);
   
            if (detallecompra is null)
                return NotFound();
            
            ServicioProductos.Delete(id);
        
            return NoContent();
    }
}