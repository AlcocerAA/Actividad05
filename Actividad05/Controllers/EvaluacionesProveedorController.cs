using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluacionesProveedorController : ControllerBase
{
    private readonly IEvaluacionesProveedorService _service;

    public EvaluacionesProveedorController(IEvaluacionesProveedorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EvaluacionesProveedorResponseDto>>> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EvaluacionesProveedorResponseDto>> GetById(int id)
    {
        var result = await _service.GetById(id);
        if (result == null)
        {
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EvaluacionesProveedorResponseDto>> Create([FromBody] EvaluacionesProveedorCreateUpdateDto dto)
    {
        var creado = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdEvaluacion }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EvaluacionesProveedorCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return NoContent();
    }
}
