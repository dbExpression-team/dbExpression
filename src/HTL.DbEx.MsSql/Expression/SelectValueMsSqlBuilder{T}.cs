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
    public class SelectValueSqlExpressionBuilder<T> : SelectMsSqlExpressionBuilder<T> where T : IComparable
    {
        #region constructors
        public SelectValueSqlExpressionBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public SelectValueSqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
        }
        #endregion
    }
}
