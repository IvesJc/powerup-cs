using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers;

[ApiController]
    [Route("api/v1/powerup/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Endpoint para criar um usuário
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioResponseDto usuario)
        {
            var createdUsuario = await _usuarioService.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = createdUsuario.Id }, createdUsuario);
        }

        // Endpoint para obter todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarioList = await _usuarioService.GetAllAsync();
            return Ok(usuarioList);
        }

        // Endpoint para obter um usuário por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            return Ok(usuario);
        }

        // Endpoint para atualizar um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioResponseDto usuario)
        {
            var updatedUsuario = await _usuarioService.UpdateAsync(id, usuario);
            if (updatedUsuario == null)
            {
                return NotFound(new { Message = "Usuário não encontrado para atualização." });
            }

            return Ok(updatedUsuario);
        }

        // Endpoint para deletar um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.DeleteAsync(id);
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