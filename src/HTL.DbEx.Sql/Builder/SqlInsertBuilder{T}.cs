using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder
{
    public class SqlInsertBuilder<T> : SqlBuilder<T>, 
        IInsertBuilder<T>,
        ITerminationBuilder, 
        IBuilder<T>
        where T : class, IDBEntity
    {
        public SqlInsertBuilder(DBExpressionSet expression) : base(expression)
        {
        }

        ITerminationBuilder IInsertBuilder<T>.Into<U>(U entity)
        {
            Expression.BaseEntity = entity;
            Expression &= entity.GetInclusiveInsertExpression((T)Expression.Instance);
            return this;
        }
    }
}
