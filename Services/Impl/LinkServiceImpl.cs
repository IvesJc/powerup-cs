using Microsoft.EntityFrameworkCore;
using PowerUp.Data;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Exceptions;
using PowerUp.Models;

namespace PowerUp.Services.Impl;

public class LinkServiceImpl : ILinkService
{
    private readonly AppDbContext _context;

    public LinkServiceImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LinkRequestDto> CreateAsync(LinkResponseDto linkResponseDto)
    {
        var newLink = new LinkModel()
        {
            Url = linkResponseDto.Url,
            Descricao = linkResponseDto.Descricao
        };

        _context.LinkModels.Add(newLink);
        await _context.SaveChangesAsync();

        return MapToDTO(newLink);
    }

    public async Task<List<LinkRequestDto>> GetAllAsync()
    {
        return await _context.LinkModels
            .Select(l => MapToDTO(l))
            .ToListAsync();
    }

    public async Task<LinkRequestDto> GetByIdAsync(int id)
    {
        var link = await _context.LinkModels
                       .FirstOrDefaultAsync(l => l.Id == id)
                   ?? throw new NotFoundException($"Link not found with id: {id}");

        return MapToDTO(link);
    }

    public async Task<LinkRequestDto> UpdateAsync(int id, LinkResponseDto linkResponseDto)
    {
        var link = await _context.LinkModels
                       .FirstOrDefaultAsync(l => l.Id == id)
                   ?? throw new NotFoundException($"Link not found with id: {id}");

        link.Url = linkResponseDto.Url;
        link.Descricao = linkResponseDto.Descricao;

        _context.LinkModels.Update(link);
        await _context.SaveChangesAsync();

        return MapToDTO(link);
    }

    public async Task DeleteAsync(int id)
    {
        var link = await _context.LinkModels
                       .FirstOrDefaultAsync(l => l.Id == id)
                   ?? throw new NotFoundException($"Link not found with id: {id}");

        _context.LinkModels.Remove(link);
        await _context.SaveChangesAsync();
    }

    private LinkRequestDto MapToDTO(LinkModel link)
    {
        return new LinkRequestDto
        {
            Id = link.Id,
            Url = link.Url,
            Descricao = link.Descricao
        };
    }
}
