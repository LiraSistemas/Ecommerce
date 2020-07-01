using LiraConnection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraConnection.Enum
{
    public enum SqlServer
    {
        [ConnectionStringAttribute(
        producao: "Data Source = LocalHost;Initial Catalog = LiraEcommerce;User ID = sa;Password = 1q2w!Q@W; Connection Lifetime=30",
        homologacao: "Data Source = LocalHost;Initial Catalog = LiraEcommerce;User ID = sa;Password = 1q2w!Q@W; Connection Lifetime=30"
        )]
        Ecommerce,
    }
}
