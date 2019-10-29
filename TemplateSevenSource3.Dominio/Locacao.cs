using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Locacao
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime Retirada { get; set; }
        public DateTime Entrega { get; set; }
    }
}