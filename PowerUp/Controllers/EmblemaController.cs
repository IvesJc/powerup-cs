using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/emblema/")]
    public class EmblemaController : ControllerBase
    {
        private readonly IEmblemaService _emblemaService;

        public EmblemaController(IEmblemaService emblemaService)
        {
            _emblemaService = emblemaService;
        }

        // Endpoint para criar um emblema
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmblemaResponseDto emblema)
        {
            var createdEmblema = await _emblemaService.CreateAsync(emblema);
            return CreatedAtAction(nameof(GetById), new { id = createdEmblema.Id }, createdEmblema);
        }

        // Endpoint para obter todos os emblemas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emblemaList = await _emblemaService.GetAllAsync();
            return Ok(emblemaList);
        }

        // Endpoint para obter um emblema por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emblema = await _emblemaService.GetByIdAsync(id);
            if (emblema == null)
            {
                return NotFound();
            }

            return Ok(emblema);
        }

        // Endpoint para atualizar um emblema
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmblemaResponseDto emblema)
        {
            var updatedEmblema = await _emblemaService.UpdateAsync(id, emblema);
            if (updatedEmblema == null)
            {
                return NotFound();
            }

            return Ok(updatedEmblema);
        }

        // Endpoint para deletar um emblema
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _emblemaService.DeleteAsync(id);
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