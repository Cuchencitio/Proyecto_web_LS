namespace ApiLosSuculentos.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Rut { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Contrasenia { get; set; }
    public string? Telefono { get; set; }   
    public int Estado { get; set; }

}