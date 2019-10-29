using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Num { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}