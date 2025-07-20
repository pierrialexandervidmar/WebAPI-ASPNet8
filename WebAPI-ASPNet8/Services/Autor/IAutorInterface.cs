using WebAPI_ASPNet8.Dto.Autor;
using WebAPI_ASPNet8.Models;

namespace WebAPI_ASPNet8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto autorEdicaoDto, int idAutor);
        Task<bool> ExcluirAutor(int idAutor);
    }
}
