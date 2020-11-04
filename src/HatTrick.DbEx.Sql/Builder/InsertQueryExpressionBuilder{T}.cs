using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class InsertQueryExpressionBuilder<T> : QueryExpressionBuilder<T>,
        IInsertExpressionBuilder<T>,
        IInsertTerminationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        #region internals
        private readonly IEnumerable<T> instances;
        public new InsertQueryExpression Expression => base.Expression as InsertQueryExpression;
        #endregion

        #region constructors
        protected InsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, IEnumerable<T> instances, InsertQueryExpression expression) : base(configuration, expression)
        {
            this.instances = instances;
        }
        #endregion

        #region methods
        IInsertTerminationExpressionBuilder<T> IInsertExpressionBuilder<T>.Into<U>(U entity)
        {
            var i = 0;
            Expression.BaseEntity = entity;
            Expression.Inserts = instances.ToDictionary(x => i++, x => new InsertExpressionSet(x, (entity as IExpressionEntity<T>).BuildInclusiveInsertExpression(x).Expressions));
            return this;
        }
        #endregion
    }
}
