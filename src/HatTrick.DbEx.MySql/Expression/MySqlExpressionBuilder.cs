using System;
using System.Data.Common;
using System.Data;
using System.Configuration;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql;

namespace HTL.DbEx.MySql.Expression
{
    public class MySqlExpressionBuilder<T> : SqlExpressionBuilder<T> where T : class, new()
    {
        #region internals
        private readonly string _totalRecCountParamName = "total_count";
        #endregion

        #region constructors
        public MySqlExpressionBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public MySqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
        }
        #endregion

        #region get sql connection
        protected override SqlConnection GetSqlConnection()
        {
            return new MySqlConnection(base.ConnectionStringSettings);
        }
        #endregion

        #region resolve affected record count
        protected override int ResolveAffectedRecordCount()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region resolve result set count
        protected override int ResolveResultSetCount()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region assemble sql
        protected override string AssembleSql()
        {
            string sql = null;
            switch (base.CommandExecutionContext.Value)
            {
                case ExecutionContext.Get:
                case ExecutionContext.GetDynamic:
                case ExecutionContext.GetList:
                case ExecutionContext.GetDynamicList:
                case ExecutionContext.GetValueList:
                case ExecutionContext.GetValue:
                case ExecutionContext.GetValueTable:
                    sql = this.AssembleQuery();
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
                    throw new InvalidOperationException($"encountered unknown execution context: {base.CommandExecutionContext}");
            }

            return sql;
        }

        protected virtual string AssembleTotalCountQuery(string join, string where, string groupBy, string having)
        {
            DbParameter p = this.SqlClient.GetDbParameter(_totalRecCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base.DbParams.Add(p);

            string sql;

            if (IsDistinct || base.Expression.GroupBy != null || base.Expression.Having != null)
            {
                sql = $"SET {_totalRecCountParamName} := (SELECT COUNT(*) FROM (SELECT {(IsDistinct ? "DISTINCT " : string.Empty)}{base.Expression.Select} FROM {base.BaseEntity.ToString()} {join} {where} {groupBy} {having}) AS T);";
            }
            else
            {
                sql = $"SET {_totalRecCountParamName} = (SELECT COUNT(*) FROM {base.BaseEntity.ToString()} {join} {where});";
            }

            return sql;
        }

        protected virtual string AssembleAffectedRecordCountQuery()
        {
            DbParameter p = this.SqlClient.GetDbParameter(_totalRecCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base.DbParams.Add(p);

            string sql = $"SET {_totalRecCountParamName} := (SELECT ROW_COUNT());";
            return sql;
        }

        protected string AssembleQuery()
        {
            string select = string.Empty;
            string distinct = string.Empty;
            string where = string.Empty;
            string join = string.Empty;
            string orderBy = string.Empty;
            string groupBy = string.Empty;
            string having = string.Empty;
            string limit = string.Empty;
            string offset = string.Empty;
            string totalCountQuery = string.Empty;

            if (Expression.Select != null)
            {
                select = Expression.Select.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (IsDistinct)
            {
                distinct = " DISTINCT";
            }
            if (Expression.Where != null)
            {
                where = " WHERE " + Expression.Where.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.Joins != null)
            {
                join = " " + Expression.Joins.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.GroupBy != null)
            {
                groupBy = " GROUP BY " + Expression.GroupBy.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.Having != null)
            {
                having = " HAVING " + Expression.Having.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.OrderBy != null)
            {
                orderBy = " ORDER BY " + Expression.OrderBy.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (TopValue.HasValue)
            {
                limit = string.Concat("LIMIT ", base.TopValue.Value.ToString(), Environment.NewLine);
            }
            if (LimitValue.HasValue)
            {
                limit = $" LIMIT {LimitValue}";
            }
            if (SkipValue.HasValue)
            {
                offset = $" OFFSET {SkipValue}";
            }
            if (GetTotalCount)
            {
                totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);
            }

            string sql;
            sql = $@"{totalCountQuery}SELECT {distinct}{select} FROM {base.BaseEntity.ToString()}{join}{where}{groupBy}{having}{orderBy}{limit}{offset}";

            return sql;
        }

        private string AssembleInsertSql()
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = $"INSERT INTO {base.BaseEntity.ToString()} {insertClause};";
            return sql;
        }

        private string AssembleIdentityDBEntityInsertSql()
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = $"INSERT INTO {base.BaseEntity.ToString()} {insertClause}; SELECT LAST_INSERT_ID();";
            return sql;
        }

        private string AssembleUpdateSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string limit = string.Empty;

            string assignmentClause = base.Expression.Assign.ToParameterizedString(base.DbParams, this.SqlClient);

            if (Expression.Joins != null)
            {
                join = " " + Expression.Joins.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.Where != null)
            {
                where = " WHERE " + Expression.Where.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (TopValue.HasValue)
            {
                limit = $" LIMIT {base.TopValue.Value.ToString()}";
            }
            if (GetTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = $"UPDATE {base.BaseEntity.ToString()} SET {assignmentClause} FROM {base.BaseEntity.ToString()}{join}{where};{affectedRecordQuery}";
            return sql;
        }

        private string AssembleDeleteSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string limit = string.Empty;

            if (Expression.Joins != null)
            {
                join = " " + Expression.Joins.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.Where != null)
            {
                where = " WHERE " + Expression.Where.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (TopValue.HasValue)
            {
                limit = $" LIMIT {TopValue.Value.ToString()}";
            }
            if (GetTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = $"DELETE {base.BaseEntity.ToString()} FROM {base.BaseEntity.ToString()}{join}{where};{affectedRecordQuery}";
            return sql;
        }
        #endregion

        #region to sql methods
        public override string ToDeleteSql()
        {
            throw new NotImplementedException();
        }

        public override string ToGetListSql()
        {
            throw new NotImplementedException();
        }

        public override string ToGetSql()
        {
            throw new NotImplementedException();
        }

        public override string ToGetValueListSql<Y>(DBSelectExpression field)
        {
            throw new NotImplementedException();
        }

        public override string ToGetValueSql<Y>(DBSelectExpression field)
        {
            throw new NotImplementedException();
        }

        public override string ToGetValueTableSql()
        {
            throw new NotImplementedException();
        }

        public override string ToInsertSql(T obj)
        {
            throw new NotImplementedException();
        }

        public override string ToUpdateSql()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
