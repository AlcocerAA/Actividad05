namespace Actividad05.DTOs;

public class InspeccionesCalidadCreateUpdateDto
{
    public int IdOrden { get; set; }
    public string Inspector { get; set; } = null!;
    public string Etapa { get; set; } = null!;
    public DateTime FechaInspeccion { get; set; }
    public decimal CantidadInspeccionada { get; set; }
    public decimal CantidadDefectuosa { get; set; }
    public string? Observaciones { get; set; }
}

public class InspeccionesCalidadResponseDto
{
    public int IdInspeccion { get; set; }
    public int IdOrden { get; set; }
    public string Inspector { get; set; } = null!;
    public string Etapa { get; set; } = null!;
    public DateTime FechaInspeccion { get; set; }
    public decimal CantidadInspeccionada { get; set; }
    public decimal CantidadDefectuosa { get; set; }
    public string? Observaciones { get; set; }
}
