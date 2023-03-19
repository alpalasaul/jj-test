using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string NombreMateria { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
