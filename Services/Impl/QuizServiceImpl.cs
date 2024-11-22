using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class QuizServiceImpl : IQuizService
{
    private readonly AppDbContext _context;

    public QuizServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<QuizRequestDto> CreateAsync(QuizResponseDto quizDto)
    {
        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(m => m.Id == quizDto.ModuloEducativo)
            ?? throw new NotFoundException("ModuloEducativo not found");

        var quiz = new QuizModel()
        {
            Nome = quizDto.Nome,
            Descricao = quizDto.Descricao,
            Categoria = quizDto.Categoria,
            NotaMinima = quizDto.NotaMinima,
            ModuloEducativo = moduloEducativo
        };

        _context.QuizModels.Add(quiz);
        await _context.SaveChangesAsync();

        return MapToDTO(quiz);
    }

    public async Task<List<QuizRequestDto>> GetAllAsync()
    {
        return await _context.QuizModels
            .Select(q => MapToDTO(q))
            .ToListAsync();
    }

    public async Task<QuizRequestDto> GetByIdAsync(int id)
    {
        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == id)
            ?? throw new NotFoundException($"Quiz not found with id: {id}");

        return MapToDTO(quiz);
    }

    public async Task<QuizRequestDto> UpdateAsync(int id, QuizResponseDto quizDto)
    {
        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(m => m.Id == quizDto.ModuloEducativo)
            ?? throw new NotFoundException("ModuloEducativo not found");

        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == id)
            ?? throw new NotFoundException($"Quiz not found with id: {id}");

        quiz.Nome = quizDto.Nome;
        quiz.Descricao = quizDto.Descricao;
        quiz.Categoria = quizDto.Categoria;
        quiz.NotaMinima = quizDto.NotaMinima;
        quiz.ModuloEducativo = moduloEducativo;

        _context.QuizModels.Update(quiz);
        await _context.SaveChangesAsync();

        return MapToDTO(quiz);
    }

    public async Task DeleteAsync(int id)
    {
        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == id)
            ?? throw new NotFoundException($"Quiz not found with id: {id}");

        _context.QuizModels.Remove(quiz);
        await _context.SaveChangesAsync();
    }

    private QuizRequestDto MapToDTO(QuizModel quiz)
    {
        return new QuizRequestDto
        {
            Id = quiz.Id,
            Nome = quiz.Nome,
            Descricao = quiz.Descricao,
            Categoria = quiz.Categoria,
            NotaMinima = quiz.NotaMinima,
            ModuloEducativo = quiz.ModuloEducativo.Id
        };
    }
}
