using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Dto.Livro;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Autor;
using WebApi8_Video.Services.Livro;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLIvros")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        /// <summary>
        /// Retorna um livro pelo ID.
        /// </summary>
        /// <param name="idLivro">ID do livro</param>
        /// <returns>Livro encontrado ou 404</returns>
        [HttpGet("BuscarLivroPorId/{idLivro}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<LivroRespostaDto>>> BuscarLivroPorId(int idLivro)
        {
            var resposta = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(resposta);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var autor = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(autor);
        }

        [HttpPost("CriarLivro/")]
        [Consumes("application/json")]
        public async Task<ActionResult<ResponseModel<LivroRespostaDto>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);

            return CreatedAtAction(
                nameof(BuscarLivroPorId),
                new { idLivro = livro.Dados.Id },
                livro
            );
        }

    }
}
