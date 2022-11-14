using Microsoft.AspNetCore.Mvc;

namespace Tp_09_Fede_Chediex.Controllers;
using Tp_09_Fede_Chediex.Models;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{


    [HttpGet]
    public IActionResult Get()
    {
        List<Post> lista = BD.ListarPosts();
        return Ok(lista);
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id < 1)
        {
            return BadRequest();
        }
        Post u = BD.ObtenerPost(id);
        if (u == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(u);
        }
    }

    [HttpPost]
    public IActionResult Post(Post c)
    {

        if (c.Titulo == null || c.Titulo == "" || c.Imagen == null || c.Imagen == "" || c.Contenido == null || c.Contenido == "" || c.IdUsuario < 1 || c.IdCategoria < 1)
        {
            return BadRequest();
        }

        if (BD.ObtenerUsuario(c.IdUsuario) == null || BD.ObtenerCategoria(c.IdCategoria) == null)
        {
            return NotFound();
        }

        BD.AgregarPost(c);
        return Ok();
    }
    [HttpPut]
    public IActionResult Put(int id, Post c)
    {
        if (id < 1 || c.Titulo == null || c.Titulo == "" || c.Imagen == null || c.Imagen == "" || c.Contenido == null || c.Contenido == "" || c.IdUsuario < 1 || c.IdCategoria < 1)
        {
            return BadRequest();
        }
        if (BD.ObtenerUsuario(c.IdUsuario) == null || BD.ObtenerCategoria(c.IdCategoria) == null || BD.ObtenerPost(id) == null)
        {
            return NotFound();
        }
        BD.UpdatePost(id, c);
        return Ok();
    }
    
    [HttpPatch]
    public IActionResult Patch(int id, Post c)
    {
        if (id < 1 || c.Titulo == null || c.Titulo == "" || c.Imagen == null || c.Imagen == "" || c.Contenido == null || c.Contenido == "" || c.IdUsuario < 1 || c.IdCategoria < 1)
        {
            return BadRequest();
        }
        if (BD.ObtenerUsuario(c.IdUsuario) == null || BD.ObtenerCategoria(c.IdCategoria) == null || BD.ObtenerPost(id) == null)
        {
            return NotFound();
        }
        
        Post.Add(new Post { Titulo = c.Titulo, Contenido = c.Contenido, Imagen = c.Imagen, IdCategoria = c.IdCategoria});
        db.SaveChanges();
        Post postOriginal = BD.ObtenerPost(id);
        int i = 0;

        return Ok(postOriginal);
    }


}
