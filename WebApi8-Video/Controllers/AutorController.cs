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

        /// <summary>
        /// Retorna todos os autores cadastrados.
        /// </summary>
        /// <returns>Lista de autores</returns>
        [HttpGet("ListarAutores")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        /// <summary>
        /// Retorna os dados de um autor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do autor</param>
        /// <returns>Autor encontrado ou mensagem de erro</returns>
        [HttpGet("BuscarAutorPorId/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int id)
        {
            var autor = await _autorInterface.BuscarAutorPorId(id);
            return Ok(autor);
        }

        /// <summary>
        /// Retorna o autor associado a um livro específico.
        /// </summary>
        /// <param name="idLivro">ID do livro</param>
        /// <returns>Autor correspondente ao livro ou mensagem de erro</returns>
        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        /// <summary>
        /// Cria um novo autor.
        /// </summary>
        /// <param name="autorCriacaoDto">Dados do autor a ser criado</param>
        /// <returns>Autor criado com status 201</returns>
        [HttpPost("CriarAutor")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autor = await _autorInterface.CriarAutor(autorCriacaoDto);

            return CreatedAtAction(
                nameof(BuscarAutorPorId),
                new { id = autor.Dados.Id },
                autor
             );
        }

        /// <summary>
        /// Edita os dados de um autor existente.
        /// </summary>
        /// <param name="autorEdicaoDto">Dados atualizados do autor</param>
        /// <param name="idAutor">ID do autor a ser editado</param>
        /// <returns>Autor atualizado ou mensagem de erro</returns>
        [HttpPut("EditarAutor/{idAutor}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto, int idAutor)
        {
            var autor = await _autorInterface.EditarAutor(autorEdicaoDto, idAutor);
            return Ok(autor);
        }

        /// <summary>
        /// Exclui um autor do sistema.
        /// </summary>
        /// <param name="idAutor">ID do autor a ser excluído</param>
        /// <returns>Status 204 se excluído com sucesso, 404 se não encontrado</returns>
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
