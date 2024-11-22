using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class PerguntaServiceImpl : IPerguntaService
{
    private readonly AppDbContext _context;

    public PerguntaServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PerguntaRequestDto> CreateAsync(PerguntaResponseDto perguntaDto)
    {
        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == perguntaDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {perguntaDto.Quiz}");

        var savedEntity = new PerguntaModel()
        {
            Titulo = perguntaDto.Titulo,
            Conteudo = perguntaDto.Conteudo,
            QuizId = quiz.Id
        };

        _context.PerguntaModels.Add(savedEntity);
        await _context.SaveChangesAsync();

        return MapToDTO(savedEntity);
    }

    public async Task<List<PerguntaRequestDto>> GetAllAsync()
    {
        return await _context.PerguntaModels
            .Select(p => MapToDTO(p))
            .ToListAsync();
    }

    public async Task<PerguntaRequestDto> GetByIdAsync(int id)
    {
        var pergunta = await _context.PerguntaModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Pergunta not found with id: {id}");

        return MapToDTO(pergunta);
    }

    public async Task<PerguntaRequestDto> UpdateAsync(int id, PerguntaResponseDto perguntaDto)
    {
        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == perguntaDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {perguntaDto.Quiz}");

        var pergunta = await _context.PerguntaModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Pergunta not found with id: {id}");

        pergunta.Titulo = perguntaDto.Titulo;
        pergunta.Conteudo = perguntaDto.Conteudo;
        pergunta.QuizId = quiz.Id;

        _context.PerguntaModels.Update(pergunta);
        await _context.SaveChangesAsync();

        return MapToDTO(pergunta);
    }

    public async Task DeleteAsync(int id)
    {
        var pergunta = await _context.PerguntaModels
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new NotFoundException($"Pergunta not found with id: {id}");

        _context.PerguntaModels.Remove(pergunta);
        await _context.SaveChangesAsync();
    }

    private PerguntaRequestDto MapToDTO(PerguntaModel pergunta)
    {
        return new PerguntaRequestDto
        {
            Id = pergunta.Id,
            Titulo = pergunta.Titulo,
            Conteudo = pergunta.Conteudo,
            Quiz = pergunta.Quiz.Id
        };
    }
}
