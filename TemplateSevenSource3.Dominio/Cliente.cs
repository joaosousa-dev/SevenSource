using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TemplateSevenSource3Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        [RegularExpression(@"[a-zA-Z]{1,50}", ErrorMessage = "Apenas letras, mínimo 3 caracteres")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [DisplayName("Email")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um Email válido")]
        public string Email { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }
        [DisplayName("Repetir senha")]
        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais")]
        public string ConfirmarSenha { get; set; }
        [DisplayName("CNH")]
        public int Cnh { get; set; }
        [DisplayName("CPF")]
        public int Cpf { get; set; }

    }
}