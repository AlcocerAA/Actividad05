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
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetById(id);
        if (result == null)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProveedoreCreateUpdateDto dto)
    {
        await _service.Create(dto);
        return Ok("Proveedor creado con exito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProveedoreCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return Ok("Proveedor actualizado correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Proveedor no encontrado.");
        }
        return Ok("Proveedor eliminado correctamente");
    }
}
