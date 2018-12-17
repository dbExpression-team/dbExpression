using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlParameterBuilder : ISqlParameterBuilder
    {
        public IList<DbParameter> Parameters { get; set; }

        protected SqlParameterBuilder(IList<DbParameter> parameters)
        {
            Parameters = parameters;
        }

        protected virtual void AddParameter(DbParameter parameter)
        {
            Parameters.Add(parameter);
        }

        #region abstract methods
        public abstract DbParameter Add<T>(object value)
            where T : IComparable;
        public abstract DbParameter Add(object value, FieldExpressionMetadata metadata);
        public abstract DbParameter Add(object value, Type valueType);
        #endregion
    }
}
