using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
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
        public virtual DbParameter Add(object value) => Add(value, value.GetType(), null);
        public virtual DbParameter Add(object value, Type valueType) => Add(value, valueType, null);
        public abstract DbParameter Add(object value, Type valueType, int? size);
        #endregion
    }
}
