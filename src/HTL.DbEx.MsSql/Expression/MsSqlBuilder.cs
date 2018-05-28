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
    public abstract class MsSqlBuilder<T> : SqlExpressionBuilder
    {
        #region constructors
        public MsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity, ExecutionContext context) : base(connectionStringName, baseEntity, context)
        {
        }

        public MsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, ExecutionContext context) : base(connectionStringSettings, baseEntity, context)
        {
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region get sql connection
        protected override SqlConnection GetSqlConnection()
        {
            return new MsSqlConnection(base.ConnectionStringSettings);
        }
        #endregion

        #region sql assembly methods
        //protected override string AssembleSql()
        //{
        //    string sql = null;
        //switch (base.CommandExecutionContext.Value)
        //{
        //    case ExecutionContext.Get:
        //    case ExecutionContext.GetDynamic:
        //    case ExecutionContext.GetList:
        //    case ExecutionContext.GetDynamicList:
        //    case ExecutionContext.GetValueList:
        //    case ExecutionContext.GetValue:
        //    case ExecutionContext.GetValueTable:
        //        if (base.BottomValue.HasValue)
        //        {
        //            sql = this.AssembleBottomRestrictedQuery();
        //        }
        //        else if (base.SkipValue.HasValue)
        //        {
        //            sql = this.AssembleSkipTakeRestrictedQuery();
        //        }
        //        else
        //        {
        //            sql = this.AssembleQuery();
        //        }
        //        break;
        //    case ExecutionContext.Insert:
        //        if (base.IsIdentityEntity)
        //        {
        //            sql = this.AssembleIdentityDBEntityInsertSql();
        //        }
        //        else
        //        {
        //            sql = this.AssembleInsertSql();
        //        }
        //        break;
        //    case ExecutionContext.Update:
        //        sql = this.AssembleUpdateSql();
        //        break;
        //    case ExecutionContext.Delete:
        //        sql = this.AssembleDeleteSql();
        //        break;
        //    default:
        //        throw new InvalidOperationException("encountered unknown execution context: " + base.CommandExecutionContext);
        //}

        //    return sql;
        //}
        #endregion

        #region execute
        public void Execute()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
