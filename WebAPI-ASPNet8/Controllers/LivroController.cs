using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ASPNet8.Dto.Livro;
using WebAPI_ASPNet8.Models;
using WebAPI_ASPNet8.Services.Livro;

namespace WebAPI_ASPNet8.Controllers
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

        /// <summary>
        /// Retorna todos os livros cadastrados.
        /// </summary>
        /// <returns>Lista de livros</returns>
        [HttpGet("ListarLivros")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        /// <summary>
        /// Retorna os dados de um livro específico pelo ID.
        /// </summary>
        /// <param name="idLivro">ID do livro a ser consultado</param>
        /// <returns>Livro encontrado ou mensagem de erro</returns>
        [HttpGet("BuscarLivroPorId/{idLivro}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<LivroRespostaDto>>> BuscarLivroPorId(int idLivro)
        {
            var resposta = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(resposta);
        }

        /// <summary>
        /// Retorna todos os livros de um autor específico.
        /// </summary>
        /// <param name="idAutor">ID do autor</param>
        /// <returns>Lista de livros vinculados ao autor</returns>
        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var autor = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
            return Ok(autor);
        }

        /// <summary>
        /// Cria um novo livro no sistema.
        /// </summary>
        /// <param name="livroCriacaoDto">Dados para criação do livro</param>
        /// <returns>Livro criado com status 201</returns>
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

        /// <summary>
        /// Atualiza os dados de um livro existente.
        /// </summary>
        /// <param name="livroEdicaoDto">Dados atualizados do livro</param>
        /// <param name="idLivro">ID do livro a ser editado</param>
        /// <returns>Livro atualizado ou erro</returns>
        [HttpPut("EditarLivro/{idLivro}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<LivroRespostaDto>>> EditarLivro(LivroEdicaoDto livroEdicaoDto, int idLivro)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto, idLivro);
            return Ok(livro);
        }

        /// <summary>
        /// Exclui um livro do sistema.
        /// </summary>
        /// <param name="idLivro">ID do livro a ser excluído</param>
        /// <returns>Status 204 se excluído, 404 se não encontrado</returns>
        [HttpDelete("ExcluirLivro/{idLivro}")]
        public async Task<IActionResult> ExcluirLivro(int idLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(idLivro);

            if (!livro)
            {
                return NotFound(new
                {
                    status = false,
                    mensagem = "Livro não encontrado."
                });
            }

            return NoContent();
        }
    }
}
