using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class RecompensaConfigServiceImpl : IRecompensaConfigService
{
    private readonly AppDbContext _context;

    public RecompensaConfigServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RecompensaConfigRequestDto> CreateAsync(RecompensaConfigResponseDto recompensaConfigDto)
    {
        var recompensaTipo = await _context.RecompensaModelTipos
            .FirstOrDefaultAsync(r => r.Id == recompensaConfigDto.RecompensaTipo)
            ?? throw new NotFoundException("RecompensaTipo not found");

        var recompensaConfig = new RecompensaConfigModel()
        {
            Nome = recompensaConfigDto.Nome,
            CustoPontos = recompensaConfigDto.CustoPontos,
            RecompensaTipo = recompensaTipo
        };

        _context.RecompensaConfigModels.Add(recompensaConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(recompensaConfig);
    }

    public async Task<List<RecompensaConfigRequestDto>> GetAllAsync()
    {
        return await _context.RecompensaConfigModels
            .Select(r => MapToDTO(r))
            .ToListAsync();
    }

    public async Task<RecompensaConfigRequestDto> GetByIdAsync(int id)
    {
        var recompensaConfig = await _context.RecompensaConfigModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"RecompensaConfig not found with id: {id}");

        return MapToDTO(recompensaConfig);
    }

    public async Task<RecompensaConfigRequestDto> UpdateAsync(int id, RecompensaConfigResponseDto recompensaConfigDto)
    {
        var recompensaTipo = await _context.RecompensaModelTipos
            .FirstOrDefaultAsync(r => r.Id == recompensaConfigDto.RecompensaTipo)
            ?? throw new NotFoundException("RecompensaTipo not found");

        var recompensaConfig = await _context.RecompensaConfigModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"RecompensaConfig not found with id: {id}");

        recompensaConfig.Nome = recompensaConfigDto.Nome;
        recompensaConfig.CustoPontos = recompensaConfigDto.CustoPontos;
        recompensaConfig.RecompensaTipo = recompensaTipo;

        _context.RecompensaConfigModels.Update(recompensaConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(recompensaConfig);
    }

    public async Task DeleteAsync(int id)
    {
        var recompensaConfig = await _context.RecompensaConfigModels
            .FirstOrDefaultAsync(r => r.Id == id)
            ?? throw new NotFoundException($"RecompensaConfig not found with id: {id}");

        _context.RecompensaConfigModels.Remove(recompensaConfig);
        await _context.SaveChangesAsync();
    }

    private RecompensaConfigRequestDto MapToDTO(RecompensaConfigModel recompensaConfig)
    {
        return new RecompensaConfigRequestDto
        {
            Id = recompensaConfig.Id,
            Nome = recompensaConfig.Nome,
            CustoPontos = recompensaConfig.CustoPontos,
            RecompensaTipo = recompensaConfig.RecompensaTipo.Id
        };
    }
}
