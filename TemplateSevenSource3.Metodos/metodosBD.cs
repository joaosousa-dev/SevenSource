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
            
            strQuery += string.Format("INSERT INTO CLIENTE (NOMECLIENTE,EMAILCLIENTE,CNHCLIENTE,CPFCLIENTE) VALUES ('{0}','{1}','{2}','{3}');", cliente.Nome, cliente.Email, cliente.Cnh, cliente.Cpf);
            banco.ExecutarComando(strQuery);
            strQuery = string.Format("INSERT INTO TELEFONE (TELFIXO,TELMOVEL,CPFCLIENTE)VALUES('{0}','{1}',{2});", cliente.TelFixo, cliente.TelMovel,cliente.Cpf);
            banco.ExecutarComando(strQuery);
            
        }
        public void DeletarCLI(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM CLIENTE WHERE CPFCLIENTE={0}", cliente.Cpf);
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
        }
        public List<Cliente> ListarCLI()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM CLIENTE;";
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
                    Cpf = long.Parse(retorno["CPFCLIENTE"].ToString())
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
                var strQuery = string.Format("SELECT * FROM CLIENTE WHERE CPFCLIENTE = {0};", cpf);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCLI(retorno).FirstOrDefault();
            }
        }
        public void Salvar(Cliente cliente)
        {
            if (cliente.Cpf> 0)
            {
                AtualizarCLI(cliente);
            }
            else
            {
                CadastroCLI(cliente);
            }
        }
    }
}
