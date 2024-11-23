using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
[Route("api/v1/powerup/artigo/")]
public class ArtigoController : ControllerBase
{
    private readonly IArtigoService _artigoService;

    public ArtigoController(IArtigoService artigoService)
    {
        _artigoService = artigoService;
    }

    // Endpoint para criar um artigo
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ArtigoResponseDto artigo)
    {
        var createdArtigo = await _artigoService.CreateAsync(artigo);
        return CreatedAtAction(nameof(GetById), new { id = createdArtigo.Id }, createdArtigo);
    }

    // Endpoint para obter todos os artigos
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var artigoList = await _artigoService.GetAllAsync();
        return Ok(artigoList);
    }

    // Endpoint para obter um artigo por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var artigo = await _artigoService.GetByIdAsync(id);
        if (artigo == null)
        {
            return NotFound();
        }

        return Ok(artigo);
    }

    // Endpoint para atualizar um artigo
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ArtigoResponseDto artigo)
    {
        var updatedArtigo = await _artigoService.UpdateAsync(id, artigo);
        if (updatedArtigo == null)
        {
            return NotFound();
        }

        return Ok(updatedArtigo);
    }

    // Endpoint para deletar um artigo
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _artigoService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno no servidor.", Details = ex.Message });
        }
    }
}