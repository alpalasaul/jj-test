using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
