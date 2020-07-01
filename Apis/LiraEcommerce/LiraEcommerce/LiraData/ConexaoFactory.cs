using LiraConnection;
using LiraConnection.Interfaces;

namespace LiraData
{
    public  sealed class ConexaoFactory
    {
        public static ISQLConnection GetConexao()
        {
            return new Conexao();
        }
    }
}
