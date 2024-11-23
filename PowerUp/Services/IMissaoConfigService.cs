using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IMissaoConfigService
{
    Task<MissaoConfigRequestDto> CreateAsync(MissaoConfigResponseDto missaoConfig);
    Task<List<MissaoConfigRequestDto>> GetAllAsync();
    Task<MissaoConfigRequestDto> GetByIdAsync(int id);
    Task<MissaoConfigRequestDto> UpdateAsync(int id, MissaoConfigResponseDto missaoConfig);
    Task DeleteAsync(int id);
}
