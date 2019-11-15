using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3Metodos
{
    public class metodosBD
    {
        //private Banco banco;
        Banco banco = new Banco();
        public void CadastroCLI(Cliente cliente)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO ENDERECO(RUA, NUMERO, CIDADE, BAIRRO, ESTADO, CEP) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", cliente.Rua, cliente.Numero, cliente.Cidade, cliente.Bairro, cliente.Estado, cliente.Cep);
            banco.ExecutarComando(strQuery);
            cliente.idend = banco.RetornaIdEnd(cliente);
            strQuery += string.Format("INSERT INTO CLIENTE (NOMECLIENTE,EMAILCLIENTE,CNHCLIENTE,CPFCLIENTE,IDENDERECO) VALUES ('{0}','{1}','{2}','{3}',{4});", cliente.Nome, cliente.Email, cliente.Cnh, cliente.Cpf, cliente.idend);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("INSERT INTO TELEFONE (TELFIXO,TELMOVEL,CPFCLIENTE)VALUES('{0}','{1}',{2});", cliente.TelFixo, cliente.TelMovel, cliente.Cpf);
            banco.ExecutarComando(strQuery);

        }
        public void DeletarCLI(long cpf)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM TELEFONE WHERE CPFCLIENTE={0}", cpf);
            banco.ExecutarComando(strQuery);
            strQuery += string.Format("DELETE FROM CLIENTE WHERE CPFCLIENTE={0}", cpf);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarCLI(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE CLIENTE SET ");
            strQuery += string.Format("NOMECLIENTE='{0}',", cliente.Nome);
            strQuery += string.Format("EMAILCLIENTE='{0}',", cliente.Email);
            //strQuery += string.Format("CPFCLIENTE='{0}',", cliente.Cpf);
            strQuery += string.Format("CNHCLIENTE='{0}'", cliente.Cnh);
            strQuery += string.Format("WHERE CPFCLIENTE={0}", cliente.Cpf);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("UPDATE TELEFONE SET ");
            strQuery += string.Format("TELMOVEL='{0}',", cliente.TelMovel);
            strQuery += string.Format("TELFIXO='{0}' ", cliente.TelFixo);
            strQuery += string.Format("WHERE CPFCLIENTE={0}", cliente.Cpf);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("UPDATE ENDERECO SET ");
            strQuery += string.Format("RUA = '{0}',", cliente.Rua);
            strQuery += string.Format("NUMERO = '{0}',", cliente.Numero);
            strQuery += string.Format("BAIRRO = '{0}',", cliente.Bairro);
            strQuery += string.Format("CIDADE = '{0}',", cliente.Cidade);
            strQuery += string.Format("ESTADO = '{0}',", cliente.Estado);
            strQuery += string.Format("CEP = '{0}' ", cliente.Cep);
            strQuery += string.Format("WHERE IDENDERECO={0}", cliente.idend);
            banco.ExecutarComando(strQuery);
        }
        public List<Cliente> ListarCLI()
        {
            using (banco = new Banco())
            {
                //var strQuery = "SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE;";
                var strQuery = "SELECT * FROM VWCLIENTE;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCLI(retorno);
            };
        }
        public List<Cliente> ListaDeCLI(SqlDataReader retorno)
        {
            var cliente = new List<Cliente>();
            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {

                    Nome = retorno["NOMECLIENTE"].ToString(),
                    Email = retorno["EMAILCLIENTE"].ToString(),
                    Cnh = retorno["CNHCLIENTE"].ToString(),
                    Cpf = long.Parse(retorno["CPFCLIENTE"].ToString()),
                    TelMovel = retorno["TELMOVEL"].ToString(),
                    TelFixo = retorno["TELFIXO"].ToString(),
                    Rua = retorno["RUA"].ToString(),
                    Numero = retorno["NUMERO"].ToString(),
                    Bairro = retorno["BAIRRO"].ToString(),
                    Cidade = retorno["CIDADE"].ToString(),
                    Estado = retorno["ESTADO"].ToString(),
                    Cep = retorno["CEP"].ToString()
                };
                cliente.Add(TempCliente);
            }
            retorno.Close();
            return cliente;
        }

        public Cliente ListaId(long cpf)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM VWCLIENTE where CPFCLIENTE={0}", cpf);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCLI(retorno).FirstOrDefault();
            }
        }
        public void Salvar(Cliente cliente)
        {
            if (cliente.Cpf > 0)
                AtualizarCLI(cliente);
            else
                CadastroCLI(cliente);
        }
    }
}
