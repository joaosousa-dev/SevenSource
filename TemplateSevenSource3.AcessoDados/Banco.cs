using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace TemplateSevenSource3AcessoDados
{
    public class Banco : IDisposable
    {
        private SqlConnection conexao;

        public Banco()
        {
<<<<<<< HEAD
            conexao = new SqlConnection(@"Data Source=SOUSA-PC;Initial Catalog=LOCADORASEVENCAR;User ID=sa;Password=joaovictor");
=======
            conexao = new SqlConnection(@"Data Source=DESKTOP-F6BBN38;Initial Catalog=LOCADORASEVENCAR;User ID=sa;Password=1234567");
>>>>>>> 3fc4b22f315ea1ec72420bba1e0f20ea100190a4
            conexao.Open();
        }
        public void ExecutarComando(string strQuery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strQuery,conexao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public SqlDataReader ExecultarConsulta(string strQuery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strQuery,conexao);
                return cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        public void Dispose()
        {
            if(conexao.State==ConnectionState.Open)
            conexao.Close();
        }
    }
}
