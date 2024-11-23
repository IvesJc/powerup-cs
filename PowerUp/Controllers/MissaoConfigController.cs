using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/missaoConfig/")]
    public class MissaoConfigController : ControllerBase
    {
        private readonly IMissaoConfigService _missaoConfigService;

        public MissaoConfigController(IMissaoConfigService missaoConfigService)
        {
            _missaoConfigService = missaoConfigService;
        }

        // Endpoint para criar uma configuração de missão
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MissaoConfigResponseDto missaoConfig)
        {
            var createdMissaoConfig = await _missaoConfigService.CreateAsync(missaoConfig);
            return CreatedAtAction(nameof(GetById), new { id = createdMissaoConfig.Id }, createdMissaoConfig);
        }

        // Endpoint para obter todas as configurações de missão
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var missaoConfigList = await _missaoConfigService.GetAllAsync();
            return Ok(missaoConfigList);
        }

        // Endpoint para obter uma configuração de missão por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var missaoConfig = await _missaoConfigService.GetByIdAsync(id);
            if (missaoConfig == null)
            {
                return NotFound(new { Message = "Configuração de missão não encontrada." });
            }

            return Ok(missaoConfig);
        }

        // Endpoint para atualizar uma configuração de missão
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MissaoConfigResponseDto missaoConfig)
        {
            var updatedMissaoConfig = await _missaoConfigService.UpdateAsync(id, missaoConfig);
            if (updatedMissaoConfig == null)
            {
                return NotFound(new { Message = "Configuração de missão não encontrada para atualização." });
            }

            return Ok(updatedMissaoConfig);
        }

        // Endpoint para deletar uma configuração de missão
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _missaoConfigService.DeleteAsync(id);
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