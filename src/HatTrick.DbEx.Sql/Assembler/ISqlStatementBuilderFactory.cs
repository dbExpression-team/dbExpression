using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilderFactory
    {
        void RegisterPartAssembler<T, U>()
            where T : class, IDbExpressionAssemblyPart
            where U : class, IDbExpressionAssemblyPartAssembler<T>, new();

        void RegisterPartAssembler<T>(IDbExpressionAssemblyPartAssembler<T> assembler)
            where T : class, IDbExpressionAssemblyPart;

        void RegisterAssembler<T>(ExecutionContext executionContext)
            where T : class, ISqlStatementAssembler, new();

        void RegisterAssembler<T>(ExecutionContext executionContext, T assembler)
            where T : class, ISqlStatementAssembler;

        void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new();

        void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter;

        ISqlStatementBuilder CreateSqlStatementBuilder(ExpressionSet expression, ISqlParameterBuilder parameterBuilder);
    }
}
