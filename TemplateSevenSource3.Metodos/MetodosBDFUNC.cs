using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Metodos
{
    public class MetodosBDFUNC
    {
        Banco banco = new Banco();
        public Funcionario TestarUsuario(Funcionario funcionario)
        {
            var SelectLogin = string.Format("select * from VWFUNCIONARIO where LOGINFUN = '{0}' and SENHAFUN = '{1}' ", funcionario.Login, funcionario.Senha);
            SqlDataReader leitor;
           leitor = banco.ExecultarConsulta(SelectLogin);
            if (leitor.HasRows)
            {
                Funcionario func = new Funcionario();
                while (leitor.Read())
                {
                    
                    {
                        func.Login = Convert.ToString(leitor["LOGINFUN"]);
                        func.Senha = Convert.ToString(leitor["SENHAFUN"]);
                        func.NomeCargo = leitor["NOMECARGO"].ToString();
                    }

                }
                funcionario = func;
            }

            else
            {
                funcionario.Login = null;
                funcionario.Senha = null;
                funcionario.NomeCargo = null;
            }

            return funcionario;
        }
        public void CadastroFUNC(Funcionario funcionario)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO FUNCIONARIO (LOGINFUN,NOMEFUN,SENHAFUN,CPFFUN,IDCARGO) VALUES ('{0}','{1}','{2}','{3}',{4});", funcionario.Login, funcionario.Nome, funcionario.Senha, funcionario.Cpf, funcionario.IdCargo);
            banco.ExecutarComando(strQuery);

        }
        public void DeletarFUNC(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM FUNCIONARIO WHERE IDFUNCIONARIO={0}", id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarFUNC(Funcionario funcionario)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE FUNCIONARIO SET ");
            strQuery += string.Format("NOMEFUN='{0}', ",funcionario.Nome);
            strQuery += string.Format("SENHAFUN='{0}',", funcionario.Senha);
            strQuery += string.Format("CPFFUN=UPPER'{0}',", funcionario.Cpf);
            strQuery += string.Format("IDCARGO={0} ", funcionario.IdCargo);
            strQuery += string.Format("WHERE IDFUN={0}",funcionario.Id);
            banco.ExecutarComando(strQuery);
        }
        public List<Funcionario> ListarFUNC()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM VWFUNCIONARIO;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeFUNC(retorno);
            };
        }
        public List<Funcionario> ListaDeFUNC(SqlDataReader retorno)
        {
            var funcionario = new List<Funcionario>();
            while (retorno.Read())
            {
                var TempFuncionario = new Funcionario()
                {
                    Id = int.Parse(retorno["IDFUN"].ToString()),
                    Nome = retorno["NOMEFUN"].ToString(),
                    IdCargo = int.Parse(retorno["IDCARGO"].ToString()),
                    NivelCargo = int.Parse(retorno["NIVELCARGO"].ToString()),
                    NomeCargo = retorno["NOMECARGO"].ToString(),
                };
                funcionario.Add(TempFuncionario);
            }
            retorno.Close();
            return funcionario;
        }
        public Funcionario ListaId(int id)
        {
            using (banco = new Banco())
            {
                var strQuery = string.Format("SELECT * FROM VWFUNCIONARIO where IDFUNCIONARIO={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeFUNC(retorno).FirstOrDefault();
            }
        }
    }

}
