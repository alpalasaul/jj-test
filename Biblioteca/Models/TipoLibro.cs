using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class TipoLibro
{
    public int IdTipoLibro { get; set; }

    public string NombreTipoLibro { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
