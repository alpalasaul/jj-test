using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string NombreGenero { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
