using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesProduccionController : ControllerBase
{
    private readonly IOrdenesProduccionService _service;

    public OrdenesProduccionController(IOrdenesProduccionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrdenesProduccionResponseDto>>> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrdenesProduccionResponseDto>> GetById(int id)
    {
        var result = await _service.GetById(id);
        if (result == null)
        {
            return NotFound("Orden de produccion no encontrada.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OrdenesProduccionResponseDto>> Create([FromBody] OrdenesProduccionCreateUpdateDto dto)
    {
        var creado = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdOrden }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrdenesProduccionCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Orden de produccion no encontrada.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Orden de produccion no encontrada.");
        }
        return NoContent();
    }
}
