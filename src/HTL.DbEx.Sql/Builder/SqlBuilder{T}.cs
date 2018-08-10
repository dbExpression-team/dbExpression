using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder
{
    public class SqlBuilder<T> : SqlBuilder,
        IValueContinuationBuilder<T>,
        IValueListContinuationBuilder<T>
    {

        #region constructors
        public SqlBuilder(DBExpressionSet expression) : base(expression)
        { }
        #endregion

        #region validate
        //protected override void Validate()
        //{
        //    base.Validate();
        //}
        #endregion

        #region get sql connection
        //protected override SqlConnection GetSqlConnection()
        //{
        //    return new MsSqlConnection(base.ConnectionStringSettings);
        //}
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
    }
}
