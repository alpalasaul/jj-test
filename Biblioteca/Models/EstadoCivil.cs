using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class EstadoCivil
{
    public int IdEstadoCivil { get; set; }

    public string NombreEstadoCivil { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
