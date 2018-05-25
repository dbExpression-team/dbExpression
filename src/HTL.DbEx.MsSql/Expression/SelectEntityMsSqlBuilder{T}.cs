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
    public class SelectEntitySqlExpressionBuilder<T> : SelectMsSqlExpressionBuilder<T> where T : class, new()
    {
        #region constructors
        public SelectEntitySqlExpressionBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public SelectEntitySqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
        }
        #endregion
    }
}
