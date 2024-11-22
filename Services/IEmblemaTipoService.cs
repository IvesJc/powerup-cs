using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IEmblemaTipoService
{
    Task<EmblemaTipoRequestDto> CreateAsync(EmblemaTipoResponseDto emblemaTipo);
    Task<List<EmblemaTipoRequestDto>> GetAllAsync();
    Task<EmblemaTipoRequestDto> GetByIdAsync(int id);
    Task<EmblemaTipoRequestDto> UpdateAsync(int id, EmblemaTipoResponseDto emblemaTipo);
    Task DeleteAsync(int id);
}