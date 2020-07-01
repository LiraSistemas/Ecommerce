using LiraConnection.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraConnection.Attributes
{    
    public class ConnectionStringAttribute : Attribute
    {
        public ConnectionString _stringConnection;
        public ConnectionStringAttribute(string producao, string homologacao)
        {
            _stringConnection = new ConnectionString(producao, homologacao);
        }
    }
}
