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
    public IActionResult Patch(int id, Post n)
    {
        if (id < 1 || n.IdUsuario < 1 || n.IdCategoria < 1)
        {
            return BadRequest();
        }
        if (BD.ObtenerUsuario(n.IdUsuario) == null || BD.ObtenerCategoria(n.IdCategoria) == null || BD.ObtenerPost(id) == null)
        {
            return NotFound();
        }

        Post o = BD.ObtenerPost(id);

        if (n.Titulo != null && n.Titulo != "" && n.Titulo != o.Titulo)
        {
            o.Titulo = n.Titulo;
        }
        if (n.Imagen != null && n.Imagen != "" && n.Imagen != o.Imagen)
        {
            o.Imagen = n.Imagen;
        }
        if (n.Contenido == null && n.Contenido != "" && n.Contenido != o.Contenido)
        {
            o.Contenido = n.Contenido;
        }
        if(n.IdCategoria != o.IdCategoria)
        {
            o.IdCategoria = n.IdCategoria;
        }

        BD.UpdatePost(id, o);
        
        return Ok();
    }


}
