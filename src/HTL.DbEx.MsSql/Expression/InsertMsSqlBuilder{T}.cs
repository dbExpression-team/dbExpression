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
        public new void Execute()
        {
            Validate();

            bool isIdentity = typeof(T) == typeof(IIdentityDBEntity);

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
    }
}
