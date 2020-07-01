using LiraConnection.Enum;
using LiraConnection.Interfaces;
using LiraConnection.SQL;
using System;
using System.Data.SqlClient;

namespace LiraConnection
{
    public class Conexao : ISQLConnection
    {

        /// <summary>
        /// Conexão SQLSERVER
        /// </summary>
        /// <param name="eSQLServer">Onde Conectar</param>
        /// <returns>Conexão Aberta</returns>
        public SqlConnection SQLServer(SqlServer SQLServer, bool producao)
        {
            return new ConexaoSql(SQLServer, producao).con;
        }

        /// <summary>
        /// String de Conexão com o SQLSERVER
        /// </summary>
        /// <param name="eSQLServer">Onde Conectar</param>
        /// <returns>String de Conexão</returns>
        public string SQLServerString(SqlServer SQLServer, bool producao)
        {
            return new ConexaoSql(SQLServer, producao).ConnectionString();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
