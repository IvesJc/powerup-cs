using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/missao/")]
    public class MissaoController : ControllerBase
    {
        private readonly IMissaoService _missaoService;

        public MissaoController(IMissaoService missaoService)
        {
            _missaoService = missaoService;
        }

        // Endpoint para criar uma missão
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MissaoResponseDto missao)
        {
            var createdMissao = await _missaoService.CreateAsync(missao);
            return CreatedAtAction(nameof(GetById), new { id = createdMissao.Id }, createdMissao);
        }

        // Endpoint para obter todas as missões
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var missaoList = await _missaoService.GetAllAsync();
            return Ok(missaoList);
        }

        // Endpoint para obter uma missão por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var missao = await _missaoService.GetByIdAsync(id);
            if (missao == null)
            {
                return NotFound(new { Message = "Missão não encontrada." });
            }

            return Ok(missao);
        }

        // Endpoint para atualizar uma missão
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MissaoResponseDto missao)
        {
            var updatedMissao = await _missaoService.UpdateAsync(id, missao);
            if (updatedMissao == null)
            {
                return NotFound(new { Message = "Missão não encontrada para atualização." });
            }

            return Ok(updatedMissao);
        }

        // Endpoint para deletar uma missão
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _missaoService.DeleteAsync(id);
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