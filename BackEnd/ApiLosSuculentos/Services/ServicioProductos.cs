using ApiLosSuculentos.Models;
using System;
using System.Data;
namespace ApiLosSuculentos.Services;

public  class ServicioProductos
{
    static DBContext.Connection db = new DBContext.Connection();

    public ServicioProductos(string conn)
		{
            db = new DBContext.Connection(conn);
		}

    public IList<Productos> Listar()
    {
        string query = @"SELECT ID_PRODUCTOS, VALOR, STOCK, TIPO, SERVICIOS, DET_COMPRAS_ID_DET_COMPRA FROM PRODUCTOS";
        DataTable dt = db.Execute(query);

        IList<Productos> lista = new List<Productos>();
        if (dt.Rows.Count > 0)
        {
            lista = (from DataRow rw in dt.Rows
                     select new Productos()
                     {
                         Id= Convert.ToInt32(rw["ID_PRODUCTOS"]),
                         Valor = Convert.ToInt32(rw["VALOR"]),
                         Stock = Convert.ToInt32(rw["STOCK"]),
                         Tipo = Convert.ToInt32(rw["TIPO"]),
                         Servicios = rw["FORMA_DE_PAGO"].ToString(),
                         Det_compras_Id_Det_compra = Convert.ToInt32(rw["DET_COMPRAS_ID_DET_COMPRA"])
                     }
                     ).ToList();
        }

        return lista;
    }

    public static Productos? Get(int id)
    {
        string query = @"SELECT ID_PRODUCTOS, VALOR, STOCK, TIPO, SERVICIOS, DET_COMPRAS_ID_DET_COMPRA FROM PRODUCTOS WHERE ID_PRODUCTOS = " + id;
        DataTable dt = db.Execute(query);

        Productos? obj = new Productos();
        if (dt.Rows.Count > 0)
        {
            obj = (from DataRow rw in dt.Rows
                   select new Productos()
                   {
                        Id= Convert.ToInt32(rw["ID_PRODUCTOS"]),
                         Valor = Convert.ToInt32(rw["VALOR"]),
                         Stock = Convert.ToInt32(rw["STOCK"]),
                         Tipo = Convert.ToInt32(rw["TIPO"]),
                         Servicios = rw["FORMA_DE_PAGO"].ToString(),
                         Det_compras_Id_Det_compra = Convert.ToInt32(rw["DET_COMPRAS_ID_DET_COMPRA"])
                   }
                     ).FirstOrDefault();
        }

        return obj;
    }


    public static void Add(Productos producto)
    {
        string query = string.Format(@"insert into PRODUCTOS(ID_PRODUCTOS, VALOR, STOCK, TIPO, SERVICIOS, DET_COMPRAS_ID_DET_COMPRA) values ({1}, {10000}, {1}, {1}, '{SERVICIO}', {1})", producto.Id, producto.Valor, producto.Stock, producto.Tipo, producto.Servicios, producto.Det_compras_Id_Det_compra);
        DataTable dt = db.Execute(query);

        //compra.Id = nextId++;
        //Compras.Add(compra);
    }

    public static void Delete(int id)
    {

        string query = string.Format(@"DELETE FROM PRODUCTOS WHERE ID_PRODUCTOS = {0}", id);
        DataTable dt = db.Execute(query);
        //var compra = Get(id);
        //if(compra is null)
        //    return;

        //Compras.Remove(compra);
    }

    public static void Update(Productos producto)
    {

        string query = string.Format(@"UPDATE PRUDUCTOS SET ID_PRODUCTOS = {1}, VALOR = {2}, STOCK = {3}, TIPO = {1}, SERVICIOS = {SERVICIO}, DET_COMPRAS_ID_DET_COMPRA = {1} WHERE ID_PRODUCTOS = {0};", producto.Id, producto.Valor, producto.Stock, producto.Tipo, producto.Servicios, producto.Det_compras_Id_Det_compra);
        DataTable dt = db.Execute(query);
        //var index = Compras.FindIndex(u => u.Id == compra.Id);
        //if(index == -1)
        // Compras[index] = compra;
    }
}

//    public static List<Productos> GetAll() => LProductos;

//    public static Productos? Get(int id) => LProductos.FirstOrDefault(p => p.Id == id);

//    public static void Add(Productos productos)
//    {
//        productos.Id = nextId++;
//        LProductos.Add(productos);
//    }

//    public static void Delete(int id)
//    {
//        var productos = Get(id);
//        if(productos is null)
//            return;

//        LProductos.Remove(productos);
//    }

//    public static void Update(Productos productos)
//    {
//        var index = LProductos.FindIndex(u => u.Id == productos.Id);
//        if(index == -1)
//            return;

//        LProductos[index] = productos;
//    }
//}