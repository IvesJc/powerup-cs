using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class EmblemaServiceImpl : IEmblemaService
{
    private readonly AppDbContext _context;

    public EmblemaServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmblemaRequestDto> CreateAsync(EmblemaResponseDto emblemaResponseDto)
    {
        var emblemaConfig = await _context.EmblemaConfigModels
            .FirstOrDefaultAsync(ec => ec.Id == emblemaResponseDto.EmblemaConfig)
            ?? throw new NotFoundException($"EmblemaConfig not found with id: {emblemaResponseDto.EmblemaConfig}");

        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == emblemaResponseDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {emblemaResponseDto.Usuario}");

        var newEmblema = new EmblemaModel()
        {
            EmblemaConfigId = emblemaConfig.Id,
            UsuarioId = usuario.Id
        };

        _context.EmblemaModels.Add(newEmblema);
        await _context.SaveChangesAsync();

        return MapToDto(newEmblema);
    }

    public async Task<List<EmblemaRequestDto>> GetAllAsync()
    {
        return await _context.EmblemaModels
            .Select(e => MapToDto(e))
            .ToListAsync();
    }

    public async Task<EmblemaRequestDto> GetByIdAsync(int id)
    {
        var emblema = await _context.EmblemaModels
            .FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new NotFoundException($"Emblema not found with id: {id}");

        return MapToDto(emblema);
    }

    public async Task<EmblemaRequestDto> UpdateAsync(int id, EmblemaResponseDto emblemaResponseDto)
    {
        var emblemaConfig = await _context.EmblemaConfigModels
            .FirstOrDefaultAsync(ec => ec.Id == emblemaResponseDto.EmblemaConfig)
            ?? throw new NotFoundException($"EmblemaConfig not found with id: {emblemaResponseDto.EmblemaConfig}");

        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == emblemaResponseDto.Usuario)
            ?? throw new NotFoundException($"Usuario not found with id: {emblemaResponseDto.Usuario}");

        var emblema = await _context.EmblemaModels
            .FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new NotFoundException($"Emblema not found with id: {id}");

        emblema.EmblemaConfigId = emblemaConfig.Id;
        emblema.UsuarioId = usuario.Id;

        _context.EmblemaModels.Update(emblema);
        await _context.SaveChangesAsync();

        return MapToDto(emblema);
    }

    public async Task DeleteAsync(int id)
    {
        var emblema = await _context.EmblemaModels
            .FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new NotFoundException($"Emblema not found with id: {id}");

        _context.EmblemaModels.Remove(emblema);
        await _context.SaveChangesAsync();
    }

    private static  EmblemaRequestDto MapToDto(EmblemaModel emblema)
    {
        return new EmblemaRequestDto
        {
            Id = emblema.Id,
            Usuario = emblema.Usuario.Id,
            EmblemaConfig = emblema.EmblemaConfig.Id
        };
    }
}
