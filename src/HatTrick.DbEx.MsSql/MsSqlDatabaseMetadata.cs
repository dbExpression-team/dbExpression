using HatTrick.DbEx.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlDatabaseMetadata : SqlDatabaseMetadata
    {
        public MsSqlDatabaseMetadata(string name, string connectionName) : base(name, connectionName)
        { }
    }
}
