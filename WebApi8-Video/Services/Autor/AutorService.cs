using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FindAsync(idAutor);

                if (autor == null) 
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Autor não encontrado, que merda ein!";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Localizamos o autor loco véio!";
                return resposta;
            } 
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Nenhum autor atrelado a este livro";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Deu boa bixo véio, pega ai o autor do livro";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = new AutorModel();
                autor.Nome = autorCriacaoDto.Nome;
                autor.Sobrenome = autorCriacaoDto.Sobrenome;

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Ta ai o autor novo bixo!";

                return resposta;
            } 
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto autorEdicaoDto, int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FindAsync(idAutor);

                if (autor == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Autor não encontrado, que merda ein!";
                    return resposta;
                }

                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Ta ai o autor novo bixo!";

                return resposta;
            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<bool> ExcluirAutor(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FindAsync(idAutor);

                if (autor == null)
                    return false;

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return false;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            
            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Deu boa bixo véio";
                return resposta;
            } 
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
