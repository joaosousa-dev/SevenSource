using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Veiculo
    {
        public int Id { get; set; }
        [DisplayName("ID Categoria")]
        public int IdCategoria { get; set; }
        [DisplayName("Categoria")]
        public string TipoCategoria { get; set; }
        public string Placa { get; set; }
        [DisplayName("Câmbio")]
        public char Cambio { get; set; }    
        public int Ano { get; set; }
        public string Modelo { get; set; }
        [DisplayName("ID Marca")]
        public int IdMarca { get; set; }
        [DisplayName("Marca")]
        public string NomeMarca { get; set; }
        public string Status { get; set; }
        public int IdManutencao { get; set; }
        [DisplayName("Descrição da manutenção")]
        public string DsManutencao { get; set; }
        public string fotopath { get; set; }
                
        
    }
}