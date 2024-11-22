using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class UsuarioServiceImpl : IUsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioRequestDto> CreateAsync(UsuarioResponseDto usuarioDto)
    {
        var ranking = await _context.RankingModels
            .FirstOrDefaultAsync(r => r.Id == usuarioDto.Ranking)
            ?? throw new NotFoundException($"Ranking not found with id: {usuarioDto.Ranking}");

        var usuario = new UsuarioModel()
        {
            Nome = usuarioDto.Nome,
            FirebaseUid = usuarioDto.FirebaseUid,
            Email = usuarioDto.Email,
            Ranking = ranking
        };

        _context.UsuarioModels.Add(usuario);
        await _context.SaveChangesAsync();

        return MapToDTO(usuario);
    }

    public async Task<List<UsuarioRequestDto>> GetAllAsync()
    {
        return await _context.UsuarioModels
            .Select(u => MapToDTO(u))
            .ToListAsync();
    }

    public async Task<UsuarioRequestDto> GetByIdAsync(int id)
    {
        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new NotFoundException($"Usuario not found with id: {id}");

        return MapToDTO(usuario);
    }

    public async Task<UsuarioRequestDto> UpdateAsync(int id, UsuarioResponseDto usuarioDto)
    {
        var ranking = await _context.RankingModels
            .FirstOrDefaultAsync(r => r.Id == usuarioDto.Ranking)
            ?? throw new NotFoundException($"Ranking not found with id: {usuarioDto.Ranking}");

        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new NotFoundException($"Usuario not found with id: {id}");

        usuario.Nome = usuarioDto.Nome;
        usuario.Email = usuarioDto.Email;
        usuario.FirebaseUid = usuarioDto.FirebaseUid;
        usuario.Ranking = ranking;

        _context.UsuarioModels.Update(usuario);
        await _context.SaveChangesAsync();

        return MapToDTO(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.UsuarioModels
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new NotFoundException($"Usuario not found with id: {id}");

        _context.UsuarioModels.Remove(usuario);
        await _context.SaveChangesAsync();
    }

    private UsuarioRequestDto MapToDTO(UsuarioModel usuario)
    {
        return new UsuarioRequestDto
        {
            Id = usuario.Id,
            FirebaseUid = usuario.FirebaseUid,
            Email = usuario.Email,
            Nome = usuario.Nome,
            Ranking = usuario.Ranking.Id
        };
    }
}
