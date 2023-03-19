using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class CarreraJj
{
    public int IdCarrera { get; set; }

    public int IdFacultad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<EstudianteJj> EstudianteJjs { get; } = new List<EstudianteJj>();

    public virtual FacultadJj IdFacultadNavigation { get; set; } = null!;
}
