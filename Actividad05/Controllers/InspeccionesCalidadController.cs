using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspeccionesCalidadController : ControllerBase
{
    private readonly IInspeccionesCalidadService _service;

    public InspeccionesCalidadController(IInspeccionesCalidadService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InspeccionesCalidadResponseDto>>> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InspeccionesCalidadResponseDto>> GetById(int id)
    {
        var result = await _service.GetById(id);
        if (result == null)
        {
            return NotFound("Inspección de calidad no encontrada.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<InspeccionesCalidadResponseDto>> Create([FromBody] InspeccionesCalidadCreateUpdateDto dto)
    {
        var creado = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdInspeccion }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] InspeccionesCalidadCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Inspección de calidad no encontrada.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Inspección de calidad no encontrada.");
        }
        return NoContent();
    }
}
