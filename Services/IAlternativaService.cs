using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IAlternativaService
{
    Task<AlternativaRequestDto> CreateAsync(AlternativaResponseDto alternativaResponseDto);

    Task<List<AlternativaRequestDto>> GetAllAsync();

    Task<AlternativaRequestDto> GetByIdAsync(int id);

    Task<AlternativaRequestDto> UpdateAsync(int id, AlternativaResponseDto alternativaResponseDto);

    Task DeleteAsync(int id);
}
