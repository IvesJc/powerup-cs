using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

   [ApiController]
    [Route("api/v1/powerup/link/")]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;

        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        // Endpoint para criar um link
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LinkResponseDto link)
        {
            var createdLink = await _linkService.CreateAsync(link);
            return CreatedAtAction(nameof(GetById), new { id = createdLink.Id }, createdLink);
        }

        // Endpoint para obter todos os links
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var linkList = await _linkService.GetAllAsync();
            return Ok(linkList);
        }

        // Endpoint para obter um link por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var link = await _linkService.GetByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            return Ok(link);
        }

        // Endpoint para atualizar um link
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LinkResponseDto link)
        {
            var updatedLink = await _linkService.UpdateAsync(id, link);
            if (updatedLink == null)
            {
                return NotFound();
            }

            return Ok(updatedLink);
        }

        // Endpoint para deletar um link
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _linkService.DeleteAsync(id);
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