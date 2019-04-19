using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssemblerFactory
    {
        void RegisterPartAssembler<T, U>()
            where T : class, IAssemblyPart
            where U : class, IAssemblyPartAppender<T>, new();

        void RegisterPartAssembler<T>(IAssemblyPartAppender<T> assembler)
            where T : class, IAssemblyPart;

        void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType)
            where T : class, ISqlStatementAssembler, new();

        void RegisterAssembler<T>(SqlStatementExecutionType statementExecutionType, T assembler)
            where T : class, ISqlStatementAssembler;

        void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new();

        void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter;

        ISqlStatementAssembler CreateSqlStatementBuilder(ExpressionSet expression, ISqlParameterBuilder parameterBuilder);
    }
}
