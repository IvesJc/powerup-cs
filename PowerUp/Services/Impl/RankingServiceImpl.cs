using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class RankingServiceImpl : IRankingService
{
    private readonly AppDbContext _context;

    public RankingServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RankingRequestDto> CreateAsync(RankingResponseDto rankingDto)
    {
        var ranking = new RankingModel()
        {
            Nome = rankingDto.Nome
        };

        _context.RankingModels.Add(ranking);
        await _context.SaveChangesAsync();

        return MapToDto(ranking);
    }

    public async Task<List<RankingRequestDto>> GetAllAsync()
    {
        return await _context.RankingModels
            .Select(r => MapToDto(r))
            .ToListAsync();
    }

    public async Task<RankingRequestDto> GetByIdAsync(int id)
    {
        var ranking = await _context.RankingModels
                          .FirstOrDefaultAsync(r => r.Id == id)
                      ?? throw new NotFoundException($"Ranking not found with id: {id}");

        return MapToDto(ranking);
    }

    public async Task<RankingRequestDto> UpdateAsync(int id, RankingResponseDto rankingDto)
    {
        var ranking = await _context.RankingModels
                          .FirstOrDefaultAsync(r => r.Id == id)
                      ?? throw new NotFoundException($"Ranking not found with id: {id}");

        ranking.Nome = rankingDto.Nome;

        _context.RankingModels.Update(ranking);
        await _context.SaveChangesAsync();

        return MapToDto(ranking);
    }

    public async Task DeleteAsync(int id)
    {
        var ranking = await _context.RankingModels
                          .FirstOrDefaultAsync(r => r.Id == id)
                      ?? throw new NotFoundException($"Ranking not found with id: {id}");

        _context.RankingModels.Remove(ranking);
        await _context.SaveChangesAsync();
    }

    private static  RankingRequestDto MapToDto(RankingModel ranking)
    {
        return new RankingRequestDto
        {
            Id = ranking.Id,
            Nome = ranking.Nome
        };
    }
}
