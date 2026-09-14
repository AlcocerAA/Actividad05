using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class MateriasPrima
{
    public int IdMateriaPrima { get; set; }

    public int? IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string UnidadMedida { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public decimal StockActual { get; set; }

    public decimal StockMinimo { get; set; }

    public virtual ICollection<FormulaProduccion> FormulaProduccions { get; set; } = new List<FormulaProduccion>();

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
