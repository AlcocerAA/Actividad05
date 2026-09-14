using Actividad05.DTOs;
using Actividad05.Models;
using Actividad05.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
    public async Task<IActionResult> ObtenerFormulas()
    {
        var formulas = await _service.GetAllFormulas();
        return Ok(formulas);
    }

    [HttpPost]
    public async Task<IActionResult> CrearFormula([FromBody] FormulaProduccionDto dto)
    {
        try
        {
            var formula = new FormulaProduccion
            {
                IdProducto = dto.IdProducto ?? 0,
                IdMateriaPrima = dto.IdMateriaPrima ?? 0,
                CantidadRequerida = dto.CantidadRequerida ?? 0
            };

            await _service.CreateFormula(formula);
            return Ok("Formula de produccion creada con exito");
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException pgEx)
            {
                if (pgEx.SqlState == "23503")
                {
                    return BadRequest("El IdProducto o el IdMateriaPrima especificado no existe en la base de datos.");
                }
                if (pgEx.SqlState == "23505")
                {
                    return BadRequest("Ya existe una formula registrada para ese IdProducto e IdMateriaPrima.");
                }
            }
            return BadRequest("Error al procesar la formula de produccion en la base de datos.");
        }
    }

    [HttpPut("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> ActualizarFormula(int idProducto, int idMateriaPrima, [FromBody] FormulaProduccionDto dto)
    {
        var formula = new FormulaProduccion
        {
            IdProducto = idProducto,
            IdMateriaPrima = idMateriaPrima,
            CantidadRequerida = dto.CantidadRequerida ?? 0
        };

        var resultado = await _service.UpdateFormula(idProducto, idMateriaPrima, formula);
        if (!resultado)
        {
            return NotFound("Formula de produccion no encontrada");
        }

        return Ok("Formula de produccion actualizada correctamente");
    }

    [HttpPatch("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> ActualizarParcialFormula(int idProducto, int idMateriaPrima, [FromBody] FormulaProduccionDto dto)
    {
        var formula = new FormulaProduccion
        {
            IdProducto = idProducto,
            IdMateriaPrima = idMateriaPrima,
            CantidadRequerida = dto.CantidadRequerida ?? 0
        };

        var resultado = await _service.PatchFormula(idProducto, idMateriaPrima, formula);
        if (!resultado)
        {
            return NotFound("Formula de produccion no encontrada");
        }

        return Ok("Formula de produccion actualizada parcialmente correctamente");
    }

    [HttpDelete("{idProducto}/{idMateriaPrima}")]
    public async Task<IActionResult> EliminarFormula(int idProducto, int idMateriaPrima)
    {
        try
        {
            var resultado = await _service.DeleteFormula(idProducto, idMateriaPrima);
            if (!resultado)
            {
                return NotFound("Formula de produccion no encontrada");
            }

            return Ok("Formula de produccion eliminada correctamente");
        }
        catch (DbUpdateException)
        {
            return BadRequest("No se puede eliminar la formula de produccion debido a dependencias en la base de datos.");
        }
    }
}