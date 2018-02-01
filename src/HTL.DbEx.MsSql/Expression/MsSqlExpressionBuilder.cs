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
    public class MsSqlExpressionBuilder<T> : SqlExpressionBuilder<T> where T : new()
    {
        #region interface
        internal static readonly string TotalRecordCountParamName = "@TotalCount";
        #endregion

        #region constructors
        public MsSqlExpressionBuilder(string connectionStringName, DBExpressionEntity baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public MsSqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity) : base(connectionStringSettings, baseEntity)
        {
        }
        #endregion

        #region get sql connection
        protected override SqlConnection GetSqlConnection()
        {
            return new MsSqlConnection(base._connectionStringSettings);
        }
        #endregion

        #region sql assembly methods
        protected override string AssembleSql()
        {
            string sql;
            switch (base._execContext.Value)
            {
                case ExecutionContext.Get:
                case ExecutionContext.GetDynamic:
                case ExecutionContext.GetList:
                case ExecutionContext.GetDynamicList:
                case ExecutionContext.GetValueList:
                case ExecutionContext.GetValue:
                case ExecutionContext.GetValueTable:
                    if (base._bottom.HasValue)
                    {
                        sql = this.AssembleBottomRestrictedQuery();
                    }
                    else if (base._skip.HasValue)
                    {
                        sql = this.AssembleSkipTakeRestrictedQuery();
                    }
                    else
                    {
                        sql = this.AssembleQuery();
                    }
                    break;
                case ExecutionContext.Insert:
                    if (base._isIdentityEntity)
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
                    throw new InvalidOperationException("encountered unknown execution context: " + base._execContext);
            }

            return sql;
        }

        protected virtual string AssembleTotalCountQuery(string join, string where, string groupBy, string having)
        {
            DbParameter p = this.SqlClient.GetDbParameter(TotalRecordCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base._dbParams.Add(p);

            string sql;

            if (_isDistinct || base._set.GroupBy != null || base._set.Having != null)
            {
                sql = string.Format(@"SET {0} = (SELECT COUNT(*) FROM (SELECT {1}{2} FROM {3} {4} {5} {6} {7}) AS T);",
                TotalRecordCountParamName,
                (_isDistinct) ? "DISTINCT " : string.Empty,
                base._set.Select,
                base._baseEntity.ToString(),
                join,
                where,
                groupBy,
                having);
            }
            else
            {
                sql = string.Format(@"SET {0} = (SELECT COUNT(*) FROM {1} {2} {3});",
                TotalRecordCountParamName,
                base._baseEntity.ToString(),
                join,
                where);
            }

            return sql;
        }

        protected virtual string AssembleAffectedRecordCountQuery()
        {
            DbParameter p = this.SqlClient.GetDbParameter(TotalRecordCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base._dbParams.Add(p);

            string sql = string.Format("SET {0} = (SELECT @@ROWCOUNT);", TotalRecordCountParamName);
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

            if (_set.Select != null)
            {
                select = _set.Select.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Where != null)
            {
                where = " WHERE " + _set.Where.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Joins != null)
            {
                join = " " + _set.Joins.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.GroupBy != null)
            {
                groupBy = " GROUP BY " + _set.GroupBy.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Having != null)
            {
                having = " HAVING " + _set.Having.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.OrderBy != null)
            {
                orderBy = " ORDER BY " + _set.OrderBy.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_top.HasValue)
            {
                top = string.Concat("TOP (", base._top.Value.ToString(), ")", Environment.NewLine);
            }
            if (_getTotalCount)
            {
                totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);
            }

            string sql;
            sql = string.Format(@"
            {0}
            SELECT
            {1}{2}{3}
            FROM {4}
                {5}
                {6}
                {7}
                {8}
                {9}",
            totalCountQuery,
            (_isDistinct) ? "DISTINCT " : string.Empty,
            top,
            select,
            base._baseEntity.ToString(),
            join,
            where,
            groupBy,
            having,
            orderBy);

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

            if (_set.Select != null)
            {
                select = _set.Select.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Where != null)
            {
                where = " WHERE " + _set.Where.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Joins != null)
            {
                join = " " + _set.Joins.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.GroupBy != null)
            {
                groupBy = " GROUP BY " + _set.GroupBy.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Having != null)
            {
                having = " HAVING " + _set.Having.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.OrderBy != null)
            {
                orderBy = " ORDER BY " + _set.OrderBy.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_getTotalCount)
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
            (_isDistinct) ? "DISTINCT " : string.Empty,
            select,
            orderBy,
            join,
            where,
            groupBy,
            having,
            this.BaseEntity,
            this.BaseEntity.ToString("[s.e]"),
            (_skip.Value + 1),
            (_skip.Value + base._limit.Value));

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

            if (_set.Select != null)
            {
                select = _set.Select.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Where != null)
            {
                where = " WHERE " + _set.Where.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Joins != null)
            {
                join = " " + _set.Joins.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.GroupBy != null)
            {
                groupBy = " GROUP BY " + _set.GroupBy.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Having != null)
            {
                having = " HAVING " + _set.Having.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.OrderBy != null)
            {
                order = " ORDER BY " + _set.OrderBy.ToParameterizedString(base._dbParams, this.SqlClient);
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
            (_isDistinct) ? "DISTINCT " : string.Empty,
            select,
            order,
            join,
            where,
            groupBy,
            having,
            this.BaseEntity,
            this.BaseEntity.ToString("[s.e]"),
            (_bottom.Value - 1),
            TotalRecordCountParamName);

            return sql;
        }

        private string AssembleInsertSql()
        {
            string insertClause = base._set.Insert.ToParameterizedString(base._dbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1};", base._baseEntity.ToString(), insertClause);
            return sql;
        }

        private string AssembleIdentityDBEntityInsertSql()
        {
            string insertClause = base._set.Insert.ToParameterizedString(base._dbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1}; SELECT SCOPE_IDENTITY();", base._baseEntity.ToString(), insertClause);
            return sql;
        }

        private string AssembleUpdateSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string topExpression = string.Empty;
            
            string assignmentClause = base._set.Assign.ToParameterizedString(base._dbParams, this.SqlClient);

            if (_set.Joins != null)
            {
                join = " " + _set.Joins.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Where != null)
            {
                where = " WHERE " + _set.Where.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_top.HasValue)
            {
                topExpression = string.Concat("TOP (", base._top.Value.ToString(), ")", Environment.NewLine);
            }
            if (_getTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = string.Format("UPDATE {0} {1} SET {2} FROM {1}{3}{4};{5}", topExpression, base._baseEntity.ToString(), assignmentClause, join, where, affectedRecordQuery);
            return sql;
        }

        private string AssembleDeleteSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string topExpression = string.Empty;

            if (_set.Joins != null)
            {
                join = " " + _set.Joins.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_set.Where != null)
            {
                where = " WHERE " + _set.Where.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_top.HasValue)
            {
                topExpression = string.Concat("TOP (", base._top.Value.ToString(), ")", Environment.NewLine);
            }
            if (_getTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = string.Format("DELETE {0} {1} FROM {1}{2}{3};{4}", topExpression, base._baseEntity.ToString(), join, where, affectedRecordQuery);
            return sql;
        }
        #endregion

        #region resolve result set count
        protected override int ResolveResultSetCount()
        {
            int val = -1;
            DbParameter parameter = _dbParams.Find(p => p.ParameterName == TotalRecordCountParamName);
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
            base._execContext = ExecutionContext.Get;
            base.ValidateExpression();

            base._set.ClearSelect();
            base._set &= base._selectExprProvider.Invoke();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToGetListSql()
        {
            base._set.ClearSelect();
            base._set &= base._selectExprProvider.Invoke();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueListSql<Y>(DBSelectExpression field)
        {
            base._execContext = ExecutionContext.GetValueList;
            base.ValidateExpression();

            base._set.ClearSelect();
            base._set &= field;

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueSql<Y>(DBSelectExpression field)
        {
            base._execContext = ExecutionContext.GetValue;
            base.ValidateExpression();

            base._set.ClearSelect();
            base._set &= field;

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToGetValueTableSql()
        {
            base._execContext = ExecutionContext.GetValueTable;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);

            return sql;
        }

        public override string ToInsertSql(T obj)
        {
            base._execContext = ExecutionContext.Insert;
            base.ValidateExpression();

            if (_insertExpressionProvider != null)
            {
                base._set &= _insertExpressionProvider(obj);
            }
            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToUpdateSql()
        {
            base._execContext = ExecutionContext.Update;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        public override string ToDeleteSql()
        {
            base._execContext = ExecutionContext.Delete;
            base.ValidateExpression();

            string sql = this.AssembleSql();

            sql = this.InjectParameters(sql);
            return sql;
        }

        private string InjectParameters(string sql)
        {
            Type t = null;
            for (int i = 0; i < base._dbParams.Count; i++)
            {
                t = base._dbParams[i].Value.GetType();
                if (t.IsEnum)
                {
                    sql = sql.Replace(base._dbParams[i].ParameterName, TypeUtility.GetUnderlyingEnumIntegral(t, base._dbParams[i].Value).ToString());
                }
                else if (TypeUtility.IsIntegralType(t) || TypeUtility.IsDecimalType(t) || TypeUtility.IsFloatingPointType(t))
                {
                    sql = sql.Replace(base._dbParams[i].ParameterName, base._dbParams[i].Value.ToString());
                }
                else if (t == typeof(byte[]) || t == typeof(string) || t == typeof(DateTime) || t == typeof(Guid))
                {
                    sql = sql.Replace(base._dbParams[i].ParameterName, "'" + base._dbParams[i].Value.ToString() + "'");
                }
                else if (t == typeof(DBSelectExpression))
                {
                    sql = sql.Replace(base._dbParams[i].ParameterName, base._dbParams[i].Value.ToString());
                }
            }
            return sql;
        }
        #endregion
    }
}
