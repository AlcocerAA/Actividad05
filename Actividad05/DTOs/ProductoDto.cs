namespace Actividad05.DTOs;

public class ProductoCreateUpdateDto
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string UnidadMedida { get; set; } = null!;
    public decimal? CostoEstimado { get; set; }
    public decimal StockActual { get; set; }
    public decimal StockMinimo { get; set; }
}

public class ProductoResponseDto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string UnidadMedida { get; set; } = null!;
    public decimal? CostoEstimado { get; set; }
    public decimal StockActual { get; set; }
    public decimal StockMinimo { get; set; }
}
