using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Modelo
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string Nome { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
    }
}