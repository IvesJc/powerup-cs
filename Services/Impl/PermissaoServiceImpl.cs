using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class PermissaoServiceImpl : IPermissaoService
{
    private readonly AppDbContext _context;

    public PermissaoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PermissaoRequestDto> CreateAsync(PermissaoResponseDto permissaoDto)
    {
        var savedEntity = new PermissaoModel()
        {
            Nome = permissaoDto.Nome,
            Descricao = permissaoDto.Descricao
        };

        _context.PermissaoModels.Add(savedEntity);
        await _context.SaveChangesAsync();

        return MapToDTO(savedEntity);
    }

    public async Task<List<PermissaoRequestDto>> GetAllAsync()
    {
        return await _context.PermissaoModels
            .Select(p => MapToDTO(p))
            .ToListAsync();
    }

    public async Task<PermissaoRequestDto> GetByIdAsync(int id)
    {
        var permissao = await _context.PermissaoModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Permissao not found with id: {id}");

        return MapToDTO(permissao);
    }

    public async Task<PermissaoRequestDto> UpdateAsync(int id, PermissaoResponseDto permissaoDto)
    {
        var permissao = await _context.PermissaoModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Permissao not found with id: {id}");

        permissao.Nome = permissaoDto.Nome;
        permissao.Descricao = permissaoDto.Descricao;

        _context.PermissaoModels.Update(permissao);
        await _context.SaveChangesAsync();

        return MapToDTO(permissao);
    }

    public async Task DeleteAsync(int id)
    {
        var permissao = await _context.PermissaoModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Permissao not found with id: {id}");

        _context.PermissaoModels.Remove(permissao);
        await _context.SaveChangesAsync();
    }

    private PermissaoRequestDto MapToDTO(PermissaoModel permissao)
    {
        return new PermissaoRequestDto
        {
            Id = permissao.Id,
            Nome = permissao.Nome,
            Descricao = permissao.Descricao
        };
    }
}
