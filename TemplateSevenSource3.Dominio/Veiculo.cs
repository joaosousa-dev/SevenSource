using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Placa { get; set; }
        public char Cambio { get; set; }    
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string IdMarca { get; set; }
        public string Status { get; set; }
        public string fotopath { get; set; }
        [DataType(DataType.MultilineText)]
        public string DescricaoCategoria { get; set; }
        public string TipoCategoria { get; set; }
        public double Valor_p_diaCategoria { get; set; }
        public string IdManutencao { get; set; }
        public string DescManutencao { get; set; }
    }
}