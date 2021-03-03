using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeDeletePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        #region interface
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public SqlStatement SqlStatement { get; private set; }
        #endregion

        #region constructors
        public BeforeDeletePipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, DeleteQueryExpression expression, ISqlParameterBuilder parameterBuilder, SqlStatement statement)
            : base(database, expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
            SqlStatement = statement ?? throw new ArgumentNullException(nameof(statement));
        }
        #endregion
    }
}
