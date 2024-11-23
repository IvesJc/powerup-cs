using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;

namespace PowerUp.Services.Impl;

public class ArtigoServiceImpl : IArtigoService
{
    private readonly AppDbContext _context;

    public ArtigoServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ArtigoRequestDto> CreateAsync(ArtigoResponseDto artigoDto)
    {
        // Verificando se o link existe
        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == artigoDto.ThumbLink) 
            ?? throw new NotFoundException($"Link not found with id: {artigoDto.ThumbLink}");

        // Verificando se o módulo educativo existe
        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(m => m.Id == artigoDto.ModuloEducativo)
            ?? throw new NotFoundException($"Educativo not found with id: {artigoDto.ModuloEducativo}");

        // Criando o novo artigo
        var artigo = new ArtigoModel
        {
            Titulo = artigoDto.Titulo,
            Subtitulo = artigoDto.Subtitulo,
            Conteudo = artigoDto.Conteudo,
            ThumbLink = link,
            ModuloEducativoId = moduloEducativo.Id
        };

        _context.ArtigoModels.Add(artigo);
        await _context.SaveChangesAsync();

        return MapToDto(artigo);
    }

    public async Task<List<ArtigoRequestDto>> GetAllAsync()
    {
        return await _context.ArtigoModels
            .Select(a => MapToDto(a))
            .ToListAsync();
    }

    public async Task<ArtigoRequestDto> GetByIdAsync(int id)
    {
        var artigo = await _context.ArtigoModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Artigo not found with id: {id}");

        return MapToDto(artigo);
    }

    public async Task<ArtigoRequestDto> UpdateAsync(int id, ArtigoResponseDto artigoDto)
    {
        var updatedArtigo = await _context.ArtigoModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Artigo not found with id: {id}");

        var link = await _context.LinkModels
            .FirstOrDefaultAsync(l => l.Id == artigoDto.ThumbLink)
            ?? throw new NotFoundException($"Link not found with id: {artigoDto.ThumbLink}");

        var moduloEducativo = await _context.ModuloEducativoModels
            .FirstOrDefaultAsync(m => m.Id == artigoDto.ModuloEducativo)
            ?? throw new NotFoundException($"Educativo not found with id: {artigoDto.ModuloEducativo}");

        // Atualizando os dados do artigo
        updatedArtigo.Titulo = artigoDto.Titulo;
        updatedArtigo.Subtitulo = artigoDto.Subtitulo;
        updatedArtigo.Conteudo = artigoDto.Conteudo;
        updatedArtigo.ThumbLink = link;
        updatedArtigo.ModuloEducativoId = moduloEducativo.Id;

        _context.ArtigoModels.Update(updatedArtigo);
        await _context.SaveChangesAsync();

        return MapToDto(updatedArtigo);
    }

    public async Task DeleteAsync(int id)
    {
        var artigo = await _context.ArtigoModels
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? throw new NotFoundException($"Artigo not found with id: {id}");

        _context.ArtigoModels.Remove(artigo);
        await _context.SaveChangesAsync();
    }

    private  static ArtigoRequestDto MapToDto(ArtigoModel artigo)
    {
        return new ArtigoRequestDto
        {
            Id = artigo.Id,
            Titulo = artigo.Titulo,
            Subtitulo = artigo.Subtitulo,
            Conteudo = artigo.Conteudo,
            ThumbLink = artigo.ThumbLink.Id,
            ModuloEducativo = artigo.ModuloEducativoId
        };
    }
}
