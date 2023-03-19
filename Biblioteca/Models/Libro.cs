using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public int? IdAutor { get; set; }

    public int? IdEstado { get; set; }

    public int? IdTipoLibro { get; set; }

    public int? IdCategoriaEdad { get; set; }

    public string Titulo { get; set; } = null!;

    public int? Materia { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual CategoriaEdad? IdCategoriaEdadNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual TipoLibro? IdTipoLibroNavigation { get; set; }

    public virtual Materium? MateriaNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
