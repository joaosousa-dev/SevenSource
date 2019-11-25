using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateSevenSource3Dominio
{
    public class Locacao
    {
        public int Id { get; set; }
        public int IdVeiculo { get; set; }
        [DisplayName("Modelo")]
        public string ModeloVeiculo { get; set; }
        [DisplayName("Marca")]
        public string MarcaVeiculo { get; set; }
        [DisplayName("Categoria")]
        public string CategoriaVeiculo { get; set; }
        [DisplayName("Foto")]
        public string fotoVeiculo { get; set; }
        [DisplayName("Valor/dia")]
        public string Valor_p_diaCategoria { get; set; }
        [DisplayName("CPF Cliente")]
        public long CpfCliente { get; set; }
        [DisplayName("Cliente")]
        public string NomeCliente { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("Funcionário")]
        public string NomeFuncionario { get; set; }
        [DataType(DataType.Date)]
        public DateTime Retirada { get; set; }
        [DataType(DataType.Date)]

        public DateTime Entrega { get; set; }
        [DisplayName("Qtd dias")]
        public int TotalDias { get; set; }
        [DisplayName("Valor Total")]

        public float ValorLocacao { get; set; }
        [DisplayName("ID Pagamento")]
        public int IdPagamento { get; set; }
        [DisplayName("Situação")]
        public string SituacaoLocacao { get; set; }
        [DisplayName("Placa")]
        public string PlacaVeiculo { get; set; }
        [DisplayName("Tipo de pagamento")]

        public string TipoPagamento { get; set; }
        [DisplayName("Pgt")]
        public string SituacaoPagamento { get; set; }

    }
}