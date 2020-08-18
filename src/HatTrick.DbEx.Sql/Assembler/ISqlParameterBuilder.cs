using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlParameterBuilder
    {
        IList<ParameterizedFieldExpression> Parameters { get; }
        DbParameter Add<T>(T value);
        DbParameter Add(object value, Type valueType);
        ParameterizedFieldExpression Add<T>(T value, FieldExpression expression);
        ParameterizedFieldExpression AddOutput(FieldExpression field);
    }
}
