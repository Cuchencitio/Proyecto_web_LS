using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorCompra : ControllerBase
{
    static ServicioCompra? servicio;
    public ControladorCompra(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioCompra(conn);
    }
    [HttpGet]
    public IList<Compra> GetCompras()
    {
        return servicio.Listar();
    }



    [HttpGet("{id}")]
    public ActionResult<Compra> Get(int id)
    {
            var compra = ServicioCompra.Get(id);

        if(compra == null)
            return NotFound();

        return compra;
    }


    [HttpPost]
    public IActionResult Create(Compra compra)
    {            
        ServicioCompra.Add(compra);
        return CreatedAtAction(nameof(Get), new { id = compra.Id }, compra);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Compra compra)
    {
        if (id != compra.Id)
            return BadRequest();
            
        var CompraExistente = ServicioCompra.Get(id);
        if(CompraExistente is null)
            return NotFound();
    
        ServicioCompra.Update(compra);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var compra = ServicioCompra.Get(id);
   
            if (compra is null)
                return NotFound();
            
            ServicioCompra.Delete(id);
        
            return NoContent();
    }
}