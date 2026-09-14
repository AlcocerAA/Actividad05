using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class EvaluacionesProveedor
{
    public int IdEvaluacion { get; set; }

    public int IdProveedor { get; set; }

    public DateOnly FechaEvaluacion { get; set; }

    public short Puntualidad { get; set; }

    public short CalidadInsumo { get; set; }

    public short PrecioCompetitivo { get; set; }

    public string? Observaciones { get; set; }

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}
