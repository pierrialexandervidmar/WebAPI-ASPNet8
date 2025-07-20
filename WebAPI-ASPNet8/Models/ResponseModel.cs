using WebAPI_ASPNet8.Migrations;

namespace WebAPI_ASPNet8.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status {  get; set; }
    }
}
