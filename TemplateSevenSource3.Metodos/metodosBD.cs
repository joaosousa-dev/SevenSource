﻿using MySql.Data.MySqlClient;
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
            strQuery += string.Format("INSERT INTO CLIENTE (NOMECLIENTE,EMAILCLIENTE,SENHACLIENTE,CNHCLIENTE,CPFCLIENTE) VALUES ('{0}','{1}','{2}',{3},{4});", cliente.Nome, cliente.Email, cliente.Senha, cliente.Cnh, cliente.Cpf);
            banco.ExecutarComando(strQuery);
        }
        public void DeletarCLI(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM CLIENTE WHERE IDCLIENTE={0}", cliente.Id);
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarCLI(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE CLIENTE SET ");
            strQuery += string.Format("IDCLIENTE={0}", cliente.Id);
            strQuery += string.Format("NOMECLIENTE='{0}'", cliente.Nome);
            strQuery += string.Format("EMAILCLIENTE='{0}'", cliente.Email);
            strQuery += string.Format("SENHACLIENTE='{0}'", cliente.Senha);
            strQuery += string.Format("CPFCLIENTE='{0}'", cliente.Cpf);
            strQuery += string.Format("CNHCLIENTE='{0}'", cliente.Cnh);
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
                    Id = int.Parse(retorno["IDCLIENTE"].ToString()),
                    Nome = retorno["NOMECLIENTE"].ToString(),
                    Email = retorno["EMAILCLIENTE"].ToString(),
                    Senha = retorno["SENHACLIENTE"].ToString(),
                    Cnh = int.Parse(retorno["CNHCLIENTE"].ToString()),
                    Cpf = int.Parse(retorno["CPFCLIENTE"].ToString())
                };
                cliente.Add(TempCliente);
            }
            retorno.Close();
            return cliente;
        }
    }
}