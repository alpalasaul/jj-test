using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models;

public partial class EstudianteJj
{
    public int IdEstudiante { get; set; }
    [Display(Name = "Cedula")]
    [Required(ErrorMessage = "El campo cedula es Obligatorio")]
    public string Cedula { get; set; } = null!;
    [Required]
    [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Solo debe ingresar letras, No números")]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Direccion { get; set; } = null!;
    [Required]
    
    public string Email { get; set; } = null!;
    [Required]
    [RegularExpression("^[0-9]+$", ErrorMessage = "Solo debe ingresar letras, No números")]
    public string? Telefono { get; set; }
    [Required]
    public int IdCarrera { get; set; }
    [Required]
    public string Estado { get; set; } = null!;

    public virtual CarreraJj IdCarreraNavigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
