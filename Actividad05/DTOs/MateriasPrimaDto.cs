namespace Actividad05.DTOs;

public class MateriasPrimaCreateUpdateDto
{
    public int? IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string UnidadMedida { get; set; } = null!;
    public decimal PrecioUnitario { get; set; }
    public decimal StockActual { get; set; }
    public decimal StockMinimo { get; set; }
}

public class MateriasPrimaResponseDto
{
    public int IdMateriaPrima { get; set; }
    public int? IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string UnidadMedida { get; set; } = null!;
    public decimal PrecioUnitario { get; set; }
    public decimal StockActual { get; set; }
    public decimal StockMinimo { get; set; }
}
