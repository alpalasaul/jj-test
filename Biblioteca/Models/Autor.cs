using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string NombreAutor { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
