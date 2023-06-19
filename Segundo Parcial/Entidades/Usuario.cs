namespace Entidades;
public abstract class Usuario
{
    public int Id { get; }
    public string Nombre { get; }
    public string Apellido { get; }
    public string NombreCompleto { get; }
    public string Email { get; }
    public string Contrasena { get; }
    public TipoUsuario TipoDeUsuario { get; }

    public Usuario()
    {
        Id = -1;
        this.Nombre = string.Empty;
        this.Apellido = string.Empty;
        this.NombreCompleto = string.Empty;
        this.Email = string.Empty;
        this.Contrasena = string.Empty;
        this.TipoDeUsuario = TipoUsuario.Cliente;
    }
    public Usuario(int id, string nombre, string apellido, string email, string contrasena, TipoUsuario tipoDeUsuario) : this()
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.NombreCompleto = $"{this.Nombre.Capitalize()} {this.Apellido.Capitalize()}";
        this.Email = email;
        this.Contrasena = contrasena;
        this.TipoDeUsuario = tipoDeUsuario;
    }
    /// <summary>
    /// Obtiene un mensaje de bienvenida segun el usuario ingresado
    /// </summary>
    public abstract string ObtenerMensajeBienvenida();
}
