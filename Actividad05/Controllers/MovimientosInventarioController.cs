using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosInventarioController : ControllerBase
{
    private readonly IMovimientosInventarioService _service;

    public MovimientosInventarioController(IMovimientosInventarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovimientosInventarioResponseDto>>> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovimientosInventarioResponseDto>> GetById(int id)
    {
        var result = await _service.GetById(id);
        if (result == null)
        {
            return NotFound("Movimiento de inventario no encontrado.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<MovimientosInventarioResponseDto>> Create([FromBody] MovimientosInventarioCreateUpdateDto dto)
    {
        var creado = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdMovimiento }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MovimientosInventarioCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Movimiento de inventario no encontrado.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Movimiento de inventario no encontrado.");
        }
        return NoContent();
    }
}
