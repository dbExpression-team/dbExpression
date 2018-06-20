﻿using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class SqlBuilder<T, U, V> : SqlBuilder<T, U>,
        IFromBuilder<T, U, V>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        public SqlBuilder(DBExpressionSet expression) : base(expression)
        {
        }

        #region Select
        V IFromBuilder<T, U, V>.From(DBExpressionEntity entity)
        {
            Expression.BaseEntity = entity;
            return this as V;
        }
        #endregion
    }
}
