using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class MissaoConfigServiceImpl : IMissaoConfigService
{
    private readonly AppDbContext _context;

    public MissaoConfigServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MissaoConfigRequestDto> CreateAsync(MissaoConfigResponseDto missaoConfigDto)
    {
        var newMissaoConfig = new MissaoConfigModel()
        {
            Nome = missaoConfigDto.Nome,
            Descricao = missaoConfigDto.Descricao,
            Pontos = missaoConfigDto.Pontos,
            FrequenciaDias = missaoConfigDto.FrequenciaDias
        };

        _context.MissaoConfigModels.Add(newMissaoConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(newMissaoConfig);
    }

    public async Task<List<MissaoConfigRequestDto>> GetAllAsync()
    {
        return await _context.MissaoConfigModels
            .Select(m => MapToDTO(m))
            .ToListAsync();
    }

    public async Task<MissaoConfigRequestDto> GetByIdAsync(int id)
    {
        var missaoConfig = await _context.MissaoConfigModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"MissaoConfig not found with id: {id}");

        return MapToDTO(missaoConfig);
    }

    public async Task<MissaoConfigRequestDto> UpdateAsync(int id, MissaoConfigResponseDto missaoConfigDto)
    {
        var missaoConfig = await _context.MissaoConfigModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"MissaoConfig not found with id: {id}");

        missaoConfig.Nome = missaoConfigDto.Nome;
        missaoConfig.Descricao = missaoConfigDto.Descricao;
        missaoConfig.Pontos = missaoConfigDto.Pontos;
        missaoConfig.FrequenciaDias = missaoConfigDto.FrequenciaDias;

        _context.MissaoConfigModels.Update(missaoConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(missaoConfig);
    }

    public async Task DeleteAsync(int id)
    {
        var missaoConfig = await _context.MissaoConfigModels
            .FirstOrDefaultAsync(m => m.Id == id)
            ?? throw new NotFoundException($"MissaoConfig not found with id: {id}");

        _context.MissaoConfigModels.Remove(missaoConfig);
        await _context.SaveChangesAsync();
    }

    private MissaoConfigRequestDto MapToDTO(MissaoConfigModel missaoConfig)
    {
        return new MissaoConfigRequestDto
        {
            Id = missaoConfig.Id,
            Nome = missaoConfig.Nome,
            Descricao = missaoConfig.Descricao,
            Pontos = missaoConfig.Pontos,
            FrequenciaDias = missaoConfig.FrequenciaDias
        };
    }
}
