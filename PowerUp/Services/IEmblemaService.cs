using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IEmblemaService
{
    Task<EmblemaRequestDto> CreateAsync(EmblemaResponseDto emblema);
    Task<List<EmblemaRequestDto>> GetAllAsync();
    Task<EmblemaRequestDto> GetByIdAsync(int id);
    Task<EmblemaRequestDto> UpdateAsync(int id, EmblemaResponseDto emblema);
    Task DeleteAsync(int id);
}