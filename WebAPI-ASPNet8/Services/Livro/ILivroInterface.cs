using WebAPI_ASPNet8.Dto.Autor;
using WebAPI_ASPNet8.Dto.Livro;
using WebAPI_ASPNet8.Models;

namespace WebAPI_ASPNet8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroRespostaDto>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<LivroRespostaDto>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<LivroRespostaDto>> EditarLivro(LivroEdicaoDto livroEdicaoDto, int idLivro);
        Task<bool> ExcluirLivro(int idLivro);
    }
}
