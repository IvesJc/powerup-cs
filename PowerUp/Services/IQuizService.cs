using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IQuizService
{
    Task<QuizRequestDto> CreateAsync(QuizResponseDto quiz);
    Task<List<QuizRequestDto>> GetAllAsync();
    Task<QuizRequestDto> GetByIdAsync(int id);
    Task<QuizRequestDto> UpdateAsync(int id, QuizResponseDto quiz);
    Task DeleteAsync(int id);
}
