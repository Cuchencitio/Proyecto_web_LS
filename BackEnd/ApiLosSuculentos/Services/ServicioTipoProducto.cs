using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public class ServicioTipoProducto
{
    static DBContext.Connection db = new DBContext.Connection();

    public ServicioTipoProducto(string conn)
		{
            db = new DBContext.Connection(conn);
		}

    public  List<TipoProducto> Listar()
    {
        string query = @"SELECT ID_TIPO, INTERIOR, EXTERIOR, SUSTRATOS, PRODUCTOS_ID_PRODUCTO FROM TIPO_PRODUCTOS";
        DataTable dt = db.Execute(query);

        List<TipoProducto> lista = new List<TipoProducto>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new TipoProducto()
                     {
                         Id = Convert.ToInt32(rw["ID_TIPO"]),
                         DetalleInterior = rw["INTERIOR"].ToString(),
                         DetalleExterior = rw["EXTERIOR"].ToString(),
                         DetalleSustrato = rw["SUSTRATOS"].ToString(),
                         Productos_Id_Producto = Convert.ToInt32(rw["PRODUCTOS_ID_PRODUCTO"])
                     }
                     ).ToList();
        }

        return lista;
    }

    public static TipoProducto? Get(int id)
    {
        string query = @"SELECT ID_TIPO, INTERIOR, EXTERIOR, SUSTRATOS, PRODUCTOS_ID_PRODUCTO FROM TIPO_PRODUCTOS WHERE ID_TIPO =" + id;
        DataTable dt = db.Execute(query);

        TipoProducto? obj = new TipoProducto();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new TipoProducto()
                   {
                         Id = Convert.ToInt32(rw["ID_TIPO"]),
                         DetalleInterior = rw["INTERIOR"].ToString(),
                         DetalleExterior = rw["EXTERIOR"].ToString(),
                         DetalleSustrato = rw["SUSTRATOS"].ToString(),
                         Productos_Id_Producto = Convert.ToInt32(rw["PRODUCTOS_ID_PRODUCTO"])
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(TipoProducto tipoproducto)
    {
        string query = string.Format(@"insert into TIPO_PRODUCTOS(ID_TIPO, INTERIOR, EXTERIOR, SUSTRATOS, PRODUCTOS_ID_PRODUCTO) values ({1}, '{DetalleGenerico}', '{DetalleGenerico}', '{DetalleGenerico}', {1})", tipoproducto.Id, tipoproducto.DetalleInterior, tipoproducto.DetalleExterior, tipoproducto.DetalleSustrato, tipoproducto.Productos_Id_Producto);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM TIPO_PRODUCTOS WHERE ID_TIPO = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(TipoProducto tipoproducto)
    {

        string query = string.Format(@"UPDATE TIPO_PRODUCTOS SET ID_TIPO = {1}, INTERIOR = '{DetalleGenerico}', EXTERIOR = '{DetalleGenerico}', SUSTRATOS = '{DetalleGenerico}', PRODUCTOS_ID_PRODUCTO = {1} WHERE ID_TIPO = {0};", tipoproducto.Id, tipoproducto.DetalleInterior, tipoproducto.DetalleExterior, tipoproducto.DetalleSustrato, tipoproducto.Productos_Id_Producto);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
        // Compras[index] = compra;
    }
}
//    public static List<TipoProducto> GetAll() => TipoProductos;

//    public static TipoProducto? Get(int id) => TipoProductos.FirstOrDefault(p => p.Id == id);

//    public static void Add(TipoProducto tipoProducto)
//    {
//        tipoProducto.Id = nextId++;
//        TipoProductos.Add(tipoProducto);
//    }

//    public static void Delete(int id)
//    {
//        var tipoProducto = Get(id);
//        if(tipoProducto is null)
//            return;

//        TipoProductos.Remove(tipoProducto);
//    }

//    public static void Update(TipoProducto tipoProducto)
//    {
//        var index = TipoProductos.FindIndex(u => u.Id == tipoProducto.Id);
//        if(index == -1)
//            return;

//        TipoProductos[index] = tipoProducto;
//    }
//}