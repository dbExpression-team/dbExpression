using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilder
    {
        IList<ParameterizedExpression> Parameters { get; }
        DbParameter Add<T>(T value);
        DbParameter Add(object value, Type valueType);
        ParameterizedExpression Add<T>(T value, ISqlFieldMetadata meta);
    }
}
