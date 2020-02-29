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
        TTo FormatValueType<TFrom, TTo>(TFrom value)
            where TFrom : IConvertible
            where TTo : IComparable;

        SqlStatement CreateSqlStatement();

        void AppendPart(ExpressionContainer part, AssemblyContext context);

        void AppendPart<T>(T part, AssemblyContext context)
            where T : class, IAssemblyPart;

        string GenerateAlias();
        #endregion
    }
}
