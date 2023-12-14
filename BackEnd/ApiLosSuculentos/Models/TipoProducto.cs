namespace ApiLosSuculentos.Models;

public class TipoProducto
{
    public int Id { get; set; }
    public string? DetalleInterior { get; set; }
    public string? DetalleExterior { get; set; }
    public string? DetalleSustrato { get; set; }
    public int Productos_Id_Producto { get; set; }
}