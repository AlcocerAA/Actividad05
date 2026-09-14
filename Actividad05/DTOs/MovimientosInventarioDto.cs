namespace Actividad05.DTOs;

public class MovimientosInventarioCreateUpdateDto
{
    public int? IdMateriaPrima { get; set; }
    public int? IdProducto { get; set; }
    public int? IdOrden { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public string? Responsable { get; set; }
}

public class MovimientosInventarioResponseDto
{
    public int IdMovimiento { get; set; }
    public int? IdMateriaPrima { get; set; }
    public int? IdProducto { get; set; }
    public int? IdOrden { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public string? Responsable { get; set; }
}
