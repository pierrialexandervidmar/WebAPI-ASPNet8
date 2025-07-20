using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Autor;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface) 
        {
            _autorInterface = autorInterface;            
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{id}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorId(id);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        { 
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autor = await _autorInterface.CriarAutor(autorCriacaoDto);
            
            return CreatedAtAction(
                nameof(BuscarAutorPorId),
                new { id = autor.Dados.Id },
                autor
             );
        }

        [HttpPut("EditarAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto, int idAutor)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicaoDto, idAutor);
            return Ok(autor);
        }

        [HttpDelete("ExcluirAutor/{idAutor}")]
        public async Task<IActionResult> ExcluirAutor(int idAutor)
        {
            var autor = await _autorInterface.ExcluirAutor(idAutor);

            if (!autor)
            {
                return NotFound(new
                {
                    status = false,
                    mensagem = "Autor não encontrado."
                });
            }

            return NoContent();
        }
    }
}
