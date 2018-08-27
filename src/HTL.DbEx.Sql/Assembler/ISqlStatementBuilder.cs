using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilder
    {
        ISqlParameterBuilder Parameters { get; }

        string FormatValueType((Type, object) value);

        string FormatValueType<T>(object value)
            where T : IComparable;

        (string,IList<DbParameter>) CreateSqlStatement();

        string AssemblePart((Type, object) part);
        string AssemblePart((Type, object) part, AssemblerOverrides overrides);

        string AssemblePart<T>(object part)
            where T : ISqlAssemblyPart;
        string AssemblePart<T>(object part, AssemblerOverrides overrides)
            where T : ISqlAssemblyPart;
    }
}
