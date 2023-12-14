namespace ApiLosSuculentos.Models;

public class Compra
{
    public int Id { get; set; }
    public int Precio { get; set; }
    public int Cantidad { get; set; }
    public string? FormadePago { get; set; }
    public string? DetalleEnvio { get; set; }
    public int Usuarios_Id_Usuario { get; set; }
}