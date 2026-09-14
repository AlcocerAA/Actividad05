namespace Actividad05.DTOs;

public class EvaluacionesProveedorCreateUpdateDto
{
    public int IdProveedor { get; set; }
    public DateOnly FechaEvaluacion { get; set; }
    public short Puntualidad { get; set; }
    public short CalidadInsumo { get; set; }
    public short PrecioCompetitivo { get; set; }
    public string? Observaciones { get; set; }
}

public class EvaluacionesProveedorResponseDto
{
    public int IdEvaluacion { get; set; }
    public int IdProveedor { get; set; }
    public DateOnly FechaEvaluacion { get; set; }
    public short Puntualidad { get; set; }
    public short CalidadInsumo { get; set; }
    public short PrecioCompetitivo { get; set; }
    public string? Observaciones { get; set; }
}
