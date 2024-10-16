// Profesion.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.Entities;

public partial class Profesion
{
    [Display(Name = "Id que se asignara a la profesión")]
    public int Id { get; set; }

    [Display(Name = "Nombre de la Profesión")]
    public string Nom { get; set; } = null!;

    [Display(Name = "Descripción de la profesión")]
    public string? Des { get; set; }

    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();
}