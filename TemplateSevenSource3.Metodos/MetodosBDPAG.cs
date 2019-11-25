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
    public class MetodosBDPAG
    {
        Banco banco = new Banco();
        public Pagamento ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM LOCACAO where IDLOCACAO={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaPagamento(retorno).FirstOrDefault();
            }
        }
        public List<Pagamento> ListaPagamento(SqlDataReader retorno)
        {
            var pagamento = new List<Pagamento>();
            while (retorno.Read())
            {
                var Temppag = new Pagamento()
                {
                    Id = int.Parse(retorno["IDPAGAMENTO"].ToString()),
                    TipoPagamento = retorno["TIPOPAGAMENTO"].ToString()
                };
                pagamento.Add(Temppag);
            }
            retorno.Close();
            return pagamento;
        }

    }
}
