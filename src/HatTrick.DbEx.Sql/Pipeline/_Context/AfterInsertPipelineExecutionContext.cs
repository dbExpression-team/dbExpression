using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        #region internals
        private readonly IDbEntity entity;
        #endregion

        #region interface
        public override Type EntityType => entity.GetType();
        #endregion

        #region constructors
        public AfterInsertPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression, IDbEntity entity)
            : base(database, expression)
        {
            this.entity = entity ?? throw new ArgumentNullException($"{nameof(entity)} is required.");
        }
        #endregion

        #region methods
        public TEntity GetEntity<TEntity>()
            where TEntity : class, IDbEntity
            => entity as TEntity;
        #endregion
    }
}
