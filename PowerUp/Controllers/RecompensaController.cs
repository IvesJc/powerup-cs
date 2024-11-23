using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/recompensa/")]
    public class RecompensaController : ControllerBase
    {
        private readonly IRecompensaService _recompensaService;

        public RecompensaController(IRecompensaService recompensaService)
        {
            _recompensaService = recompensaService;
        }

        // Endpoint para criar uma recompensa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RecompensaResponseDto recompensa)
        {
            var createdRecompensa = await _recompensaService.CreateAsync(recompensa);
            return CreatedAtAction(nameof(GetById), new { id = createdRecompensa.Id }, createdRecompensa);
        }

        // Endpoint para obter todas as recompensas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recompensaList = await _recompensaService.GetAllAsync();
            return Ok(recompensaList);
        }

        // Endpoint para obter uma recompensa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recompensa = await _recompensaService.GetByIdAsync(id);
            if (recompensa == null)
            {
                return NotFound(new { Message = "Recompensa não encontrada." });
            }

            return Ok(recompensa);
        }

        // Endpoint para atualizar uma recompensa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecompensaResponseDto recompensa)
        {
            var updatedRecompensa = await _recompensaService.UpdateAsync(id, recompensa);
            if (updatedRecompensa == null)
            {
                return NotFound(new { Message = "Recompensa não encontrada para atualização." });
            }

            return Ok(updatedRecompensa);
        }

        // Endpoint para deletar uma recompensa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _recompensaService.DeleteAsync(id);
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