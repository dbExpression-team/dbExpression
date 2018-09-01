using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Expression;
using System;

namespace HTL.DbEx.Sql.Assembler
{
    public interface ISqlStatementAssemblerFactory
    {
        void RegisterPartAssembler<T, U>()
            where T : class, ISqlAssemblyPart
            where U : class, ISqlPartAssembler<T>, new();

        void RegisterPartAssembler<T>(ISqlPartAssembler<T> assembler)
            where T : class, ISqlAssemblyPart;

        void RegisterAssembler<T>(ExecutionContext executionContext)
            where T : class, ISqlStatementAssembler, new();

        void RegisterAssembler<T>(ExecutionContext executionContext, T assembler)
            where T : class, ISqlStatementAssembler;

        void RegisterValueFormatter<T, U>()
           where T : IComparable
           where U : class, IValueTypeFormatter<T>, new();

        void RegisterValueFormatter<T>(IValueTypeFormatter<T> valueFormatter)
            where T : IComparable, IValueTypeFormatter;

        ISqlStatementAssembler CreateSqlStatementBuilder(DBExpressionSet expression, ISqlParameterBuilder parameterBuilder);
    }
}
