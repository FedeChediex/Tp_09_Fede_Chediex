namespace Tp_09_Fede_Chediex.Models;
public class Post
{

    private int _idPost;
    private string _titulo;
    private string _imagen;
    private string _contenido;
    private int _idCategoria;
    private int _idUsuario;

    public Post(string titulo, string imagen, string contenido, int idCategoria, int idUsuario)
    {

        _titulo = titulo;
        _imagen = imagen;
        _contenido = contenido;
        _idCategoria = idCategoria;
        _idUsuario = idUsuario;
    }
    public Post()
    {
        _titulo = "titulo";
        _imagen = "null";
        _contenido = "contenido";
        _idCategoria = 0;
        _idUsuario = 0;
    }

    public int IdPost{
        
        get{
            return _idPost;
        }
        set{
            _idPost = value;
        }

    }
    public string Titulo{
        
        get{
            return _titulo;
        }
        set{
            _titulo = value;
        }

    }
    public string Imagen{
        
        get{
            return _imagen;
        }
        set{
            _imagen = value;
        }

    }
    public string Contenido{
        
        get{
            return _contenido;
        }
        set{
            _contenido = value;
        }

    }

    
    public int IdCategoria{
        
        get{
            return _idCategoria;
        }
        set{
            _idCategoria = value;
        }

    }
    public int IdUsuario{
        
        get{
            return _idUsuario;
        }
        set{
            _idUsuario = value;
        }

    }
   
    
}