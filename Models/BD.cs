namespace Tp_09_Fede_Chediex.Models;
using System.Data.SqlClient;
using Dapper;
//polygon(0 40%, 100% 40%, 100% 85%, 95% 85%, 95% 85%, 85% 85%, 85% 85%, 8% 85%, 0 70%);
public class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-009;DataBase=Tp_08;Trusted_Connection=True";

    public static List<Categoria> ListarCategorias()
    {
        List<Categoria> lista = new List<Categoria>();
        string sql = "SELECT * FROM Categoria";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {

            lista = bd.Query<Categoria>(sql).ToList();
        }
        return lista;
    }
    public static List<Post> ListarPosts()
    {
        List<Post> ListaPosts = new List<Post>();
        string sql = "SELECT * FROM Post";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            ListaPosts = bd.Query<Post>(sql).ToList();
        }
        return ListaPosts;
    }
    public static List<Comentario> ListarComentarios(int IdPost)
    {
        List<Comentario> ListaComentarios = new List<Comentario>();
        string sql = "SELECT * FROM comentario WHERE IdPost = @uIdPost";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            ListaComentarios= bd.Query<Comentario>(sql, new { uIdPost =  IdPost }).ToList();
        }
        return ListaComentarios;
    }
    public static List<Usuario> ListarUsuarios()
    {
        List<Usuario> lista = new List<Usuario>();
        string sql = "SELECT * FROM Usuario";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {

            lista = bd.Query<Usuario>(sql).ToList();
        }
        return lista;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    //OBTENER//
    public static Categoria ObtenerCategoria(int IdCategoria)
    {
            Categoria cat;
            string SQL = "SELECT * FROM Categoria WHERE IdCategoria = @pIdCategoria ";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                cat = db.QueryFirstOrDefault<Categoria>(SQL, new{pIdCategoria = IdCategoria});
                
            }
            return cat;
    }

    public static Usuario ObtenerUsuario(int IdUsuario)
        {
            Usuario user;
            string SQL = "SELECT * FROM Usuario WHERE IdUsuario = @pIdUsuario ";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                user= db.QueryFirstOrDefault<Usuario>(SQL, new{pIdUsuario = IdUsuario});
            }
            return user;
        }
    public static Post ObtenerPost(int IdPost)
        {
            Post publicacion;
            string SQL = "SELECT * FROM Post WHERE IdPost = @pIdPost ";
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                publicacion= db.QueryFirstOrDefault<Post>(SQL, new{pIdPost = IdPost});
            }
            return publicacion;
        }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////
    //INSERT
    public static void IngresarUsuario(Usuario usuario)
    {
        
        string sql = "INSERT INTO Usuario(Nombre, Contrasenia) VALUES (@pNombre, @pContrasenia)";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {

            bd.Execute(sql, new{pNombre = usuario.Nombre, pContrasenia = usuario.Contrasenia});
        }
    }
    public static void AgregarPost(Post post)
    {
        
        string sql = "INSERT INTO Post(Titulo, Imagen, Contenido, IdCategoria, IdUsuario) VALUES (@pTitulo, @pImagen, @pContenido, @pIdCategoria, @pIdUsuario)";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {

            bd.Execute(sql, new{pTitulo = post.Titulo, pImagen = post.Imagen, pContenido = post.Contenido,  pIdCategoria = post.IdCategoria, pIdUsuario = post.IdUsuario});
        }
    }

    public static void AgregarComentario(Comentario coment)
    {
        
        string sql = "INSERT INTO comentario(Contenido, Imagen, Tiempo, IdPost, IdUsuario) VALUES (@pContenido, @pImagen, @pTiempo, @pIdPost, @pIdUsuario)";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {

            bd.Execute(sql, new{pContenido = coment.Contenido, pImagen = coment.Imagen, pTiempo = coment.Tiempo,  pIdPost = coment.IdPost, pIdUsuario = coment.IdUsuario});
        }
    }
}