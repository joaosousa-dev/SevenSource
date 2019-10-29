using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Devolucao
    {
        public int Id { get; set; }
        public DateTime Data {get; set; }
        public int IdLocacao { get; set; }
    }
}