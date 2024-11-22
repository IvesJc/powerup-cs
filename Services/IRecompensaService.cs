using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IRecompensaService
{
    Task<RecompensaRequestDto> CreateAsync(RecompensaResponseDto recompensa);
    Task<List<RecompensaRequestDto>> GetAllAsync();
    Task<RecompensaRequestDto> GetByIdAsync(int id);
    Task<RecompensaRequestDto> UpdateAsync(int id, RecompensaResponseDto recompensa);
    Task DeleteAsync(int id);
}

