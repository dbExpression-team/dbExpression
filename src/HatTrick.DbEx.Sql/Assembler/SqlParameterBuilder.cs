using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlParameterBuilder : ISqlParameterBuilder
    {
        public IList<ParameterizedFieldExpression> Parameters { get; set; } = new List<ParameterizedFieldExpression>();

        protected SqlParameterBuilder()
        {
        }

        #region abstract methods
        public abstract DbParameter Add<T>(T value);
        public abstract ParameterizedFieldExpression Add<T>(T value, FieldExpression expression);
        public abstract DbParameter Add(object value, Type valueType);
        public abstract ParameterizedFieldExpression AddOutput(FieldExpression expression);
        #endregion
    }
}
