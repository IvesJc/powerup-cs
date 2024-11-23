using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IDesafioService
{
    Task<DesafioRequestDto> CreateAsync(DesafioResponseDto desafio);
    Task<List<DesafioRequestDto>> GetAllAsync();
    Task<DesafioRequestDto> GetByIdAsync(int id);
    Task<DesafioRequestDto> UpdateAsync(int id, DesafioResponseDto desafio);
    Task DeleteAsync(int id);
}
