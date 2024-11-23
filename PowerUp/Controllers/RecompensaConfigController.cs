using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Request;
using PowerUp.Dto.Response;
using PowerUp.Services;
using PowerUp.Services.Impl;

namespace PowerUp.Controllers;

[ApiController]
[Route("api/v1/powerup/recompensaConfig/")]
public class RecompensaConfigController : ControllerBase
{
    private readonly IRecompensaConfigService _recompensaConfigService;

    public RecompensaConfigController(IRecompensaConfigService recompensaConfigService)
    {
        _recompensaConfigService = recompensaConfigService;
    }

    // Endpoint para criar uma configuração de recompensa
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RecompensaConfigResponseDto recompensaConfig)
    {
        var createdRecompensaConfig = await _recompensaConfigService.CreateAsync(recompensaConfig);
        return CreatedAtAction(nameof(GetById), new { id = createdRecompensaConfig.Id }, createdRecompensaConfig);
    }

    // Endpoint para obter todas as configurações de recompensa
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var recompensaConfigList = await _recompensaConfigService.GetAllAsync();
        return Ok(recompensaConfigList);
    }

    // Endpoint para obter uma configuração de recompensa por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var recompensaConfig = await _recompensaConfigService.GetByIdAsync(id);
        if (recompensaConfig == null)
        {
            return NotFound(new { Message = "Configuração de recompensa não encontrada." });
        }

        return Ok(recompensaConfig);
    }

    // Endpoint para atualizar uma configuração de recompensa
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RecompensaConfigResponseDto recompensaConfig)
    {
        var updatedRecompensaConfig = await _recompensaConfigService.UpdateAsync(id, recompensaConfig);
        if (updatedRecompensaConfig == null)
        {
            return NotFound(new { Message = "Configuração de recompensa não encontrada para atualização." });
        }

        return Ok(updatedRecompensaConfig);
    }

    // Endpoint para deletar uma configuração de recompensa
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _recompensaConfigService.DeleteAsync(id);
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