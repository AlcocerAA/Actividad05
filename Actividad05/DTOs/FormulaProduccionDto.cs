namespace Actividad05.DTOs;

public class FormulaProduccionCreateDto
{
    public int IdProducto { get; set; }
    public int IdMateriaPrima { get; set; }
    public decimal CantidadRequerida { get; set; }
}

public class FormulaProduccionUpdateDto
{
    public decimal CantidadRequerida { get; set; }
}

public class FormulaProduccionResponseDto
{
    public int IdProducto { get; set; }
    public int IdMateriaPrima { get; set; }
    public decimal CantidadRequerida { get; set; }
}