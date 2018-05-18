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
    public class MsSqlExpressionBuilder<T> : SqlExpressionBuilder<T> where T : class, new()
    {
        #region interface
        internal static readonly string TotalRecordCountParamName = "@TotalCount";
        #endregion

        #region constructors
        public MsSqlExpressionBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public MsSqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
        }
        #endregion

        #region get sql connection
        protected override SqlConnection GetSqlConnection()
        {
            return new MsSqlConnection(base.ConnectionStringSettings);
        }
        #endregion

        #region sql assembly methods
        protected override string AssembleSql()
        {
            string sql;
            switch (base.CommandExecutionContext.Value)
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
        }

        protected virtual string AssembleTotalCountQuery(string join, string where, string groupBy, string having)
        {
            DbParameter p = this.SqlClient.GetDbParameter(TotalRecordCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base.DbParams.Add(p);

            string sql;

            if (IsDistinct || base.Expression.GroupBy != null || base.Expression.Having != null)
            {
                sql = $"SET {TotalRecordCountParamName} = (SELECT COUNT(*) " +
                    $"FROM (SELECT {(IsDistinct ? "DISTINCT " : string.Empty)}{base.Expression.Select} " +
                    $"FROM {base.BaseEntity} {join} {where} {groupBy} {having}) AS T);";
            }
            else
            {
                sql = $"SET {TotalRecordCountParamName} = (SELECT COUNT(*) FROM {base.BaseEntity} {join} {where});";
            }

            return sql;
        }

        protected virtual string AssembleAffectedRecordCountQuery()
        {
            DbParameter p = this.SqlClient.GetDbParameter(TotalRecordCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base.DbParams.Add(p);

            string sql = $"SET {TotalRecordCountParamName} = (SELECT @@ROWCOUNT);";
            return sql;
        }

        private string AssembleQuery()
        {
            string select = string.Empty;
            string where = string.Empty;
            string join = string.Empty;
            string orderBy = string.Empty;
            string groupBy = string.Empty;
            string having = string.Empty;
            string top = string.Empty;
            string totalCountQuery = string.Empty;

            if (Expression.Select != null)
            {
                select = Expression.Select.ToParameterizedString(base.DbParams, this.SqlClient);
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
                top = string.Concat("TOP (", base.TopValue.Value.ToString(), ")", Environment.NewLine);
            }
            if (GetTotalCount)
            {
                totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);
            }

            var nl = Environment.NewLine;
            string sql = $"{totalCountQuery}{nl}" +
                $"SELECT{nl}" +
                $"{(IsDistinct ? "DISTINCT " : string.Empty)}{top}{nl}" +
                $"{select}{nl}" +
                $"FROM {base.BaseEntity}{nl}" +
                $"{join}{nl}" +
                $"{where}{nl}" +
                $"{groupBy}{nl}" +
                $"{having}{nl}" +
                $"{orderBy}";

            return sql;
        }

        private string AssembleSkipTakeRestrictedQuery()
        {
            string select = string.Empty;
            string where = string.Empty;
            string join = string.Empty;
            string groupBy = string.Empty;
            string having = string.Empty;
            string orderBy = string.Empty;
            string totalCountQuery = string.Empty;

            if (Expression.Select != null)
            {
                select = Expression.Select.ToParameterizedString(base.DbParams, this.SqlClient);
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
            if (GetTotalCount)
            {
                totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);
            }

            string sql;
            sql = string.Format(@"
            {0}
            SELECT * FROM (
                SELECT 
                {1}{2},
                ROW_NUMBER() OVER ( {3} ) AS [RowIndex]
                FROM {8}
                    {4}
                    {5}
                    {6}
                    {7}
            ) AS {9} WHERE [RowIndex] BETWEEN {10} AND {11} ORDER BY [RowIndex];",
            totalCountQuery,
            (IsDistinct) ? "DISTINCT " : string.Empty,
            select,
            orderBy,
            join,
            where,
            groupBy,
            having,
            this.BaseEntity,
            this.BaseEntity.ToString("[s.e]"),
            (SkipValue.Value + 1),
            (SkipValue.Value + base.LimitValue.Value));

            return sql;
        }

        private string AssembleBottomRestrictedQuery()
        {
            string select = string.Empty;
            string where = string.Empty;
            string join = string.Empty;
            string groupBy = string.Empty;
            string having = string.Empty;
            string order = string.Empty;
            string totalCountQuery = string.Empty;

            if (Expression.Select != null)
            {
                select = Expression.Select.ToParameterizedString(base.DbParams, this.SqlClient);
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
                order = " ORDER BY " + Expression.OrderBy.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            //this function always requires the totalCount be queried...
            totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);

            string sql;
            sql = string.Format(@"
            {0}
            SELECT * FROM (
                SELECT 
                {1}{2},
                ROW_NUMBER() OVER ( {3} ) AS [RowIndex]
                FROM {8}
                    {4}
                    {5}
                    {6}
                    {7}
            ) AS {9} WHERE [RowIndex] BETWEEN ({11} - {10}) AND {11} ORDER BY [RowIndex];",
            totalCountQuery,
            (IsDistinct) ? "DISTINCT " : string.Empty,
            select,
            order,
            join,
            where,
            groupBy,
            having,
            this.BaseEntity,
            this.BaseEntity.ToString("[s.e]"),
            (BottomValue.Value - 1),
            TotalRecordCountParamName);

            return sql;
        }

        private string AssembleInsertSql()
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1};", base.BaseEntity.ToString(), insertClause);
            return sql;
        }

        private string AssembleIdentityDBEntityInsertSql()
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1}; SELECT SCOPE_IDENTITY();", base.BaseEntity.ToString(), insertClause);
            return sql;
        }

        private string AssembleUpdateSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string topExpression = string.Empty;
            
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
                topExpression = string.Concat("TOP (", base.TopValue.Value.ToString(), ")", Environment.NewLine);
            }
            if (GetTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = string.Format("UPDATE {0} {1} SET {2} FROM {1}{3}{4};{5}", topExpression, base.BaseEntity.ToString(), assignmentClause, join, where, affectedRecordQuery);
            return sql;
        }

        private string AssembleDeleteSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string topExpression = string.Empty;

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
                topExpression = string.Concat("TOP (", base.TopValue.Value.ToString(), ")", Environment.NewLine);
            }
            if (GetTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = string.Format("DELETE {0} {1} FROM {1}{2}{3};{4}", topExpression, base.BaseEntity.ToString(), join, where, affectedRecordQuery);
            return sql;
        }
        #endregion

        #region resolve result set count
        protected override int ResolveResultSetCount()
        {
            int val = -1;
            DbParameter parameter = DbParams.Find(p => p.ParameterName == TotalRecordCountParamName);
            if (parameter != null && parameter.Value != DBNull.Value)
            {
                val = (int)parameter.Value;
            }
            return val;
        }
        #endregion

        #region resolve affected record count count
        protected override int ResolveAffectedRecordCount()
        {
            return this.ResolveResultSetCount();
        }
        #endregion

        #region utility methods
        public override string ToGetSql()
        {
            base.CommandExecutionContext = ExecutionContext.Get;
            base.ValidateExpression();

            base.Expression.ClearSelect();
            base.Expression &= BaseEntity.SelectExpressionProvider();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToGetListSql()
        {
            base.Expression.ClearSelect();
            base.Expression &= BaseEntity.SelectExpressionProvider();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueListSql<Y>(DBSelectExpression field)
        {
            base.CommandExecutionContext = ExecutionContext.GetValueList;
            base.ValidateExpression();

            base.Expression.ClearSelect();
            base.Expression &= field;

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueSql<Y>(DBSelectExpression field)
        {
            base.CommandExecutionContext = ExecutionContext.GetValue;
            base.ValidateExpression();

            base.Expression.ClearSelect();
            base.Expression &= field;

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueTableSql()
        {
            base.CommandExecutionContext = ExecutionContext.GetValueTable;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToInsertSql(T obj)
        {
            base.CommandExecutionContext = ExecutionContext.Insert;
            base.ValidateExpression();

            if (BaseEntity.InsertExpressionProvider != null)
            {
                base.Expression &= BaseEntity.InsertExpressionProvider(obj);
            }
            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToUpdateSql()
        {
            base.CommandExecutionContext = ExecutionContext.Update;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToDeleteSql()
        {
            base.CommandExecutionContext = ExecutionContext.Delete;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        private string InjectParameters(string sql)
        {
            Type t = null;
            for (int i = 0; i < base.DbParams.Count; i++)
            {
                t = base.DbParams[i].Value.GetType();
                if (t.IsEnum)
                {
                    sql = sql.Replace(base.DbParams[i].ParameterName, TypeUtility.GetUnderlyingEnumIntegral(t, base.DbParams[i].Value).ToString());
                }
                else if (TypeUtility.IsIntegralType(t) || TypeUtility.IsDecimalType(t) || TypeUtility.IsFloatingPointType(t))
                {
                    sql = sql.Replace(base.DbParams[i].ParameterName, base.DbParams[i].Value.ToString());
                }
                else if (t == typeof(byte[]) || t == typeof(string) || t == typeof(DateTime) || t == typeof(Guid))
                {
                    sql = sql.Replace(base.DbParams[i].ParameterName, "'" + base.DbParams[i].Value.ToString() + "'");
                }
                else if (t == typeof(DBSelectExpression))
                {
                    sql = sql.Replace(base.DbParams[i].ParameterName, base.DbParams[i].Value.ToString());
                }
            }
            return sql;
        }
        #endregion
    }
}
