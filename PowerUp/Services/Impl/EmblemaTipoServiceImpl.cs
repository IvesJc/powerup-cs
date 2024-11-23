using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class EmblemaTipoServiceImpl : IEmblemaTipoService
{
    private readonly AppDbContext _context;

    public EmblemaTipoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmblemaTipoRequestDto> CreateAsync(EmblemaTipoResponseDto emblemaTipoResponseDto)
    {
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == emblemaTipoResponseDto.ImageLink)
            ?? throw new NotFoundException($"Link not found with id: {emblemaTipoResponseDto.ImageLink}");

        var newEmblemaTipo = new EmblemaTipoModel()
        {
            Nome = emblemaTipoResponseDto.Nome,
            ImageLinkId = link.Id
        };

        _context.EmblemaModelTipos.Add(newEmblemaTipo);
        await _context.SaveChangesAsync();

        return MapToDto(newEmblemaTipo);
    }

    public async Task<List<EmblemaTipoRequestDto>> GetAllAsync()
    {
        return await _context.EmblemaModelTipos
            .Select(et => MapToDto(et))
            .ToListAsync();
    }

    public async Task<EmblemaTipoRequestDto> GetByIdAsync(int id)
    {
        var emblemaTipo = await _context.EmblemaModelTipos
            .FirstOrDefaultAsync(et => et.Id == id)
            ?? throw new NotFoundException($"EmblemaTipo not found with id: {id}");

        return MapToDto(emblemaTipo);
    }

    public async Task<EmblemaTipoRequestDto> UpdateAsync(int id, EmblemaTipoResponseDto emblemaTipoResponseDto)
    {
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == emblemaTipoResponseDto.ImageLink)
            ?? throw new NotFoundException($"Link not found with id: {emblemaTipoResponseDto.ImageLink}");

        var emblemaTipo = await _context.EmblemaModelTipos
            .FirstOrDefaultAsync(et => et.Id == id)
            ?? throw new NotFoundException($"EmblemaTipo not found with id: {id}");

        emblemaTipo.Nome = emblemaTipoResponseDto.Nome;
        emblemaTipo.ImageLinkId = link.Id;

        _context.EmblemaModelTipos.Update(emblemaTipo);
        await _context.SaveChangesAsync();

        return MapToDto(emblemaTipo);
    }

    public async Task DeleteAsync(int id)
    {
        var emblemaTipo = await _context.EmblemaModelTipos
            .FirstOrDefaultAsync(et => et.Id == id)
            ?? throw new NotFoundException($"EmblemaTipo not found with id: {id}");

        _context.EmblemaModelTipos.Remove(emblemaTipo);
        await _context.SaveChangesAsync();
    }

    private  static EmblemaTipoRequestDto MapToDto(EmblemaTipoModel emblemaTipo)
    {
        return new EmblemaTipoRequestDto
        {
            Id = emblemaTipo.Id,
            Nome = emblemaTipo.Nome,
            ImageLink = emblemaTipo.ImageLink.Id
        };
    }
}
