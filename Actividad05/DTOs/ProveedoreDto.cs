namespace Actividad05.DTOs;

public class ProveedoreCreateUpdateDto
{
    public string Nombre { get; set; } = null!;
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public decimal? CalificacionPromedio { get; set; }
    public bool Activo { get; set; } = true;
}

public class ProveedoreResponseDto
{
    public int IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public decimal? CalificacionPromedio { get; set; }
    public bool Activo { get; set; }
}
