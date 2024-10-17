// Persona.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace personapi_dotnet.Models.Entities;

public partial class Persona
{
    [Display(Name = "Cedula de la persona")]
    public long Cc { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    [StringLength(1, ErrorMessage = "El campo Género debe contener solo un carácter.")]
    public string Genero { get; set; } = null!;

    public int? Edad { get; set; }

    [JsonIgnore]  // Evita la serialización de esta propiedad
    public virtual ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();

    [JsonIgnore]  // Evita la serialización de esta propiedad
    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
}
