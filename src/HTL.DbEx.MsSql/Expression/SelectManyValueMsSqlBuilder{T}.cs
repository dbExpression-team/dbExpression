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
    public class SelectManyValueMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectManyValueMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.GetValueList)
        {
        }

        public SelectManyValueMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.GetValueList)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region execute
        public new IList<T> Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            IList<T> lst = base.GetValueList<T>(sql);

            return lst;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            if (SkipValue.HasValue && LimitValue.Value > 1)
            {
                throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Take declaration was > 1.");
            }
            if (Expression.Select != null)
            {
                throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValue' execution context failed.  'GetValue' returns a single value that represents the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
            }
        }
        #endregion
    }
}
