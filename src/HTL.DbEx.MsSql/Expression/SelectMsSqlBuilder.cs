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
    public class SelectMsSqlBuilder<T> : MsSqlBuilder<T>
    {
        #region constructors
        public SelectMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity, ExecutionContext context) : base(connectionStringName, baseEntity, context)
        {
        }

        public SelectMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, ExecutionContext context) : base(connectionStringSettings, baseEntity, context)
        {
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region assemble query
        protected string AssembleQuery()
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

            var nl = Environment.NewLine;
            string sql = $"SELECT{nl}" +
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
        #endregion

        #region assemble skip take restricted query
        protected string AssembleSkipTakeRestrictedQuery()
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

            string sql;
            sql = string.Format(@"
            SELECT * FROM (
                SELECT 
                {0}{1},
                ROW_NUMBER() OVER ( {2} ) AS [RowIndex]
                FROM {7}
                    {3}
                    {4}
                    {5}
                    {6}
            ) AS {8} WHERE [RowIndex] BETWEEN {9} AND {10} ORDER BY [RowIndex];",
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
        #endregion
    }
}