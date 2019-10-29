using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public ushort Cpf { get; set; }
        public ushort Cnh { get; set; }
        public int IdTelefone { get; set; }
        public int IdEndereco { get; set; }
    }
}