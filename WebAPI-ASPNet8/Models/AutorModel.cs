using System.Text.Json.Serialization;

namespace WebAPI_ASPNet8.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; }
    }
}
