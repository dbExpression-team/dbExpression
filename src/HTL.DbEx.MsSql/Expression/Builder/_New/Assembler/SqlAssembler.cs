using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New.Assembler
{
    public class SqlAssembler
    {
        public DBExpressionSet Expression { get; set; }

        public SqlAssembler(DBExpressionSet expression)
        {
            Expression = expression;
        }

        public string Assemble()
        {
            string sql = null;
            switch (Expression.ExecutionContext)
            {
                case ExecutionContext.Get:
                case ExecutionContext.GetDynamic:
                case ExecutionContext.GetList:
                case ExecutionContext.GetDynamicList:
                case ExecutionContext.GetValueList:
                case ExecutionContext.GetValue:
                case ExecutionContext.GetValueTable:
                    if (base.BottomValue.HasValue)
                    {
                        sql = this.AssembleBottomRestrictedQuery();
                    }
                    else if (base.SkipValue.HasValue)
                    {
                        sql = this.AssembleSkipTakeRestrictedQuery();
                    }
                    else
                    {
                        sql = this.AssembleQuery();
                    }
                    break;
                case ExecutionContext.Insert:
                    if (base.IsIdentityEntity)
                    {
                        sql = this.AssembleIdentityDBEntityInsertSql();
                    }
                    else
                    {
                        sql = this.AssembleInsertSql();
                    }
                    break;
                case ExecutionContext.Update:
                    sql = this.AssembleUpdateSql();
                    break;
                case ExecutionContext.Delete:
                    sql = this.AssembleDeleteSql();
                    break;
                default:
                    throw new InvalidOperationException("encountered unknown execution context: " + base.CommandExecutionContext);
            }

            return sql;
            return string.Empty;
        }
    }
}
