using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/pergunta/")]
    public class PerguntaController : ControllerBase
    {
        private readonly IPerguntaService _perguntaService;

        public PerguntaController(IPerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }

        // Endpoint para criar uma pergunta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerguntaResponseDto pergunta)
        {
            var createdPergunta = await _perguntaService.CreateAsync(pergunta);
            return CreatedAtAction(nameof(GetById), new { id = createdPergunta.Id }, createdPergunta);
        }

        // Endpoint para obter todas as perguntas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var perguntaList = await _perguntaService.GetAllAsync();
            return Ok(perguntaList);
        }

        // Endpoint para obter uma pergunta por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pergunta = await _perguntaService.GetByIdAsync(id);
            if (pergunta == null)
            {
                return NotFound(new { Message = "Pergunta não encontrada." });
            }

            return Ok(pergunta);
        }

        // Endpoint para atualizar uma pergunta
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PerguntaResponseDto pergunta)
        {
            var updatedPergunta = await _perguntaService.UpdateAsync(id, pergunta);
            if (updatedPergunta == null)
            {
                return NotFound(new { Message = "Pergunta não encontrada para atualização." });
            }

            return Ok(updatedPergunta);
        }

        // Endpoint para deletar uma pergunta
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _perguntaService.DeleteAsync(id);
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