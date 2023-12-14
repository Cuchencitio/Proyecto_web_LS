using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public class ServicioTipoServicio
{
    static DBContext.Connection db = new DBContext.Connection();

    public ServicioTipoServicio(string conn)
		{
            db = new DBContext.Connection(conn);
		}


    public  IList<Servicios> Listar()
    {
        string query = @"SELECT ID_SERVICIOS, JARDINERIA, ASESORIAS, DET_COMPRAS_ID_DET_COMPRA FROM SERVICIOS";
        DataTable dt = db.Execute(query);

        IList<Servicios> lista = new List<Servicios>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new Servicios()
                     {
                         Id = Convert.ToInt32(rw["ID_SERVICIOS"]),
                         DetalleJardineria = rw["JARDINERIA"].ToString(),
                         DetalleAsesorias = rw["ASESORIAS"].ToString(),
                         Det_compras_Id_Det_compra = Convert.ToInt32(rw["DET_COMPRAS_ID_DET_COMPRA"])
                     }
                     ).ToList();
        }

        return lista;
    }

    public static Servicios? Get(int id)
    {
        string query = @"SELECT ID_SERVICIOS, JARDINERIA, ASESORIAS, DET_COMPRAS_ID_DET_COMPRA FROM SERVICIOS = " + id;
        DataTable dt = db.Execute(query);

        Servicios? obj = new Servicios();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new Servicios()
                   {
                        Id = Convert.ToInt32(rw["ID_SERVICIOS"]),
                         DetalleJardineria = rw["JARDINERIA"].ToString(),
                         DetalleAsesorias = rw["ASESORIAS"].ToString(),
                         Det_compras_Id_Det_compra = Convert.ToInt32(rw["DET_COMPRAS_ID_DET_COMPRA"])
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(Servicios servicio)
    {
        string query = string.Format(@"insert into SERVICIOS(ID_SERVICIOS, JARDINERIA, ASESORIAS, DET_COMPRAS_ID_DET_COMPRA) values ({1}, '{DetalleGenerico}', '{DetalleGenerico}', {1})", servicio.Id, servicio.DetalleJardineria, servicio.DetalleAsesorias, servicio.Det_compras_Id_Det_compra);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM SERVICIOS WHERE ID_SERVICIOS = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(Servicios servicio)
    {

        string query = string.Format(@"UPDATE SERVICIOS SET ID_SERVICIOS = {1}, JARDINERIA = '{DetalleGenerico}', ASESORIAS = '{DetalleGenerico}' DET_COMPRAS_ID_DET_COMPRA = {1} WHERE ID_SERVICIOS = {0};", servicio.Id, servicio.DetalleJardineria, servicio.DetalleAsesorias, servicio.Det_compras_Id_Det_compra);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
        // Compras[index] = compra;
    }
}

//    public static List<Servicios> GetAll() => LServicio;

//    public static Servicios? Get(int id) => LServicio.FirstOrDefault(p => p.Id == id);

//    public static void Add(Servicios servicio)
//    {
//        servicio.Id = nextId++;
//        LServicio.Add(servicio);
//    }

//    public static void Delete(int id)
//    {
//        var servicio = Get(id);
//        if(servicio is null)
//            return;

//        LServicio.Remove(servicio);
//    }

//    public static void Update(Servicios servicio)
//    {
//        var index = LServicio.FindIndex(u => u.Id == servicio.Id);
//        if(index == -1)
//            return;

//        LServicio[index] = servicio;
//    }
//}