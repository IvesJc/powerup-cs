using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IPerguntaService
{
    Task<PerguntaRequestDto> CreateAsync(PerguntaResponseDto pergunta);
    Task<List<PerguntaRequestDto>> GetAllAsync();
    Task<PerguntaRequestDto> GetByIdAsync(int id);
    Task<PerguntaRequestDto> UpdateAsync(int id, PerguntaResponseDto pergunta);
    Task DeleteAsync(int id);
}
