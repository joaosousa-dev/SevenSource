using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public char Cambio { get; set; }    
        public int IdModelo { get; set; }
        public int IdMarca { get; set; }
        public int IdManutencao { get; set; }
    }
}