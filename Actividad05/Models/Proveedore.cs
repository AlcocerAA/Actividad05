using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public decimal? CalificacionPromedio { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<EvaluacionesProveedor> EvaluacionesProveedors { get; set; } = new List<EvaluacionesProveedor>();

    public virtual ICollection<MateriasPrima> MateriasPrimas { get; set; } = new List<MateriasPrima>();
}
