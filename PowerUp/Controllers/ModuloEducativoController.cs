using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/moduloEducativo/")]
    public class ModuloEducativoController : ControllerBase
    {
        private readonly IModuloEducativoService _moduloEducativoService;

        public ModuloEducativoController(IModuloEducativoService moduloEducativoService)
        {
            _moduloEducativoService = moduloEducativoService;
        }

        // Endpoint para criar um módulo educativo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModuloEducativoResponseDto moduloEducativo)
        {
            var createdModuloEducativo = await _moduloEducativoService.CreateAsync(moduloEducativo);
            return CreatedAtAction(nameof(GetById), new { id = createdModuloEducativo.Id }, createdModuloEducativo);
        }

        // Endpoint para obter todos os módulos educativos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var moduloEducativoList = await _moduloEducativoService.GetAllAsync();
            return Ok(moduloEducativoList);
        }

        // Endpoint para obter um módulo educativo por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var moduloEducativo = await _moduloEducativoService.GetByIdAsync(id);
            if (moduloEducativo == null)
            {
                return NotFound(new { Message = "Módulo educativo não encontrado." });
            }

            return Ok(moduloEducativo);
        }

        // Endpoint para atualizar um módulo educativo
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuloEducativoResponseDto moduloEducativo)
        {
            var updatedModuloEducativo = await _moduloEducativoService.UpdateAsync(id, moduloEducativo);
            if (updatedModuloEducativo == null)
            {
                return NotFound(new { Message = "Módulo educativo não encontrado para atualização." });
            }

            return Ok(updatedModuloEducativo);
        }

        // Endpoint para deletar um módulo educativo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _moduloEducativoService.DeleteAsync(id);
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