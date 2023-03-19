using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class User
{
    public int IdUsuario { get; set; }

    public int? IdGenero { get; set; }

    public int? IdEstadoCivil { get; set; }

    public int? IdUsersRol { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string CedulaUsuario { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Direccion { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual UsersRol? IdUsersRolNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
