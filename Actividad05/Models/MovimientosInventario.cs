using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class MovimientosInventario
{
    public int IdMovimiento { get; set; }

    public int? IdMateriaPrima { get; set; }

    public int? IdProducto { get; set; }

    public int? IdOrden { get; set; }

    public decimal Cantidad { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string? Responsable { get; set; }

    public virtual MateriasPrima? IdMateriaPrimaNavigation { get; set; }

    public virtual OrdenesProduccion? IdOrdenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
