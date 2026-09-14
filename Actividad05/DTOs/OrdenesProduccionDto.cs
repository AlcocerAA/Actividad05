namespace Actividad05.DTOs;

public class OrdenesProduccionCreateUpdateDto
{
    public int IdProducto { get; set; }
    public string LineaProduccion { get; set; } = null!;
    public string? Responsable { get; set; }
    public decimal CantidadPlaneada { get; set; }
    public decimal CantidadProducida { get; set; }
    public DateOnly FechaPlanificada { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaEntrega { get; set; }
}

public class OrdenesProduccionResponseDto
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
}
