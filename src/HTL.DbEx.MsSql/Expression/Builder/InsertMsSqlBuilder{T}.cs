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
    public class InsertMsSqlBuilder<T> : MsSqlBuilder<T>
    {
        #region internals
        private DBExpressionEntity<T> _typedEntity;
        private T _record;
        #endregion

        #region constructors
        public InsertMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity, T record) : base(connectionStringName, baseEntity, ExecutionContext.Insert)
        {
            _typedEntity = baseEntity;
            _record = record;
            base.Expression &= baseEntity.GetInclusiveInsertExpression(record);
        }

        public InsertMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity, T record) : base(connectionStringSettings, baseEntity, ExecutionContext.Insert)
        {
            _typedEntity = baseEntity;
            _record = record;
            base.Expression &= baseEntity.GetInclusiveInsertExpression(record);
        }
        #endregion

        #region execute
        public void Execute()
        {
            Validate();

            bool isIdentity = typeof(IIdentityDBEntity).IsAssignableFrom(typeof(T));

            string sql = this.AssembleInsertSql(isIdentity);

            if (isIdentity)
            {
                var r32 = _record as I32BitIdentityDBEntity;
                if (r32 != null)
                {
                    base.Insert(sql, r32);
                }
                else
                {
                    var r64 = _record as I64BitIdentityDBEntity;
                    if (r64 != null)
                    {
                        base.Insert(sql, r64);
                    }
                    else
                    {
                        throw new InvalidOperationException("encounterd un-expected identity type");
                    }
                }
            }
            else
            {
                base.Insert(sql);
            }
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region assemble insert sql
        private string AssembleInsertSql(bool isIdentity)
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1};", base.BaseEntity.ToString(), insertClause);
            return (isIdentity) ? sql + " SELECT SCOPE_IDENTITY();" : sql;
        }
        #endregion

        #region enlist
        public new InsertMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        //HACK
        private new InsertMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        //HACK
        private new InsertMsSqlBuilder<T> Distinct()
        {
            base.Distinct();
            return this;
        }
        #endregion

        #region skip
        //HACK
        private new DBSkipDirective Skip(int count)
        {
            base.SkipValue = count;
            return new DBSkipDirective(this);
        }
        #endregion

        #region set fields
        //HACK
        private new InsertMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new InsertMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new InsertMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        //HACK
        private new InsertMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        //HACK
        private new InsertMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        //HACK
        private new InsertMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        //HACK
        private new InsertMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        //HACK
        private new DBJoinDirective InnerJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        //HACK
        private new DBJoinDirective LeftJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        //HACK
        private new DBJoinDirective RightJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        //Hack
        private new DBJoinDirective FullJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
