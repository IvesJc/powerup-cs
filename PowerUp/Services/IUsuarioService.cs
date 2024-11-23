using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IUsuarioService
{
    Task<UsuarioRequestDto> CreateAsync(UsuarioResponseDto usuario);
    Task<List<UsuarioRequestDto>> GetAllAsync();
    Task<UsuarioRequestDto> GetByIdAsync(int id);
    Task<UsuarioRequestDto> UpdateAsync(int id, UsuarioResponseDto usuario);
    Task DeleteAsync(int id);
}


