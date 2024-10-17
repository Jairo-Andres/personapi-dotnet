// Estudio.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace personapi_dotnet.Models.Entities;

public partial class Estudio
{
    [Display(Name = "Id de la profesión existente")]
    public int IdProf { get; set; }

    [Display(Name = "Cedula de la persona existente")]
    public long CcPer { get; set; }

    public DateOnly? Fecha { get; set; }

    [Display(Name = "Nombre de la Universidad")]
    public string? Univer { get; set; }

    [JsonIgnore]  // Evita la serialización de esta propiedad
    public virtual Persona? CcPerNavigation { get; set; }

    [JsonIgnore]  // Evita la serialización de esta propiedad
    public virtual Profesion? IdProfNavigation { get; set; }
}