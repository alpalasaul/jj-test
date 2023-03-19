using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class FacultadJj
{
    public int IdFacultad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<CarreraJj> CarreraJjs { get; } = new List<CarreraJj>();
}
