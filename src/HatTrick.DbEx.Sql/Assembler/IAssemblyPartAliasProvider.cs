using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAliasProvider
    {
        void DiscoverAliases(object expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, EntityAliasDiscovery> discoveredAliases);
    }
}
