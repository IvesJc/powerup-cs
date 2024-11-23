using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/quiz/")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // Endpoint para criar um quiz
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuizResponseDto quiz)
        {
            var createdQuiz = await _quizService.CreateAsync(quiz);
            return CreatedAtAction(nameof(GetById), new { id = createdQuiz.Id }, createdQuiz);
        }

        // Endpoint para obter todos os quizzes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quizList = await _quizService.GetAllAsync();
            return Ok(quizList);
        }

        // Endpoint para obter um quiz por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quiz = await _quizService.GetByIdAsync(id);
            if (quiz == null)
            {
                return NotFound(new { Message = "Quiz não encontrado." });
            }

            return Ok(quiz);
        }

        // Endpoint para atualizar um quiz
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuizResponseDto quiz)
        {
            var updatedQuiz = await _quizService.UpdateAsync(id, quiz);
            if (updatedQuiz == null)
            {
                return NotFound(new { Message = "Quiz não encontrado para atualização." });
            }

            return Ok(updatedQuiz);
        }

        // Endpoint para deletar um quiz
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _quizService.DeleteAsync(id);
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