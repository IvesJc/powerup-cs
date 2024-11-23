using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IRankingService
{
    Task<RankingRequestDto> CreateAsync(RankingResponseDto ranking);
    Task<List<RankingRequestDto>> GetAllAsync();
    Task<RankingRequestDto> GetByIdAsync(int id);
    Task<RankingRequestDto> UpdateAsync(int id, RankingResponseDto ranking);
    Task DeleteAsync(int id);
}

