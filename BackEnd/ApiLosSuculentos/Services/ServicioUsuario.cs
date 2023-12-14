using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public class ServicioUsuario
{
    static DBContext.Connection db = new DBContext.Connection();

     public ServicioUsuario(string conn)
		{
            db = new DBContext.Connection(conn);
		}

    public  List<Usuario> Listar()
    {
        string query = @"SELECT ID_USUARIOS, NOMBRE, APELLIDO, RUT, EMAIL, DIRECCION, NOMBREUSUARIO, CONTRASENA, TELEFONO, ESTADO FROM USUARIOS";
        DataTable dt = db.Execute(query);

        List<Usuario> lista = new List<Usuario>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new Usuario()
                     {
                         Id = Convert.ToInt32(rw["ID_USUARIOS"]),
                         Nombre = rw["NOMBRE"].ToString(),
                         Apellido = rw["APELLIDO"].ToString(),
                         Rut = rw["RUT"].ToString(),
                         Email = rw["EMAIL"].ToString(),
                         Direccion = rw["DIRECCION"].ToString(),
                         NombreUsuario = rw["NOMBREUSUARIO"].ToString(),
                         Contrasenia = rw["CONTRASENA"].ToString(),
                         Telefono = rw["TELEFONO"].ToString(),
                         Estado = Convert.ToInt32(rw["ESTADO"])
                     }
                     ).ToList();
        }

        return lista;
    }

    public static Usuario? Get(int id)
    {
        string query = @"SELECT ID_USUARIOS, NOMBRE, APELLIDO, RUT, EMAIL, DIRECCION, NOMBREUSUARIO, CONTRASENIA, TELEFONO, ESTADO FROM USUARIOS WHERE ID_USUARIOS = " + id;
        DataTable dt = db.Execute(query);

        Usuario? obj = new Usuario();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new Usuario()
                   {
                         Id = Convert.ToInt32(rw["ID_USUARIOS"]),
                         Nombre = rw["NOMBRE"].ToString(),
                         Apellido = rw["APELLIDO"].ToString(),
                         Rut = rw["RUT"].ToString(),
                         Email = rw["EMAIL"].ToString(),
                         Direccion = rw["DIRECCION"].ToString(),
                         NombreUsuario = rw["NOMBREUSUARIO"].ToString(),
                         Contrasenia = rw["CONTRASENA"].ToString(),
                         Telefono = rw["TELEFONO"].ToString(),
                         Estado = Convert.ToInt32(rw["ESTADO"])
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(Usuario usuario)
    {
        string query = string.Format(@"insert into USUARIOS(ID_USUARIOS, NOMBRE, APELLIDO, RUT, EMAIL, DIRECCION, NOMBREUSUARIO, CONTRASENIA, TELEFONO, ESTADO) values ({2}, '{CESAR}', '{MAUREIRA}', '{123456789}', '{CORREO@CORREO.CL}', '{DIRECCION 1234}', '{CESMAUREIRA}', '{CONTRA123}', '{12345678}', {1})", usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Rut, usuario.Email, usuario.Direccion, usuario.NombreUsuario, usuario.Contrasenia, usuario.Telefono, usuario.Estado);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM USUARIOS WHERE ID_USUSARIOS = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(Usuario usuario)
    {

        string query = string.Format(@"UPDATE USUARIOS SET ID_USUARIOS = {1}, NOMBRE = '{CESAR}', APELLIDO = '{MAUREIRA}', RUT = '{123456789}', EMAIL = '{CORREO@CORREO.CL}', DIRECCION = '{DIRECCION 1234}', NOMBREUSUARIO = '{CESMAUREIRA}', CONTRASENIA = '{CONTRA123}', TELEFONO = '{12345678}', ESTADO = {1} WHERE ID = {0};", usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Rut, usuario.Email, usuario.Direccion, usuario.NombreUsuario, usuario.Contrasenia, usuario.Telefono, usuario.Estado);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
        // Compras[index] = compra;
    }
}

//    public static List<Usuario> GetAll() => Usuarios;

//    public static Usuario? Get(int id) => Usuarios.FirstOrDefault(p => p.Id == id);

//    public static void Add(Usuario usuario)
//    {
//        usuario.Id = nextId++;
//        Usuarios.Add(usuario);
//    }

//    public static void Delete(int id)
//    {
//        var usuario = Get(id);
//        if(usuario is null)
//            return;

//        Usuarios.Remove(usuario);
//    }

//    public static void Update(Usuario usuario)
//    {
//        var index = Usuarios.FindIndex(u => u.Id == usuario.Id);
//        if(index == -1)
//            return;

//        Usuarios[index] = usuario;
//    }
//}