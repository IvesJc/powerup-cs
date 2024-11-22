using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;

namespace PowerUp.Services.Impl;

public class EmblemaConfigServiceImpl : IEmblemaConfigService
{
    private readonly AppDbContext _context;

    public EmblemaConfigServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmblemaConfigRequestDto> CreateAsync(EmblemaConfigResponseDto emblemaConfigResponseDto)
    {
        var emblemaTipo = await _context.EmblemaModelTipos
            .FirstOrDefaultAsync(et => et.Id == emblemaConfigResponseDto.EmblemaTipo)
            ?? throw new NotFoundException($"EmblemaTipo not found with id: {emblemaConfigResponseDto.EmblemaTipo}");

        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == emblemaConfigResponseDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {emblemaConfigResponseDto.Quiz}");

        var newEmblemaConfig = new EmblemaConfigModel()
        {
            Nome = emblemaConfigResponseDto.Nome,
            Descricao = emblemaConfigResponseDto.Descricao,
            EmblemaTipoId = emblemaTipo.Id,
            QuizId = quiz.Id
        };

        _context.EmblemaConfigModels.Add(newEmblemaConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(newEmblemaConfig);
    }

    public async Task<List<EmblemaConfigRequestDto>> GetAllAsync()
    {
        return await _context.EmblemaConfigModels
            .Select(ec => MapToDTO(ec))
            .ToListAsync();
    }

    public async Task<EmblemaConfigRequestDto> GetByIdAsync(int id)
    {
        var emblemaConfig = await _context.EmblemaConfigModels
            .FirstOrDefaultAsync(ec => ec.Id == id)
            ?? throw new NotFoundException($"EmblemaConfig not found with id: {id}");

        return MapToDTO(emblemaConfig);
    }

    public async Task<EmblemaConfigRequestDto> UpdateAsync(int id, EmblemaConfigResponseDto emblemaConfigResponseDto)
    {
        var emblemaConfig = await _context.EmblemaConfigModels
            .FirstOrDefaultAsync(ec => ec.Id == id)
            ?? throw new NotFoundException($"EmblemaConfig not found with id: {id}");

        var emblemaTipo = await _context.EmblemaModelTipos
            .FirstOrDefaultAsync(et => et.Id == emblemaConfigResponseDto.EmblemaTipo)
            ?? throw new NotFoundException($"EmblemaTipo not found with id: {emblemaConfigResponseDto.EmblemaTipo}");

        var quiz = await _context.QuizModels
            .FirstOrDefaultAsync(q => q.Id == emblemaConfigResponseDto.Quiz)
            ?? throw new NotFoundException($"Quiz not found with id: {emblemaConfigResponseDto.Quiz}");

        emblemaConfig.Nome = emblemaConfigResponseDto.Nome;
        emblemaConfig.Descricao = emblemaConfigResponseDto.Descricao;
        emblemaConfig.EmblemaTipoId = emblemaTipo.Id;
        emblemaConfig.QuizId = quiz.Id;

        _context.EmblemaConfigModels.Update(emblemaConfig);
        await _context.SaveChangesAsync();

        return MapToDTO(emblemaConfig);
    }

    public async Task DeleteAsync(int id)
    {
        var emblemaConfig = await _context.EmblemaConfigModels
            .FirstOrDefaultAsync(ec => ec.Id == id)
            ?? throw new NotFoundException($"EmblemaConfig not found with id: {id}");

        _context.EmblemaConfigModels.Remove(emblemaConfig);
        await _context.SaveChangesAsync();
    }

    private EmblemaConfigRequestDto MapToDTO(EmblemaConfigModel emblemaConfig)
    {
        return new EmblemaConfigRequestDto
        {
            Id = emblemaConfig.Id,
            Nome = emblemaConfig.Nome,
            Descricao = emblemaConfig.Descricao,
            EmblemaTipo = emblemaConfig.EmblemaTipo.Id,
            Quiz = emblemaConfig.Quiz.Id
        };
    }
}
