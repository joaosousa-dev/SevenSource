using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TemplateSevenSource3Dominio
{
    public class Cliente
    {
        
        [RegularExpression(@"[a-z A-Z]{3,50}", ErrorMessage = "Apenas letras, mínimo 3 caracteres")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Email")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um Email válido")]
        public string Email { get; set; }
        [DisplayName("CNH")]
        public string Cnh { get; set; }
        [DisplayName("CPF")]
        public long Cpf { get; set; }
        [DisplayName("Telefone Móvel")]
        public string TelMovel { get; set; }
        [DisplayName("Telefone Fixo")]
        public string TelFixo { get; set; }
        [DisplayName("Rua")]
        public string Rua { get; set; }
        [DisplayName("Número")]
        public string Numero { get; set; }
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        [DisplayName("Cep")]
        public string Cep { get; set; }
        public int idend { get; set; }
        // https://igorescobar.github.io/jQuery-Mask-Plugin/docs.html
    }
}