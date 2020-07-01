using LiraConnection.Attributes;
using LiraConnection.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraConnection.Entidades
{
    public class ConnectionString
    {
        public string Producao;
        public string Homologacao;

        public ConnectionString(string producao, string homologacao)
        {
            Producao = producao;
            Homologacao = homologacao;
        }


        public static ConnectionString RetornaAtributos(SqlServer pServico)
        {
            Type t = typeof(SqlServer);
            var memInfo = t.GetMember(pServico.ToString());
            var Attributes = memInfo[0].GetCustomAttributes(typeof(ConnectionStringAttribute), false);
            var description = ((ConnectionStringAttribute)Attributes[0])._stringConnection;

            return description;
        }
    }
}
