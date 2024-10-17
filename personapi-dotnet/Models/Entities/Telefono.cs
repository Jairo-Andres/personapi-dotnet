// Telefono.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace personapi_dotnet.Models.Entities;

public partial class Telefono
{
    [Display(Name = "Número de Teléfono")]
    public string Num { get; set; } = null!;

    [Display(Name = "Operador")]
    public string Oper { get; set; } = null!;

    [Display(Name = "Dueño del Teléfono CC")]
    public long Duenio { get; set; }

    [JsonIgnore]  // Evita la serialización de esta propiedad
    public virtual Persona? DuenioNavigation { get; set; }
}
