using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public class ServicioCompra
{   

    static DBContext.Connection db = new DBContext.Connection();

     public ServicioCompra(string conn)
		{
            db = new DBContext.Connection(conn);
		}
    
    public IList<Compra> Listar()
    {
        string query = @"SELECT ID_COMPRAS, PRECIO, CANTIDAD, FORMA_DE_PAGO, ENVIO, USUARIOS_ID_USUARIO FROM COMPRAS";
        DataTable dt = db.Execute(query);

        IList<Compra> lista = new List<Compra>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new Compra()
                     {
                         Id = Convert.ToInt32(rw["ID_COMPRAS"]),
                         Precio = Convert.ToInt32(rw["PRECIO"]),
                         Cantidad = Convert.ToInt32(rw["CANTIDAD"]),
                         FormadePago = rw["FORMA_DE_PAGO"].ToString(),
                         DetalleEnvio = rw["ENVIO"].ToString(),
                         Usuarios_Id_Usuario = Convert.ToInt32(rw["USUARIOS_ID_USUARIO"])
                     }
                     ).ToList();
        }

        return lista;
    }

    public static Compra? Get(int id)
    {
        string query = @"SELECT ID_COMPRAS, PRECIO, CANTIDAD, FORMA_DE_PAGO, ENVIO, USUARIOS_ID_USUARIO FROM COMPRAS WHERE ID_COMPRAS = " + id;
        DataTable dt = db.Execute(query);

        Compra? obj = new Compra();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new Compra()
                   {
                        Id = Convert.ToInt32(rw["ID_COMPRAS"]),
                         Precio = Convert.ToInt32(rw["PRECIO"]),
                         Cantidad = Convert.ToInt32(rw["CANTIDAD"]),
                         FormadePago = rw["FORMA_DE_PAGO"].ToString(),
                         DetalleEnvio = rw["ENVIO"].ToString(),
                         Usuarios_Id_Usuario = Convert.ToInt32(rw["USUARIOS_ID_USUARIO"])
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(Compra compra)
    {
        string query = string.Format(@"insert into COMPRAS(ID_COMPRAS, PRECIO, CANTIDAD, FORMA_DE_PAGO, ENVIO, USUARIOS_ID_USUARIO) values ({2}, {10000}, {1}, '{Debito}', '{Envio gratis}', {1})", compra.Id, compra.Precio, compra.Cantidad, compra.FormadePago, compra.DetalleEnvio, compra.Usuarios_Id_Usuario);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM COMPRAS WHERE ID_COMPRAS = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(Compra compra)
    {

        string query = string.Format(@"UPDATE COMPRAS SET ID_COMPRAS = {1}, PRECIO = {2}, CANTIDAD = {3}, FORMA_DE_PAGO = '{Debito}', ENVIO = '{Envio Gratis}', USUARIOS_ID_USUARIO = '{1}' WHERE ID_COMPRAS = {0};", compra.Id, compra.Precio, compra.Cantidad, compra.FormadePago, compra.DetalleEnvio, compra.Usuarios_Id_Usuario);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
       // Compras[index] = compra;
    }
}