using LiraConnection.Enum;
using LiraConnection.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraConnection.SQL
{    

    internal class ConexaoSql
    {
        internal readonly SqlConnection con;
        private SqlServer _SqlServer;
        bool _producao;
        public ConexaoSql(SqlServer SQLServer, bool producao)
        {
            try
            {
                _SqlServer = SQLServer;
                _producao = producao;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Failed to establish a connection") >= 0)
                {
                    throw new Exception("NÃO FOI POSSÍVEL CONECTAR AO BANCO DE DADOS. SERVIDOR PODE ESTAR EM MANUTENÇÃO OU SEU COMPUTADOR PODE ESTAR SEM REDE OU INTERNET, TENTE NOVAMENTE MAIS TARDE.\n" + ex.Message);
                }
                else
                {
                    throw new Exception("NÃO FOI POSSÍVEL CONECTAR AO BANCO DE DADOS. TENTE NOVAMENTE. " + ex.Message);
                }
            }
        }

        public string ConnectionString()
        {
            string sc = _producao ? Entidades.ConnectionString.RetornaAtributos(_SqlServer).Producao : Entidades.ConnectionString.RetornaAtributos(_SqlServer).Homologacao;
            return sc + $"; Application Name={Process.GetCurrentProcess().ProcessName}";
        }

        public SqlConnection SqlConnection()
        {
            string stringConnetion = ConnectionString();
            var conn = new SqlConnection(stringConnetion);
            conn.Open();
            return conn;
        }
        public void Dispose()
        {
            con.Close();
            GC.SuppressFinalize(this);
        }

    }
}
