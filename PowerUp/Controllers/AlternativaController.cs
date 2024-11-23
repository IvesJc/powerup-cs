using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;


namespace PowerUp.Controllers
{
    [ApiController]
    [Route("api/v1/powerup/alternativa/")]
    public class AlternativaController : ControllerBase
    {
        private readonly IAlternativaService _alternativaService;

        public AlternativaController(IAlternativaService alternativaService)
        {
            _alternativaService = alternativaService;
        }

        // Endpoint para criar uma alternativa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlternativaResponseDto alternativa)
        {
            var createdAlternativa = await _alternativaService.CreateAsync(alternativa);
            return CreatedAtAction(nameof(GetById), new { id = createdAlternativa.Id }, createdAlternativa);
        }

        // Endpoint para obter todas as alternativas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alternativaList = await _alternativaService.GetAllAsync();
            return Ok(alternativaList);
        }

        // Endpoint para obter uma alternativa por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alternativa = await _alternativaService.GetByIdAsync(id);
            if (alternativa == null)
            {
                return NotFound();
            }

            return Ok(alternativa);
        }

        // Endpoint para atualizar uma alternativa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlternativaResponseDto alternativa)
        {
            var updatedAlternativa = await _alternativaService.UpdateAsync(id, alternativa);
            if (updatedAlternativa == null)
            {
                return NotFound();
            }

            return Ok(updatedAlternativa);
        }

        // Endpoint para deletar uma alternativa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alternativaService.DeleteAsync(id);
                return NoContent(); // Retorna 204 (No Content) quando a exclusão for bem-sucedida
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message }); // Retorna 404 (Not Found) se o ID não for encontrado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = ex.Message }); // Retorna 500 (Internal Server Error) para erros inesperados
            }
        }
    }
}