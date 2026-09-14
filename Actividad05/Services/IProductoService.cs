using Actividad05.DTOs;

namespace Actividad05.Services;

public interface IProductoService
{
    Task<IEnumerable<ProductoResponseDto>> GetAll();
    Task<ProductoResponseDto?> GetById(int id);
    Task<ProductoResponseDto> Create(ProductoCreateUpdateDto dto);
    Task<bool> Update(int id, ProductoCreateUpdateDto dto);
    Task<bool> Delete(int id);
}
