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
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public int IdMarca { get; set; }
        public string Status { get; set; }
        public int IdManutencao { get; set; }
        public string fotopath { get; set; }
                
        
    }
}