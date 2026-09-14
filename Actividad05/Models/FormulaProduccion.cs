using System;
using System.Collections.Generic;

namespace Actividad05.Models;

public partial class FormulaProduccion
{
    public int IdProducto { get; set; }

    public int IdMateriaPrima { get; set; }

    public decimal CantidadRequerida { get; set; }

    public virtual MateriasPrima IdMateriaPrimaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
