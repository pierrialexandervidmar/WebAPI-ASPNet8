using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI_ASPNet8.Data;
using WebAPI_ASPNet8.Dto.Livro;
using WebAPI_ASPNet8.Models;

namespace WebAPI_ASPNet8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroRespostaDto>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroRespostaDto> resposta = new ResponseModel<LivroRespostaDto>();

            try
            {
                var livro = await _context.Livros
                    .Include(l => l.Autor)
                    .FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null)
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Livro não encontrado, deu ruim!";
                    return resposta;
                }

                // Aqui você converte para DTO manualmente
                var dto = new LivroRespostaDto
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    AutorId = livro.AutorId
                };

                resposta.Dados = dto;
                resposta.Mensagem = "Localizamos o livro, deu boa bixo!!";
                return resposta;
            } catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = ex.Message;
                return resposta;
            }
        }


        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                    .Where(livro => livro.AutorId == idAutor)
                    .Include(a => a.Autor)
                    .ToListAsync();

                if (livros == null || !livros.Any())
                {
                    resposta.Status = false;
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }

                resposta.Dados = livros;
                resposta.Mensagem = "Livros do autor encontrados com sucesso!";
                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroRespostaDto>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<LivroRespostaDto> resposta = new ResponseModel<LivroRespostaDto>();

            try
            {
                var autor = await _context.Autores
                     .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.AutorId);

                if (autor == null)
                {
                    resposta.Mensagem = "Não existe esse autor bixo!";
                    return resposta;
                }

                var livro = new LivroModel
                {
                    Titulo = livroCriacaoDto.Titulo,
                    AutorId = autor.Id
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                var livroResposta = new LivroRespostaDto
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    AutorId = autor.Id
                };

                resposta.Dados = livroResposta;
                resposta.Mensagem = "Deu tudo certo loco véio!";
                resposta.Status = true;

                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroRespostaDto>> EditarLivro(LivroEdicaoDto livroEdicaoDto, int idLivro)
        {
            ResponseModel<LivroRespostaDto> resposta = new ResponseModel<LivroRespostaDto>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Não existe esse livro, bixo!";
                    resposta.Status = false;
                    return resposta;
                }

                // Verifica se o autor informado existe
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroEdicaoDto.AutorId);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor informado não existe!";
                    resposta.Status = false;
                    return resposta;
                }

                // Atualiza os dados do livro
                livro.Titulo = livroEdicaoDto.Titulo;
                livro.AutorId = livroEdicaoDto.AutorId;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                // Monta o DTO de resposta
                var livroResposta = new LivroRespostaDto
                {
                    Id = livro.Id,
                    Titulo = livro.Titulo,
                    AutorId = autor.Id
                };

                resposta.Dados = livroResposta;
                resposta.Mensagem = "Livro atualizado com sucesso!";
                resposta.Status = true;

                return resposta;
            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<bool> ExcluirLivro(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FindAsync(idLivro);

                if (livro == null)
                    return false;

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                return true;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return false;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Lista de livros, deu boa rapaz!";
                return resposta;
            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
