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
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EvaluacionesProveedorCreateUpdateDto dto)
    {
        await _service.Create(dto);
        return Ok("Evaluacion de proveedor creada con exito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EvaluacionesProveedorCreateUpdateDto dto)
    {
        var actualizado = await _service.Update(id, dto);
        if (!actualizado)
        {
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return Ok("Evaluacion de proveedor actualizada correctamente");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.Delete(id);
        if (!eliminado)
        {
            return NotFound("Evaluación de proveedor no encontrada.");
        }
        return Ok("Evaluacion de proveedor eliminada correctamente");
    }
}
