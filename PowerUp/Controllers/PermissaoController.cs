using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/permissao/")]
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoService _permissaoService;

        public PermissaoController(IPermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        // Endpoint para criar uma permissão
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PermissaoResponseDto permissao)
        {
            var createdPermissao = await _permissaoService.CreateAsync(permissao);
            return CreatedAtAction(nameof(GetById), new { id = createdPermissao.Id }, createdPermissao);
        }

        // Endpoint para obter todas as permissões
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissaoList = await _permissaoService.GetAllAsync();
            return Ok(permissaoList);
        }

        // Endpoint para obter uma permissão por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permissao = await _permissaoService.GetByIdAsync(id);
            if (permissao == null)
            {
                return NotFound(new { Message = "Permissão não encontrada." });
            }

            return Ok(permissao);
        }

        // Endpoint para atualizar uma permissão
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermissaoResponseDto permissao)
        {
            var updatedPermissao = await _permissaoService.UpdateAsync(id, permissao);
            if (updatedPermissao == null)
            {
                return NotFound(new { Message = "Permissão não encontrada para atualização." });
            }

            return Ok(updatedPermissao);
        }

        // Endpoint para deletar uma permissão
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _permissaoService.DeleteAsync(id);
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