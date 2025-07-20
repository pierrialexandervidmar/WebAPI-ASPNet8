using System.Text.Json.Serialization;

namespace WebApi8_Video.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public int AutorId { get; set; }

        [JsonIgnore]
        public AutorModel Autor { get; set; }
    }
}
