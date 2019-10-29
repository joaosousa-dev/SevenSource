using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Telefone
    {
        public int Id { get; set; }
        public int TelMovel { get; set; }
        public int TelFixo { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}