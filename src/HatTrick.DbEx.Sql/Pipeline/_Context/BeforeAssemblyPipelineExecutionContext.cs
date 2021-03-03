using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        
        public BeforeAssemblyPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
        }
    }
}
