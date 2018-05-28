using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using HTL.DbEx.Utility;
using System.Configuration;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectValueMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region internals
        #endregion

        #region constructors
        public SelectValueMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity) 
             : base(connectionStringName, baseEntity, ExecutionContext.GetValue)
        {
        }

        public SelectValueMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity) 
             : base(connectionStringSettings, baseEntity, ExecutionContext.GetValue)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region execute
        public new T Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            T obj = base.GetValue<T>(sql);

            return obj;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            if (SkipValue.HasValue && LimitValue.Value > 1)
            {
                throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Limit declaration was > 1.");
            }
        }
        #endregion
    }
}
