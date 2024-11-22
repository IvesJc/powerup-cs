using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;
using PowerUp.Repositories;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Services.Impl;

public class AlternativaServiceImpl : IAlternativaService
{
    private readonly AppDbContext _context;

    public AlternativaServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AlternativaRequestDto> CreateAsync(AlternativaResponseDto alternativaResponseDto)
    {
        // Verificando se a pergunta existe
        var pergunta = await _context.PerguntaModels
            .FirstOrDefaultAsync(p => p.Id == alternativaResponseDto.Pergunta)
            ?? throw new NotFoundException($"Pergunta não encontrada com ID: {alternativaResponseDto.Pergunta}");

        // Criando a nova alternativa
        var novaAlternativa = new AlternativaModel
        {
            Descricao = alternativaResponseDto.Descricao,
            ECorreta = alternativaResponseDto.ECorreta,
            Pergunta = pergunta
        };

        _context.AlternativaModels.Add(novaAlternativa);
        await _context.SaveChangesAsync();

        return MapToDto(novaAlternativa);
    }

    public async Task<List<AlternativaRequestDto>> GetAllAsync()
    {
        return await _context.AlternativaModels
            .Select(a => MapToDto(a))
            .ToListAsync();
    }

    public async Task<AlternativaRequestDto> GetByIdAsync(int id)
    {
        var alternativa = await _context.AlternativaModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Alternativa não encontrada com id: {id}");

        return MapToDto(alternativa);
    }

    public async Task<AlternativaRequestDto> UpdateAsync(int id, AlternativaResponseDto alternativaResponseDto)
    {
        var alternativaAtualizada = await _context.AlternativaModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Alternativa não encontrada com id: {id}");

        // Verificando se a pergunta existe
        var pergunta = await _context.PerguntaModels
            .FirstOrDefaultAsync(p => p.Id == alternativaResponseDto.Pergunta)
            ?? throw new NotFoundException($"Pergunta não encontrada com ID: {alternativaResponseDto.Pergunta}");

        // Atualizando a alternativa
        alternativaAtualizada.Descricao = alternativaResponseDto.Descricao;
        alternativaAtualizada.ECorreta = alternativaResponseDto.ECorreta;
        alternativaAtualizada.Pergunta = pergunta;

        _context.AlternativaModels.Update(alternativaAtualizada);
        await _context.SaveChangesAsync();

        return MapToDto(alternativaAtualizada);
    }

    public async Task DeleteAsync(int id)
    {
        var alternativa = await _context.AlternativaModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Alternativa não encontrada com id: {id}");

        _context.AlternativaModels.Remove(alternativa);
        await _context.SaveChangesAsync();
    }

    private AlternativaRequestDto MapToDto(AlternativaModel alternativa)
    {
        return new AlternativaRequestDto
        {
            Id = alternativa.Id,
            Pergunta = alternativa.Pergunta.Id,
            Descricao = alternativa.Descricao,
            ECorreta = alternativa.ECorreta
        };
    }
}
