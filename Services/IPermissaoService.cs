using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IPermissaoService
{
    Task<PermissaoRequestDto> CreateAsync(PermissaoResponseDto permissao);
    Task<List<PermissaoRequestDto>> GetAllAsync();
    Task<PermissaoRequestDto> GetByIdAsync(int id);
    Task<PermissaoRequestDto> UpdateAsync(int id, PermissaoResponseDto permissao);
    Task DeleteAsync(int id);
}

