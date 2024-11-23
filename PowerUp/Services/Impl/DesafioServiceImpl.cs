using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class DesafioServiceImpl : IDesafioService
{
    private readonly AppDbContext _context;

    public DesafioServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DesafioRequestDto> CreateAsync(DesafioResponseDto desafioResponseDto)
    {
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == desafioResponseDto.ThumbLink)
            ?? throw new NotFoundException($"Link not found with id: {desafioResponseDto.ThumbLink}");

        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == desafioResponseDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {desafioResponseDto.Quiz}");

        var newDesafio = new DesafioModel()
        {
            Nome = desafioResponseDto.Nome,
            Descricao = desafioResponseDto.Descricao,
            ThumbLink = link,
            Quiz = quiz
        };

        _context.DesafioModels.Add(newDesafio);
        await _context.SaveChangesAsync();

        return MapToDto(newDesafio);
    }

    public async Task<List<DesafioRequestDto>> GetAllAsync()
    {
        return await _context.DesafioModels
            .Select(desafio => MapToDto(desafio))
            .ToListAsync();
    }

    public async Task<DesafioRequestDto> GetByIdAsync(int id)
    {
        var desafio = await _context.DesafioModels
            .FirstOrDefaultAsync(d => d.Id == id)
            ?? throw new NotFoundException($"Desafio not found with id: {id}");

        return MapToDto(desafio);
    }

    public async Task<DesafioRequestDto> UpdateAsync(int id, DesafioResponseDto desafioResponseDto)
    {
        var desafio = await _context.DesafioModels
            .FirstOrDefaultAsync(d => d.Id == id)
            ?? throw new NotFoundException($"Desafio not found with id: {id}");

        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == desafioResponseDto.ThumbLink)
            ?? throw new NotFoundException($"Link not found with id: {desafioResponseDto.ThumbLink}");

        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == desafioResponseDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {desafioResponseDto.Quiz}");

        desafio.Nome = desafioResponseDto.Nome;
        desafio.Descricao = desafioResponseDto.Descricao;
        desafio.ThumbLink = link;
        desafio.Quiz = quiz;

        _context.DesafioModels.Update(desafio);
        await _context.SaveChangesAsync();

        return MapToDto(desafio);
    }

    public async Task DeleteAsync(int id)
    {
        var desafio = await _context.DesafioModels
            .FirstOrDefaultAsync(d => d.Id == id)
            ?? throw new NotFoundException($"Desafio not found with id: {id}");

        _context.DesafioModels.Remove(desafio);
        await _context.SaveChangesAsync();
    }

    private static  DesafioRequestDto MapToDto(DesafioModel desafio)
    {
        return new DesafioRequestDto
        {
            Id = desafio.Id,
            Nome = desafio.Nome,
            Descricao = desafio.Descricao,
            ThumbLink = desafio.ThumbLink.Id,
            Quiz = desafio.Quiz.Id
        };
    }
}
