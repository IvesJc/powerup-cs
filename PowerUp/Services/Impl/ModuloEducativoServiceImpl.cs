using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class ModuloEducativoServiceImpl : IModuloEducativoService
{
    private readonly AppDbContext _context;

    public ModuloEducativoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ModuloEducativoRequestDto> CreateAsync(ModuloEducativoResponseDto moduloEducativoDto)
    {
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == moduloEducativoDto.ThumbLink)
            ?? throw new NotFoundException("Link not found");

        var savedEntity = new ModuloEducativoModel()
        {
            Titulo = moduloEducativoDto.Titulo,
            Subtitulo = moduloEducativoDto.Subtitulo,
            Descricao = moduloEducativoDto.Descricao,
            Nivel = moduloEducativoDto.Nivel,
            ThumbLinkId = link.Id
        };

        _context.ModuloEducativoModels.Add(savedEntity);
        await _context.SaveChangesAsync();

        return MapToDto(savedEntity);
    }

    public async Task<List<ModuloEducativoRequestDto>> GetAllAsync()
    {
        return await _context.ModuloEducativoModels
            .Select(me => MapToDto(me))
            .ToListAsync();
    }

    public async Task<ModuloEducativoRequestDto> GetByIdAsync(int id)
    {
        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(me => me.Id == id)
            ?? throw new NotFoundException($"ModuloEducativo not found with id: {id}");

        return MapToDto(moduloEducativo);
    }

    public async Task<ModuloEducativoRequestDto> UpdateAsync(int id, ModuloEducativoResponseDto moduloEducativoDto)
    {
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == moduloEducativoDto.ThumbLink)
            ?? throw new NotFoundException("Link not found");

        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(me => me.Id == id)
            ?? throw new NotFoundException($"ModuloEducativo not found with id: {id}");

        moduloEducativo.Titulo = moduloEducativoDto.Titulo;
        moduloEducativo.Subtitulo = moduloEducativoDto.Subtitulo;
        moduloEducativo.Descricao = moduloEducativoDto.Descricao;
        moduloEducativo.Nivel = moduloEducativoDto.Nivel;
        moduloEducativo.ThumbLinkId = link.Id;

        _context.ModuloEducativoModels.Update(moduloEducativo);
        await _context.SaveChangesAsync();

        return MapToDto(moduloEducativo);
    }

    public async Task DeleteAsync(int id)
    {
        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(me => me.Id == id)
            ?? throw new NotFoundException($"ModuloEducativo not found with id: {id}");

        _context.ModuloEducativoModels.Remove(moduloEducativo);
        await _context.SaveChangesAsync();
    }

    private  static ModuloEducativoRequestDto MapToDto(ModuloEducativoModel moduloEducativo)
    {
        return new ModuloEducativoRequestDto
        {
            Id = moduloEducativo.Id,
            Titulo = moduloEducativo.Titulo,
            Subtitulo = moduloEducativo.Subtitulo,
            Descricao = moduloEducativo.Descricao,
            Nivel = moduloEducativo.Nivel,
            ThumbLink = moduloEducativo.ThumbLink.Id
        };
    }
}
