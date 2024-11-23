using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
[Route("api/v1/powerup/desafio/")]
public class DesafioController : ControllerBase
{
    private readonly IDesafioService _desafioService;

    public DesafioController(IDesafioService desafioService)
    {
        _desafioService = desafioService;
    }

    // Endpoint para criar um desafio
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DesafioResponseDto desafio)
    {
        var createdDesafio = await _desafioService.CreateAsync(desafio);
        return CreatedAtAction(nameof(GetById), new { id = createdDesafio.Id }, createdDesafio);
    }

    // Endpoint para obter todos os desafios
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var desafioList = await _desafioService.GetAllAsync();
        return Ok(desafioList);
    }

    // Endpoint para obter um desafio por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var desafio = await _desafioService.GetByIdAsync(id);
        if (desafio == null)
        {
            return NotFound();
        }

        return Ok(desafio);
    }

    // Endpoint para atualizar um desafio
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DesafioResponseDto desafio)
    {
        var updatedDesafio = await _desafioService.UpdateAsync(id, desafio);
        if (updatedDesafio == null)
        {
            return NotFound();
        }

        return Ok(updatedDesafio);
    }

    // Endpoint para deletar um desafio
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _desafioService.DeleteAsync(id);
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