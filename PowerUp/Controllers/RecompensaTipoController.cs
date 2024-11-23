using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/recompensaTipo")]
    public class RecompensaTipoController : ControllerBase
    {
        private readonly IRecompensaTipoService _recompensaTipoService;

        public RecompensaTipoController(IRecompensaTipoService recompensaTipoService)
        {
            _recompensaTipoService = recompensaTipoService;
        }

        // Endpoint para criar um tipo de recompensa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RecompensaTipoResponseDto recompensaTipo)
        {
            var createdRecompensaTipo = await _recompensaTipoService.CreateAsync(recompensaTipo);
            return CreatedAtAction(nameof(GetById), new { id = createdRecompensaTipo.Id }, createdRecompensaTipo);
        }

        // Endpoint para obter todos os tipos de recompensa
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recompensaTipoList = await _recompensaTipoService.GetAllAsync();
            return Ok(recompensaTipoList);
        }

        // Endpoint para obter um tipo de recompensa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recompensaTipo = await _recompensaTipoService.GetByIdAsync(id);
            if (recompensaTipo == null)
            {
                return NotFound(new { Message = "Tipo de recompensa não encontrado." });
            }

            return Ok(recompensaTipo);
        }

        // Endpoint para atualizar um tipo de recompensa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecompensaTipoResponseDto recompensaTipo)
        {
            var updatedRecompensaTipo = await _recompensaTipoService.UpdateAsync(id, recompensaTipo);
            if (updatedRecompensaTipo == null)
            {
                return NotFound(new { Message = "Tipo de recompensa não encontrado para atualização." });
            }

            return Ok(updatedRecompensaTipo);
        }

        // Endpoint para deletar um tipo de recompensa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _recompensaTipoService.DeleteAsync(id);
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