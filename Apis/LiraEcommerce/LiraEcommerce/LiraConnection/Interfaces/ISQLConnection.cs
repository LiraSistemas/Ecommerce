using LiraConnection.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiraConnection.Interfaces
{
    public interface ISQLConnection :IDisposable
    {
        SqlConnection SQLServer(SqlServer SQLServer, bool producao);
        string SQLServerString(SqlServer SQLServer, bool producao);
    }
}
