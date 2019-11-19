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
    public class MetodosBDVEICULO
    {
        Banco banco = new Banco();
        public void CadastroVeiculo(Veiculo veiculo)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO VEICULO(MODELO,ANO,PLACA,CAMBIO,STATUS_VEICULO,IDCATEGORIA,IDMARCA,IDMANUTENCAO) VALUES(UPPER('{0}'),'{1}', UPPER('{2}'), UPPER('{3}'), UPPER('{4}'), {5},{6},{7})",veiculo.Modelo,veiculo.Ano,veiculo.Placa,veiculo.Cambio,veiculo.Status,veiculo.IdCategoria,veiculo.IdMarca,veiculo.IdManutencao);
            banco.ExecutarComando(strQuery);

        }
        public void DeletarVeiculo(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM VEICULO WHERE IDVEICULO={0}", id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarVeiculo(Veiculo veiculo)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE VEICULO SET ");
            strQuery += string.Format("MODELO=UPPER('{0}'), ", veiculo.Modelo);
            strQuery += string.Format("ANO={0},", veiculo.Ano);
            strQuery += string.Format("PLACA=UPPER('{0}'),", veiculo.Placa);
            strQuery += string.Format("CAMBIO=UPPER('{0}'),", veiculo.Cambio);
            strQuery += string.Format("STATUS_VEICULO=UPPER('{0}'),", veiculo.Status);
            strQuery += string.Format("IDCATEGORIA={0},", veiculo.IdCategoria);
            strQuery += string.Format("IDMARCA={0} ", veiculo.IdMarca);
            strQuery += string.Format("WHERE IDVEICULO={0}", veiculo.Id);
            banco.ExecutarComando(strQuery);
        }
        public List<Veiculo> ListarVeiculo()
        {
            using (banco = new Banco())
            {
                var strQuery = "SELECT * FROM VWVEICULO;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeVeiculo(retorno);
            };
        }
        public List<Veiculo> ListaDeVeiculo(SqlDataReader retorno)
        {
            var veiculo = new List<Veiculo>();
            while (retorno.Read())
            {
                var TempVeiculo = new Veiculo()
                {
                    Id = int.Parse(retorno["IDVEICULO"].ToString()),
                    Modelo = retorno["MODELO"].ToString(),
                    Ano = int.Parse(retorno["ANO"].ToString()),
                    Placa = retorno["PLACA"].ToString(),
                    Cambio = char.Parse(retorno["CAMBIO"].ToString()),
                    Status = retorno["STATUS_VEICULO"].ToString(),
                    TipoCategoria = retorno["TIPOCATEGORIA"].ToString(),
                    NomeMarca = retorno["NOMEMARCA"].ToString(),
                    DsManutencao = retorno["DSMANUTENCAO"].ToString(),
                    IdCategoria = int.Parse(retorno["IDCATEGORIA"].ToString()),
                    IdMarca = int.Parse(retorno["IDMARCA"].ToString()),
                    IdManutencao = int.Parse(retorno["IDMANUTENCAO"].ToString())
                };
                veiculo.Add(TempVeiculo);
            }
            retorno.Close();
            return veiculo;
        }
        public Veiculo ListaId(int id)
        {
            using (banco = new Banco())
            {
                // var strQuery = string.Format("SELECT * FROM TELEFONE as T INNER JOIN CLIENTE as C on T.CPFCLIENTE = C.CPFCLIENTE where T.CPFCLIENTE={0}", cpf);
                var strQuery = string.Format("SELECT * FROM VWVEICULO where IDVEICULO={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeVeiculo(retorno).FirstOrDefault();
            }
        }
    }
}
