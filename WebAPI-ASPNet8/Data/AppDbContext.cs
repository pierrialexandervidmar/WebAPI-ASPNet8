using Microsoft.EntityFrameworkCore;
using WebAPI_ASPNet8.Models;

namespace WebAPI_ASPNet8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {   
        }

        public DbSet<AutorModel> Autores {  get; set; }
        public DbSet<LivroModel> Livros { get; set; }


    }
}
