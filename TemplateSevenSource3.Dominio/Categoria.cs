using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSevenSource3.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        [DisplayName("Valor")]
        public float Valor_p_dia { get; set; }
    }
}
