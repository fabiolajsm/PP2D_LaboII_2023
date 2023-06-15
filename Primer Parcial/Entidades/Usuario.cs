namespace Entidades;
public abstract class Usuario
{
    public string Nombre { get; }
    public string Apellido { get; }
    public string NombreCompleto { get; }
    public string Email { get; }
    public string Contrasena { get; }

    public Usuario()
    {
        this.Nombre = string.Empty;
        this.Apellido = string.Empty;
        this.NombreCompleto = string.Empty;
        this.Email = string.Empty;
        this.Contrasena = string.Empty;
    }

    public Usuario(string nombre, string apellido, string email, string contrasena) : this()
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.NombreCompleto = $"{Utilidades.Capitalize(this.Nombre)} {Utilidades.Capitalize(this.Apellido)}";
        this.Email = email;
        this.Contrasena = contrasena;
    }
    /// <summary>
    /// Obtiene un mensaje de bienvenida segun el usuario ingresado
    /// </summary>
    public abstract string ObtenerMensajeBienvenida();
}
