using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlParameterBuilder : ISqlParameterBuilder
    {
        public IList<ParameterizedFieldExpression> Parameters { get; set; } = new List<ParameterizedFieldExpression>();

        #region abstract methods
        public abstract DbParameter Add<T>(T value);
        public abstract ParameterizedFieldExpression Add<T>(T value, FieldExpression expression, ISqlFieldMetadata meta);
        public abstract DbParameter Add(object value, Type valueType);
        public abstract ParameterizedFieldExpression AddOutput(FieldExpression expression, ISqlFieldMetadata meta);
        #endregion
    }
}
