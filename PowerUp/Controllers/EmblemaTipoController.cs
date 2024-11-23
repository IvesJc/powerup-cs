using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/emblemaTipo/")]
    public class EmblemaTipoController : ControllerBase
    {
        private readonly IEmblemaTipoService _emblemaTipoService;

        public EmblemaTipoController(IEmblemaTipoService emblemaTipoService)
        {
            _emblemaTipoService = emblemaTipoService;
        }

        // Endpoint para criar um emblema tipo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmblemaTipoResponseDto emblemaTipo)
        {
            var createdEmblemaTipo = await _emblemaTipoService.CreateAsync(emblemaTipo);
            return CreatedAtAction(nameof(GetById), new { id = createdEmblemaTipo.Id }, createdEmblemaTipo);
        }

        // Endpoint para obter todos os emblemas tipo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emblemaTipoList = await _emblemaTipoService.GetAllAsync();
            return Ok(emblemaTipoList);
        }

        // Endpoint para obter um emblema tipo por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emblemaTipo = await _emblemaTipoService.GetByIdAsync(id);
            if (emblemaTipo == null)
            {
                return NotFound();
            }

            return Ok(emblemaTipo);
        }

        // Endpoint para atualizar um emblema tipo
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmblemaTipoResponseDto emblemaTipo)
        {
            var updatedEmblemaTipo = await _emblemaTipoService.UpdateAsync(id, emblemaTipo);
            if (updatedEmblemaTipo == null)
            {
                return NotFound();
            }

            return Ok(updatedEmblemaTipo);
        }

        // Endpoint para deletar um emblema tipo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _emblemaTipoService.DeleteAsync(id);
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