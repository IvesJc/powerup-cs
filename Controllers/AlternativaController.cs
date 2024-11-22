using Microsoft.AspNetCore.Mvc;
using PowerUp.Dto.Response;
using PowerUp.Services;

namespace PowerUp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PowerUp.Controllers
{
    [ApiController]
    [Route("api/v1/powerup/alternativa/")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Alternativa")]
    public class AlternativaController : Controller
    {
        private readonly IAlternativaService _alternativaService;

        public AlternativaController(IAlternativaService alternativaService)
        {
            _alternativaService = alternativaService;
        }

        [HttpGet]
        [Route("index")]  // Ajustado para corresponder à rota
        public IActionResult Index()
        {
            return View();  // Exemplo de retorno
        }

        // Método GET para cadastrar
        [HttpGet]
        [Route("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();  // Exemplo de retorno
        }
        
        // // Endpoint para criar uma alternativa
        // [HttpPost]
        // public IActionResult Create([FromBody] AlternativaResponseDto alternativa)
        // {
        //     var createdAlternativa = _alternativaService.CreateAsync(alternativa);
        //     return CreatedAtAction(nameof(GetById), new { id = createdAlternativa.Id }, createdAlternativa);
        // }
        //
        // // Endpoint para obter todas as alternativas
        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     var alternativaList = _alternativaService.GetAllAsync();
        //     return Ok(alternativaList);
        // }
        //
        // // Endpoint para obter uma alternativa por ID
        // [HttpGet("{id:int}")]
        // public IActionResult GetById(int id)
        // {
        //     var alternativa = _alternativaService.GetByIdAsync(id);
        //     if (alternativa == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(alternativa);
        // }
        //
        // // Endpoint para atualizar uma alternativa
        // [HttpPut("{id:int}")]
        // public IActionResult Update(int id, [FromBody] AlternativaResponseDto alternativa)
        // {
        //     var updatedAlternativa = _alternativaService.UpdateAsync(id, alternativa);
        //     if (updatedAlternativa == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(updatedAlternativa);
        // }

        // Endpoint para deletar uma alternativa
        // [HttpDelete("{id:int}")]
        // public IActionResult Delete(int id)
        // {
        //     var exists = _alternativaService.DeleteAsync(id);
        //     if (exists.Id.)
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }
    }
}

}
