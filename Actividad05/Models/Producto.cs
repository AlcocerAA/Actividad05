using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string UnidadMedida { get; set; } = null!;

    public decimal? CostoEstimado { get; set; }

    public decimal StockActual { get; set; }

    public decimal StockMinimo { get; set; }

    public virtual ICollection<FormulaProduccion> FormulaProduccions { get; set; } = new List<FormulaProduccion>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual ICollection<OrdenesProduccion> OrdenesProduccions { get; set; } = new List<OrdenesProduccion>();
}
