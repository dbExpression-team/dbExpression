using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Configuration;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql;

namespace HTL.DbEx.MySql.Expression
{
    public class MySqlExpressionBuilder<T> : SqlExpressionBuilder<T> where T : new()
    {
        #region internals
        private readonly string _totalRecCountParamName = "total_count";
        #endregion

        #region constructors
        public MySqlExpressionBuilder(string connectionStringName, DBExpressionEntity baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public MySqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity) : base(connectionStringSettings, baseEntity)
        {
        }
        #endregion

        #region get sql connection
        protected override SqlConnection GetSqlConnection()
        {
            return new MySqlConnection(base._connectionStringSettings);
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
            switch (base._execContext.Value)
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
            DbParameter p = this.SqlClient.GetDbParameter(_totalRecCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base._dbParams.Add(p);

            string sql;

            if (_isDistinct || base._set.GroupBy != null || base._set.Having != null)
            {
                sql = $"SET {_totalRecCountParamName} := (SELECT COUNT(*) FROM (SELECT {(_isDistinct ? "DISTINCT " : string.Empty)}{base._set.Select} FROM {base._baseEntity.ToString()} {join} {where} {groupBy} {having}) AS T);";
            }
            else
            {
                sql = $"SET {_totalRecCountParamName} = (SELECT COUNT(*) FROM {base._baseEntity.ToString()} {join} {where});";
            }

            return sql;
        }

        protected virtual string AssembleAffectedRecordCountQuery()
        {
            DbParameter p = this.SqlClient.GetDbParameter(_totalRecCountParamName, DBNull.Value, typeof(int), null);
            p.Direction = ParameterDirection.Output;
            base._dbParams.Add(p);

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

            if (_set.Select != null)
            {
                select = _set.Select.ToParameterizedString(base._dbParams, this.SqlClient);
            }
            if (_isDistinct)
            {
                distinct = " DISTINCT";
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
                limit = string.Concat("LIMIT ", base._top.Value.ToString(), Environment.NewLine);
            }
            if (_limit.HasValue)
            {
                limit = $" LIMIT {_limit}";
            }
            if (_skip.HasValue)
            {
                offset = $" OFFSET {_skip}";
            }
            if (_getTotalCount)
            {
                totalCountQuery = this.AssembleTotalCountQuery(join, where, groupBy, having);
            }

            string sql;
            sql = $@"{totalCountQuery}SELECT {distinct}{select} FROM {base._baseEntity.ToString()}{join}{where}{groupBy}{having}{orderBy}{limit}{offset}";

            return sql;
        }

        private string AssembleInsertSql()
        {
            string insertClause = base._set.Insert.ToParameterizedString(base._dbParams, this.SqlClient);

            string sql = $"INSERT INTO {base._baseEntity.ToString()} {insertClause};";
            return sql;
        }

        private string AssembleIdentityDBEntityInsertSql()
        {
            string insertClause = base._set.Insert.ToParameterizedString(base._dbParams, this.SqlClient);

            string sql = $"INSERT INTO {base._baseEntity.ToString()} {insertClause}; SELECT LAST_INSERT_ID();";
            return sql;
        }

        private string AssembleUpdateSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string limit = string.Empty;

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
                limit = $" LIMIT {base._top.Value.ToString()}";
            }
            if (_getTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = $"UPDATE {base._baseEntity.ToString()} SET {assignmentClause} FROM {base._baseEntity.ToString()}{join}{where};{affectedRecordQuery}";
            return sql;
        }

        private string AssembleDeleteSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string affectedRecordQuery = string.Empty;
            string limit = string.Empty;

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
                limit = $" LIMIT {_top.Value.ToString()}";
            }
            if (_getTotalCount)
            {
                affectedRecordQuery = this.AssembleAffectedRecordCountQuery();
            }

            string sql;
            sql = $"DELETE {base._baseEntity.ToString()} FROM {base._baseEntity.ToString()}{join}{where};{affectedRecordQuery}";
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
