using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdLibro { get; set; }

    public int IdEstudiante { get; set; }

    public DateTime FechaPrestamo { get; set; }

    public string TiempoPrestamo { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public virtual EstudianteJj IdEstudianteNavigation { get; set; } = null!;

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual User? IdUsuarioNavigation { get; set; }
}
