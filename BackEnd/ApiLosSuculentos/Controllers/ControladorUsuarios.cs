using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorUsuarios : ControllerBase
{
   static ServicioUsuario? servicio;
    public ControladorUsuarios(IConfiguration configuration)
    {
        string conn = configuration.GetConnectionString("oci");
        servicio = new ServicioUsuario(conn);
    }
    [HttpGet]
    public List<Usuario> GetAll() {
        return servicio.Listar();
    }

    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
            var usuario = ServicioUsuario.Get(id);

        if(usuario == null)
            return NotFound();

        return usuario;
    }


    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {            
        ServicioUsuario.Add(usuario);
        return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Usuario usuario)
    {
        if (id != usuario.Id)
            return BadRequest();
            
        var UsuarioExistente = ServicioUsuario.Get(id);
        if(UsuarioExistente is null)
            return NotFound();
    
        ServicioUsuario.Update(usuario);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var usuario = ServicioUsuario.Get(id);
   
            if (usuario is null)
                return NotFound();
            
            ServicioUsuario.Delete(id);
        
            return NoContent();
    }
}