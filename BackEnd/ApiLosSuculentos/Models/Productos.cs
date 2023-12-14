namespace ApiLosSuculentos.Models;

public class Productos
{
    public int Id { get; set; }
    public int Valor { get; set; }
    public int Stock { get; set; }
    public int Tipo { get; set; }
    public string? Servicios { get; set; }
    public int Det_compras_Id_Det_compra { get; set; }

}