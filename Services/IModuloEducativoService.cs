using PowerUp.Dto.Request;
using PowerUp.Dto.Response;

namespace PowerUp.Services;

public interface IModuloEducativoService
{
    Task<ModuloEducativoRequestDto> CreateAsync(ModuloEducativoResponseDto moduloEducativo);
    Task<List<ModuloEducativoRequestDto>> GetAllAsync();
    Task<ModuloEducativoRequestDto> GetByIdAsync(int id);
    Task<ModuloEducativoRequestDto> UpdateAsync(int id, ModuloEducativoResponseDto moduloEducativo);
    Task DeleteAsync(int id);
}

