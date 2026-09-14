using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoreController : ControllerBase
{
    private readonly IProveedoreService _service;

    public ProveedoreController(IProveedoreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProveedoreResponseDto>>> GetAll()
    {
        var proveedores = await _service.GetAll();
        return Ok(proveedores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProveedoreResponseDto>> GetById(int id)
    {
        var proveedor = await _service.GetById(id);
        if (proveedor == null)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return Ok(proveedor);
    }

    [HttpPost]
    public async Task<ActionResult<ProveedoreResponseDto>> Create([FromBody] ProveedoreCreateUpdateDto dto)
    {
        var creado = await _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = creado.IdProveedor }, creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProveedoreCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return NoContent();
    }
}
