using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAliasProvider<T> : IAssemblyPartAliasProvider
        where T : IAssemblyPart
    {
        void DiscoverAliases(T expression, ISqlStatementBuilder builder, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases);
    }
}
