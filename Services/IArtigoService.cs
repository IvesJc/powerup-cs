using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IArtigoService
{
    Task<ArtigoRequestDto> CreateAsync(ArtigoResponseDto artigoDto);
    Task<List<ArtigoRequestDto>> GetAllAsync();
    Task<ArtigoRequestDto> GetByIdAsync(int id);
    Task<ArtigoRequestDto> UpdateAsync(int id, ArtigoResponseDto artigoDto);
    Task DeleteAsync(int id);
}
