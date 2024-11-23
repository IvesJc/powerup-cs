using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/emblemaConfig/")]
    public class EmblemaConfigController : ControllerBase
    {
        private readonly IEmblemaConfigService _emblemaConfigService;

        public EmblemaConfigController(IEmblemaConfigService emblemaConfigService)
        {
            _emblemaConfigService = emblemaConfigService;
        }

        // Endpoint para criar uma configuração de emblema
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmblemaConfigResponseDto emblemaConfig)
        {
            var createdEmblemaConfig = await _emblemaConfigService.CreateAsync(emblemaConfig);
            return CreatedAtAction(nameof(GetById), new { id = createdEmblemaConfig.Id }, createdEmblemaConfig);
        }

        // Endpoint para obter todas as configurações de emblemas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emblemaConfigList = await _emblemaConfigService.GetAllAsync();
            return Ok(emblemaConfigList);
        }

        // Endpoint para obter uma configuração de emblema por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emblemaConfig = await _emblemaConfigService.GetByIdAsync(id);
            if (emblemaConfig == null)
            {
                return NotFound();
            }

            return Ok(emblemaConfig);
        }

        // Endpoint para atualizar uma configuração de emblema
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmblemaConfigResponseDto emblemaConfig)
        {
            var updatedEmblemaConfig = await _emblemaConfigService.UpdateAsync(id, emblemaConfig);
            if (updatedEmblemaConfig == null)
            {
                return NotFound();
            }

            return Ok(updatedEmblemaConfig);
        }

        // Endpoint para deletar uma configuração de emblema
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _emblemaConfigService.DeleteAsync(id);
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