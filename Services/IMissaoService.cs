using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IMissaoService
{
    Task<MissaoRequestDto> CreateAsync(MissaoResponseDto missao);
    Task<List<MissaoRequestDto>> GetAllAsync();
    Task<MissaoRequestDto> GetByIdAsync(int id);
    Task<MissaoRequestDto> UpdateAsync(int id, MissaoResponseDto missao);
    Task DeleteAsync(int id);
}

