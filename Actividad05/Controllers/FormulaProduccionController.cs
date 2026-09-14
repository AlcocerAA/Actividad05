using Actividad05.DTOs;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormulaProduccionController : ControllerBase
{
    private readonly IFormulaProduccionService _service;

    public FormulaProduccionController(IFormulaProduccionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FormulaProduccionResponseDto>>> ObtenerFormulas()
    {
        var formulas = await _service.GetAllFormulas();
        return Ok(formulas);
    }

    [HttpGet("{idProducto}/{idMateriaPrima}")]
    public async Task<ActionResult<FormulaProduccionResponseDto>> ObtenerFormulaPorId(int idProducto, int idMateriaPrima)
    {
        var formula = await _service.GetFormulaById(idProducto, idMateriaPrima);
        if (formula == null)
        {
            return NotFound("Formula de produccion no encontrada.");
        }
        return Ok(formula);
    }

    [HttpPost]
    public async Task<ActionResult<FormulaProduccionResponseDto>> CrearFormula([FromBody] FormulaProduccionCreateDto dto)
    {
        try
        {
            var creada = await _service.CreateFormula(dto);
            return CreatedAtAction(nameof(ObtenerFormulaPorId), new { idProducto = creada.IdProducto, idMateriaPrima = creada.IdMateriaPrima }, creada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> ActualizarFormula(int idProducto, int idMateriaPrima, [FromBody] FormulaProduccionUpdateDto dto)
    {
        var actualizado = await _service.UpdateFormula(idProducto, idMateriaPrima, dto);
        if (!actualizado)
        {
            return NotFound("Formula de produccion no encontrada.");
        }
        return NoContent();
    }

    [HttpPatch("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> ActualizarParcialFormula(int idProducto, int idMateriaPrima, [FromBody] FormulaProduccionUpdateDto dto)
    {
        var actualizado = await _service.PatchFormula(idProducto, idMateriaPrima, dto);
        if (!actualizado)
        {
            return NotFound("Formula de produccion no encontrada.");
        }
        return NoContent();
    }

    [HttpDelete("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> EliminarFormula(int idProducto, int idMateriaPrima)
    {
        var eliminado = await _service.DeleteFormula(idProducto, idMateriaPrima);
        if (!eliminado)
        {
            return NotFound("Formula de produccion no encontrada.");
        }
        return NoContent();
    }
}