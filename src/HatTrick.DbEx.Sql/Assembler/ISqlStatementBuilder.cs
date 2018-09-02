using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilder
    {
        ISqlParameterBuilder Parameters { get; }

        string FormatValueType((Type, object) value);

        string FormatValueType<T>(object value)
            where T : IComparable;

        SqlStatement CreateSqlStatement();

        string AssemblePart((Type, object) part);
        string AssemblePart((Type, object) part, AssemblerOverrides overrides);

        string AssemblePart<T>(object part)
            where T : IDbExpressionAssemblyPart;
        string AssemblePart<T>(object part, AssemblerOverrides overrides)
            where T : IDbExpressionAssemblyPart;
    }
}
