using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IEmblemaConfigService
{
    Task<EmblemaConfigRequestDto> CreateAsync(EmblemaConfigResponseDto emblemaConfig);
    Task<List<EmblemaConfigRequestDto>> GetAllAsync();
    Task<EmblemaConfigRequestDto> GetByIdAsync(int id);
    Task<EmblemaConfigRequestDto> UpdateAsync(int id, EmblemaConfigResponseDto emblemaConfig);
    Task DeleteAsync(int id);
}