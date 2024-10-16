// Persona.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.Entities;

public partial class Persona
{
    [Display(Name = "Cedula de la persona")]
    public long Cc { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int? Edad { get; set; }

    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();

    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
}
