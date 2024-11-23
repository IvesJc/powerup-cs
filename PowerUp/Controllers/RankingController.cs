using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

 [ApiController]
    [Route("api/v1/powerup/ranking/")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        // Endpoint para criar um ranking
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RankingResponseDto ranking)
        {
            var createdRanking = await _rankingService.CreateAsync(ranking);
            return CreatedAtAction(nameof(GetById), new { id = createdRanking.Id }, createdRanking);
        }

        // Endpoint para obter todos os rankings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rankingList = await _rankingService.GetAllAsync();
            return Ok(rankingList);
        }

        // Endpoint para obter um ranking por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ranking = await _rankingService.GetByIdAsync(id);
            if (ranking == null)
            {
                return NotFound(new { Message = "Ranking não encontrado." });
            }

            return Ok(ranking);
        }

        // Endpoint para atualizar um ranking
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RankingResponseDto ranking)
        {
            var updatedRanking = await _rankingService.UpdateAsync(id, ranking);
            if (updatedRanking == null)
            {
                return NotFound(new { Message = "Ranking não encontrado para atualização." });
            }

            return Ok(updatedRanking);
        }

        // Endpoint para deletar um ranking
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _rankingService.DeleteAsync(id);
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