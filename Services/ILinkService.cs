using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface ILinkService
{
    Task<LinkRequestDto> CreateAsync(LinkResponseDto link);
    Task<List<LinkRequestDto>> GetAllAsync();
    Task<LinkRequestDto> GetByIdAsync(int id);
    Task<LinkRequestDto> UpdateAsync(int id, LinkResponseDto link);
    Task DeleteAsync(int id);
}