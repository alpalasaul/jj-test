using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public partial class UsersRol
{
    public int IdUsersRol { get; set; }

    public string NombreUsers { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
