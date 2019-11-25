using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Metodos
{
    public class MetodosBDLOCAC
    {
        Banco banco = new Banco();
        public void CadastrarLocacao(Locacao locacao)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE VEICULO SET STATUS_VEICULO='ALUGADO' WHERE IDVEICULO={0}",locacao.IdVeiculo); ;
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("INSERT INTO LOCACAO(IDVEICULO,IDFUN,CPFCLIENTE,RETIRADA,PRAZOENTREGA,VALOR,SITUACAOLOCACAO,SITUACAOPAGAMENTO)VALUES({0},{1},{2},CONVERT(DATETIME,'{3}',103),CONVERT(DATETIME,'{4}',103),{5},'EM ABERTO','EM ABERTO')", locacao.IdVeiculo, locacao.IdFuncionario, locacao.CpfCliente, locacao.Retirada, locacao.Entrega,locacao.ValorLocacao); ;
            banco.ExecutarComando(strQuery);
        }
        public List<Locacao> ListarLocacao()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM VWLOCACAO;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeLocacao(retorno);
            };
        }
        public List<Locacao> ListaDeLocacao(SqlDataReader retorno)
        {
            var locacao = new List<Locacao>();
            while (retorno.Read())
            {
                var TempLocacao = new Locacao()
                {
                    Id = int.Parse(retorno["IDLOCACAO"].ToString()),
                    IdVeiculo = int.Parse(retorno["IDVEICULO"].ToString()),
                    IdFuncionario = int.Parse(retorno["IDFUN"].ToString()),
                    CpfCliente = long.Parse(retorno["CPFCLIENTE"].ToString()),
                    NomeCliente = retorno["NOMECLIENTE"].ToString(),
                    NomeFuncionario = retorno["NOMEFUN"].ToString(),
                    ModeloVeiculo = retorno["MODELO"].ToString(),
                    CategoriaVeiculo = retorno["TIPOCATEGORIA"].ToString(),
                    MarcaVeiculo = retorno["NOMEMARCA"].ToString(),
                    PlacaVeiculo = retorno["PLACA"].ToString(),
                    SituacaoLocacao = retorno["SITUACAOLOCACAO"].ToString(),
                    SituacaoPagamento = retorno["SITUACAOPAGAMENTO"].ToString(),
                    ValorLocacao = float.Parse(retorno["VALOR"].ToString()),
                    Retirada=DateTime.Parse(retorno["RETIRADA"].ToString()),
                    Entrega=DateTime.Parse(retorno["PRAZOENTREGA"].ToString())

                };
                locacao.Add(TempLocacao);
            }
            retorno.Close();
            return locacao;
        }
        public void DevolucaoLocacao(int id,int idv)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE VEICULO SET STATUS_VEICULO='DISPONIVEL' WHERE IDVEICULO={0}",idv);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("UPDATE LOCACAO SET ");
            strQuery += string.Format("SITUACAOLOCACAO='FECHADA' " );
            strQuery += string.Format("WHERE IDLOCACAO={0}",id);
            banco.ExecutarComando(strQuery);
        }
        public void PagamentoLocacao(Locacao locacao)
        {
            var strQuery = string.Format("INSERT INTO PAGAMENTO (IDLOCACAO,TIPOPAGAMENTO) VALUES({0},UPPER('{1}'))",locacao.Id,locacao.TipoPagamento);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("UPDATE LOCACAO SET ");
            strQuery += string.Format("SITUACAOPAGAMENTO='PAGA' ");
            strQuery += string.Format("WHERE IDLOCACAO={0}", locacao.Id);
            banco.ExecutarComando(strQuery);
        }
        public Locacao ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM VWLOCACAO where IDLOCACAO={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeLocacao(retorno).FirstOrDefault();
            }
        }


    }
}
