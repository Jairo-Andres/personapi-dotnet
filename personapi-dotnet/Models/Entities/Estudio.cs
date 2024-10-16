﻿// Estudio.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    public virtual Persona? CcPerNavigation { get; set; }

    public virtual Profesion? IdProfNavigation { get; set; }
}