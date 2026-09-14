using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class OrdenesProduccion
{
    public int IdOrden { get; set; }

    public int IdProducto { get; set; }

    public string LineaProduccion { get; set; } = null!;

    public string? Responsable { get; set; }

    public decimal CantidadPlaneada { get; set; }

    public decimal CantidadProducida { get; set; }

    public DateOnly FechaPlanificada { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<InspeccionesCalidad> InspeccionesCalidads { get; set; } = new List<InspeccionesCalidad>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
