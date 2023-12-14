using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public class ServicioDetalleCompra
{
    static DBContext.Connection db = new DBContext.Connection();

    public ServicioDetalleCompra(string conn)
		{
            db = new DBContext.Connection(conn);
		}
    
    public  IList<DetalleCompra> Listar()
    {
        string query = @"SELECT ID_DET_COMPRAS, COMPRAS_ID_COMPRAS FROM DET_COMPRAS";
        DataTable dt = db.Execute(query);

        IList<DetalleCompra> lista = new List<DetalleCompra>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new DetalleCompra()
                     {
                         Id_det_compras = Convert.ToInt32(rw["ID_DET_COMPRAS"]),
                         Compras_id_Compras = Convert.ToInt32(rw["COMPRAS_ID_COMPRAS"]),
                     }
                     ).ToList();
        }

        return lista;
    }

    public static DetalleCompra? Get(int id)
    {
        string query = @"SELECT ID_DET_COMPRAS, COMPRAS_ID_COMPRAS FROM DET_COMPRAS WHERE ID_DET_COMPRAS = " + id;
        DataTable dt = db.Execute(query);

        DetalleCompra? obj = new DetalleCompra();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new DetalleCompra()
                   {
                       Id_det_compras = Convert.ToInt32(rw["ID_DET_COMPRAS"]),
                       Compras_id_Compras = Convert.ToInt32(rw["COMPRAS_ID_COMPRAS"]),
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(DetalleCompra detalle)
    {
        string query = string.Format(@"insert into DET_COMPRAS(ID_DET_COMPRAS, COMPRAS_ID_COMPRAS) values ({1}, {1})", detalle.Id_det_compras, detalle.Compras_id_Compras);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM DET_COMPRAS WHERE ID_DET_COMPRAS = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(DetalleCompra detalle)
    {

        string query = string.Format(@"UPDATE DET_COMPRAS SET ID_DET_COMPRAS = {1}, COMPRAS_ID_COMPRAS = {2} WHERE ID = {0};", detalle.Id_det_compras, detalle.Compras_id_Compras);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
        // Compras[index] = compra;
    }
}

//    public static List<DetalleCompra> GetAll() => DetalleCompras;

//    public static DetalleCompra? Get(int id) => DetalleCompras.FirstOrDefault(p => p.Id == id);

//    public static void Add(DetalleCompra detalleCompra)
//    {
//        detalleCompra.Id = nextId++;
//        DetalleCompras.Add(detalleCompra);
//    }

//    public static void Delete(int id)
//    {
//        var detalleCompra = Get(id);
//        if(detalleCompra is null)
//            return;

//        DetalleCompras.Remove(detalleCompra);
//    }

//    public static void Update(DetalleCompra detalleCompra)
//    {
//        var index = DetalleCompras.FindIndex(u => u.Id == detalleCompra.Id);
//        if(index == -1)
//            return;

//        DetalleCompras[index] = detalleCompra;
//    }
//}