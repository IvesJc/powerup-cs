using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;

namespace PowerUp.Services.Impl;

public class MissaoServiceImpl : IMissaoService
{
    private readonly AppDbContext _context;

    public MissaoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MissaoRequestDto> CreateAsync(MissaoResponseDto missaoDto)
    {
        var missaoConfig = await _context.MissaoConfigModels
            .FirstOrDefaultAsync(m => m.Id == missaoDto.MissaoConfig)
            ?? throw new NotFoundException($"MissaoConfig not found with id: {missaoDto.MissaoConfig}");

        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == missaoDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {missaoDto.Usuario}");

        var newMissao = new MissaoModel()
        {
            RecompensaPontos = missaoDto.RecompensaPontos,
            Status = missaoDto.Status,
            MissaoConfig = missaoConfig,
            Usuario = usuario
        };

        _context.MissaoModels.Add(newMissao);
        await _context.SaveChangesAsync();

        return MapToDTO(newMissao);
    }

    public async Task<List<MissaoRequestDto>> GetAllAsync()
    {
        return await _context.MissaoModels
            .Select(m => MapToDTO(m))
            .ToListAsync();
    }

    public async Task<MissaoRequestDto> GetByIdAsync(int id)
    {
        var missao = await _context.MissaoModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"Missao not found with id: {id}");

        return MapToDTO(missao);
    }

    public async Task<MissaoRequestDto> UpdateAsync(int id, MissaoResponseDto missaoDto)
    {
        var missaoConfig = await _context.MissaoConfigModels
            .FirstOrDefaultAsync(m => m.Id == missaoDto.MissaoConfig)
            ?? throw new NotFoundException($"MissaoConfig not found with id: {missaoDto.MissaoConfig}");

        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == missaoDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {missaoDto.Usuario}");

        var missao = await _context.MissaoModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"Missao not found with id: {id}");

        missao.Status = missaoDto.Status;
        missao.RecompensaPontos = missaoDto.RecompensaPontos;
        missao.MissaoConfig = missaoConfig;
        missao.Usuario = usuario;

        _context.MissaoModels.Update(missao);
        await _context.SaveChangesAsync();

        return MapToDTO(missao);
    }

    public async Task DeleteAsync(int id)
    {
        var missao = await _context.MissaoModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"Missao not found with id: {id}");

        _context.MissaoModels.Remove(missao);
        await _context.SaveChangesAsync();
    }

    private MissaoRequestDto MapToDTO(MissaoModel missao)
    {
        return new MissaoRequestDto
        {
            Id = missao.Id,
            RecompensaPontos = missao.RecompensaPontos,
            Status = missao.Status,
            MissaoConfig = missao.MissaoConfig.Id,
            Usuario = missao.Usuario.Id
        };
    }
}
