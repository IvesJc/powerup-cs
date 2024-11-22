using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class RecompensaTipoServiceImpl : IRecompensaTipoService
{
    private readonly AppDbContext _context;

    public RecompensaTipoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RecompensaTipoRequestDto> CreateAsync(RecompensaTipoResponseDto recompensaTipoDto)
    {
        var recompensaTipo = new RecompensaTipoModel()
        {
            Nome = recompensaTipoDto.Nome,
            Descricao = recompensaTipoDto.Descricao
        };

        _context.RecompensaModelTipos.Add(recompensaTipo);
        await _context.SaveChangesAsync();

        return MapToDTO(recompensaTipo);
    }

    public async Task<List<RecompensaTipoRequestDto>> GetAllAsync()
    {
        return await _context.RecompensaModelTipos
            .Select(rt => MapToDTO(rt))
            .ToListAsync();
    }

    public async Task<RecompensaTipoRequestDto> GetByIdAsync(int id)
    {
        var recompensaTipo = await _context.RecompensaModelTipos
            .FirstOrDefaultAsync(rt => rt.Id == id)
            ?? throw new NotFoundException($"RecompensaTipo not found with id: {id}");

        return MapToDTO(recompensaTipo);
    }

    public async Task<RecompensaTipoRequestDto> UpdateAsync(int id, RecompensaTipoResponseDto recompensaTipoDto)
    {
        var recompensaTipo = await _context.RecompensaModelTipos
            .FirstOrDefaultAsync(rt => rt.Id == id)
            ?? throw new NotFoundException($"RecompensaTipo not found with id: {id}");

        recompensaTipo.Nome = recompensaTipoDto.Nome;
        recompensaTipo.Descricao = recompensaTipoDto.Descricao;

        _context.RecompensaModelTipos.Update(recompensaTipo);
        await _context.SaveChangesAsync();

        return MapToDTO(recompensaTipo);
    }

    public async Task DeleteAsync(int id)
    {
        var recompensaTipo = await _context.RecompensaModelTipos
            .FirstOrDefaultAsync(rt => rt.Id == id)
            ?? throw new NotFoundException($"RecompensaTipo not found with id: {id}");

        _context.RecompensaModelTipos.Remove(recompensaTipo);
        await _context.SaveChangesAsync();
    }

    private RecompensaTipoRequestDto MapToDTO(RecompensaTipoModel recompensaTipo)
    {
        return new RecompensaTipoRequestDto
        {
            Id = recompensaTipo.Id,
            Nome = recompensaTipo.Nome,
            Descricao = recompensaTipo.Descricao
        };
    }
}
