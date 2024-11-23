using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IRecompensaTipoService
{
    Task<RecompensaTipoRequestDto> CreateAsync(RecompensaTipoResponseDto recompensaTipo);
    Task<List<RecompensaTipoRequestDto>> GetAllAsync();
    Task<RecompensaTipoRequestDto> GetByIdAsync(int id);
    Task<RecompensaTipoRequestDto> UpdateAsync(int id, RecompensaTipoResponseDto recompensaTipo);
    Task DeleteAsync(int id);
}
