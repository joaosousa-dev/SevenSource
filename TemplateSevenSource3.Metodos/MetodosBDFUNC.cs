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
            var SelectLogin = string.Format("select * from FUNCIONARIO where LOGINFUN = '{0}' and SENHAFUN = '{1}'", funcionario.Login, funcionario.Senha);
            SqlDataReader leitor;
           leitor = banco.ExecultarConsulta(SelectLogin);
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Funcionario func = new Funcionario();
                    {
                        func.Login = Convert.ToString(leitor["LOGINFUN"]);
                        func.Senha = Convert.ToString(leitor["SENHAFUN"]);
                    }
                }
            }

            else
            {
                funcionario.Login = null;
                funcionario.Senha = null;
            }

            return funcionario;
        }
    }
}
