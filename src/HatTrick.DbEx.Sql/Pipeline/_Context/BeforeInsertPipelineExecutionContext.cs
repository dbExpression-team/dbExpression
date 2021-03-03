using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        #region internals
        private readonly IDbEntity entity;
        #endregion

        #region interface
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public SqlStatement SqlStatement { get; private set; }
        public override Type EntityType => entity.GetType();
        #endregion

        #region constructors
        public BeforeInsertPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, InsertQueryExpression expression, IDbEntity entity, ISqlParameterBuilder parameterBuilder, SqlStatement statement)
            : base(database, expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
            SqlStatement = statement ?? throw new ArgumentNullException(nameof(statement));
            this.entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        public TEntity GetEntity<TEntity>()
            where TEntity : class, IDbEntity
            => entity as TEntity;
        #endregion
    }
}
