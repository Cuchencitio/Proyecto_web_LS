using ApiLosSuculentos.Models;
using ApiLosSuculentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiLosSuculentos.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorBlog : ControllerBase
{
    public ControladorBlog()
    {
    }
    [HttpGet]
    public ActionResult<List<Blog>> GetAll() =>
        ServicioBlog.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Blog> Get(int id)
    {
            var blog = ServicioBlog.Get(id);

        if(blog == null)
            return NotFound();

        return blog;
    }


    [HttpPost]
    public IActionResult Create(Blog blog)
    {            
        ServicioBlog.Add(blog);
        return CreatedAtAction(nameof(Get), new { id = blog.Id }, blog);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Blog blog)
    {
        if (id != blog.Id)
            return BadRequest();
            
        var BlogExistente = ServicioBlog.Get(id);
        if(BlogExistente is null)
            return NotFound();
    
        ServicioBlog.Update(blog);           
   
    return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
            var blog = ServicioBlog.Get(id);
   
            if (blog is null)
                return NotFound();
            
            ServicioBlog.Delete(id);
        
            return NoContent();
    }
}