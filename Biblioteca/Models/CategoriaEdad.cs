using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class CategoriaEdad
{
    public int IdCategoriaEdad { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
