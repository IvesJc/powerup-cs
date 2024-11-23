using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;

namespace PowerUp.Services.Impl;

public class RecompensaServiceImpl : IRecompensaService
{
    private readonly AppDbContext _context;

    public RecompensaServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RecompensaRequestDto> CreateAsync(RecompensaResponseDto recompensaDto)
    {
        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == recompensaDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {recompensaDto.Usuario}");

        var recompensaConfig = await _context.RecompensaConfigModels
            .FirstOrDefaultAsync(r => r.Id == recompensaDto.RecompensaConfig)
            ?? throw new NotFoundException("Recompensa Config not found");

        var recompensa = new RecompensaModel()
        {
            PontosUtilizados = recompensaDto.PontosUtilizados,
            Usuario = usuario,
            RecompensaConfig = recompensaConfig
        };

        _context.RecompensaModels.Add(recompensa);
        await _context.SaveChangesAsync();

        return MapToDto(recompensa);
    }

    public async Task<List<RecompensaRequestDto>> GetAllAsync()
    {
        return await _context.RecompensaModels
            .Select(r => MapToDto(r))
            .ToListAsync();
    }

    public async Task<RecompensaRequestDto> GetByIdAsync(int id)
    {
        var recompensa = await _context.RecompensaModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"Recompensa not found with id: {id}");

        return MapToDto(recompensa);
    }

    public async Task<RecompensaRequestDto> UpdateAsync(int id, RecompensaResponseDto recompensaDto)
    {
        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == recompensaDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {recompensaDto.Usuario}");

        var recompensaConfig = await _context.RecompensaConfigModels
            .FirstOrDefaultAsync(r => r.Id == recompensaDto.RecompensaConfig)
            ?? throw new NotFoundException("Recompensa Config not found");

        var recompensa = await _context.RecompensaModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"Recompensa not found with id: {id}");

        recompensa.PontosUtilizados = recompensaDto.PontosUtilizados;
        recompensa.Usuario = usuario;
        recompensa.RecompensaConfig = recompensaConfig;

        _context.RecompensaModels.Update(recompensa);
        await _context.SaveChangesAsync();

        return MapToDto(recompensa);
    }

    public async Task DeleteAsync(int id)
    {
        var recompensa = await _context.RecompensaModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"Recompensa not found with id: {id}");

        _context.RecompensaModels.Remove(recompensa);
        await _context.SaveChangesAsync();
    }

    private  static RecompensaRequestDto MapToDto(RecompensaModel recompensa)
    {
        return new RecompensaRequestDto
        {
            Id = recompensa.Id,
            PontosUtilizados = recompensa.PontosUtilizados,
            Usuario = recompensa.Usuario.Id,
            RecompensaConfig = recompensa.RecompensaConfig.Id
        };
    }
}
