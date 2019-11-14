using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3AcessoDados
{
    public class Banco : IDisposable
    {
        private SqlConnection conexao;

        public Banco()
        {
            conexao = new SqlConnection(@"Data Source=LAB2PC007;Initial Catalog=LOCADORASEVENCAR;User ID=sa;Password=1234567");
            conexao.Open();
        }
        public void ExecutarComando(string strQuery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(strQuery, conexao);
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
                SqlCommand cmd = new SqlCommand(strQuery, conexao);
                return cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public int RetornaIdEnd(Cliente cliente)
        {
            int id = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string str = string.Format("Select IDENDERECO from ENDERECO where RUA='{0}' and NUMERO='{1}' and BAIRRO='{2}' and ESTADO='{3}' and CIDADE='{4}'and CEP='{5}';", cliente.Rua, cliente.Numero, cliente.Bairro, cliente.Estado, cliente.Cidade, cliente.Cep);
            da = new SqlDataAdapter(str, conexao);
            da.Fill(dt);
            id = (int)dt.Rows[0]["IDENDERECO"];
            return id;
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}
