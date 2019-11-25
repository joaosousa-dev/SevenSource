using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSevenSource3.Dominio
{
    public class Pagamento
    {
        public int Id { get; set; }
        [DisplayName("Tipo")]
        public string TipoPagamento { get; set; }
        public int IdLocacao { get; set; }

    }
}
