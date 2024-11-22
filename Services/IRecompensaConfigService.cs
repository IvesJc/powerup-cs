using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IRecompensaConfigService
{
    Task<RecompensaConfigRequestDto> CreateAsync(RecompensaConfigResponseDto recompensaConfig);
    Task<List<RecompensaConfigRequestDto>> GetAllAsync();
    Task<RecompensaConfigRequestDto> GetByIdAsync(int id);
    Task<RecompensaConfigRequestDto> UpdateAsync(int id, RecompensaConfigResponseDto recompensaConfig);
    Task DeleteAsync(int id);
}
