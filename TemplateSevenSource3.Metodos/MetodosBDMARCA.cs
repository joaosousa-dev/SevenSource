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
    public class MetodosBDMARCA
    {
        Banco banco = new Banco();
        public void CadastrarMarca(Marca marca)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO MARCA(NOMEMARCA)VALUES(UPPER('{0}'))",marca.Nome);
            banco.ExecutarComando(strQuery);
        }
        public void DeletarMarca(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM MARCA WHERE IDMARCA={0}",id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarMarca(Marca marca)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE MARCA SET ");
            strQuery += string.Format("NOMEMARCA=UPPER('{0}') ", marca.Nome);
            strQuery += string.Format("WHERE IDMARCA={0}", marca.Id);
            banco.ExecutarComando(strQuery);
        }
        public List<Marca> ListarMarca()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM MARCA;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeMarca(retorno);
            };
        }
        public List<Marca> ListaDeMarca(SqlDataReader retorno)
        {
            var marca = new List<Marca>();
            while (retorno.Read())
            {
                var TempMarca = new Marca()
                {
                    Id = int.Parse(retorno["IDMARCA"].ToString()),
                    Nome = retorno["NOMEMARCA"].ToString()
                };
                marca.Add(TempMarca);
            }
            retorno.Close();
            return marca;
        }
        public Marca ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM MARCA where IDMARCA={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeMarca(retorno).FirstOrDefault();
            }
        }
    }
}
