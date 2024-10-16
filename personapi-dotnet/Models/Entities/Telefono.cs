// Telefono.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.Entities;

public partial class Telefono
{
    [Display(Name = "Número de Teléfono")]
    public string Num { get; set; } = null!;

    [Display(Name = "Operador")]
    public string Oper { get; set; } = null!;

    [Display(Name = "Dueño del Teléfono CC")]
    public long Duenio { get; set; }

    public virtual Persona? DuenioNavigation { get; set; }
}
