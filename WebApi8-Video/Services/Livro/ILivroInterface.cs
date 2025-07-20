using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Dto.Livro;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroRespostaDto>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<LivroRespostaDto>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<LivroModel>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<bool> ExcluirLivro(int idLivro);
    }
}
