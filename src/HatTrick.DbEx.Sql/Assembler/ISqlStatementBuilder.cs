using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilder
    {
        #region interface
        ISqlParameterBuilder Parameters { get; }
        IAppender Appender { get; }
        #endregion

        #region methods
        string FormatValueType((Type, object) value);

        string FormatValueType<T>(object value)
            where T : IComparable;

        SqlStatement CreateSqlStatement();

        void AppendPart((Type, object) part, AssemblerContext context);

        void AppendPart<T>(object part, AssemblerContext context)
            where T : IAssemblyPart;

        void DiscoverAliases<T>(T expression, int currentLevel, DbExpressionAssemblerConfiguration config, IDictionary<int, AliasDiscovery> discoveredAliases)
            where T : IAssemblyPart;

        string GenerateAlias();
        #endregion
    }
}
