using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3AcessoDados;

namespace TemplateSevenSource3.Metodos
{
    public class MetodosBDMANUT
    {
        Banco banco = new Banco();

        public void CadastrarManutencao(Manutencao manutencao)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO MANUTENCAO(DSMANUTENCAO)VALUES(UPPER('{0}'))", manutencao.Descricao);
            banco.ExecutarComando(strQuery);
        }
        public void DeletarManutencao(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM MANUTENCAO WHERE IDMANUTENCAO={0}", id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarManutencao(Manutencao manutencao)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE MANUTENCAO SET ");
            strQuery += string.Format("DSMANUTENCAO=UPPER('{0}') ", manutencao.Descricao);
            strQuery += string.Format("WHERE IDMANUTENCAO={0}", manutencao.Id);
            banco.ExecutarComando(strQuery);
        }
        public List<Manutencao> ListarManutencao()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM MANUTENCAO;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeManutencao(retorno);
            };
        }
        public List<Manutencao> ListaDeManutencao(SqlDataReader retorno)
        {
            var manutencao = new List<Manutencao>();
            while (retorno.Read())
            {
                var TempManutencao = new Manutencao()
                {
                    Id = int.Parse(retorno["IDMANUTENCAO"].ToString()),
                    Descricao = retorno["DSMANUTENCAO"].ToString()
                };
                manutencao.Add(TempManutencao);
            }
            retorno.Close();
            return manutencao;
        }
        public Manutencao ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM MANUTENCAO where IDMANUTENCAO={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeManutencao(retorno).FirstOrDefault();
            }
        }
    }
}
