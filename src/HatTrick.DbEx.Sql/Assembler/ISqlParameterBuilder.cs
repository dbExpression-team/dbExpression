using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilder
    {
        IList<ParameterizedExpression> Parameters { get; }
        DbParameter Add<T>(T value, AssemblyContext context);
        DbParameter Add(object value, Type valueType, AssemblyContext context);
        ParameterizedExpression Add<T>(T value, AssemblyContext context, ISqlFieldMetadata meta);
    }
}
