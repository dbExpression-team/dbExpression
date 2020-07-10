using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        private ISqlParameterBuilder ParameterBuilder { get; set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }

        public InsertedEntityPipelineExecutionContext Entity { get; private set; }
        public IEnumerable<ParameterizedFieldExpression> Parameters => ParameterBuilder.Parameters.ToList().AsReadOnly();

        public AfterInsertPipelineExecutionContext(ExpressionSet expression, ISqlParameterBuilder parameterBuilder, IMapperFactory mapperFactory)
            : base(expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
            InsertFields = new FilteredFields(expression, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(expression, SqlStatementExecutionType.Insert);
            Entity = new InsertedEntityPipelineExecutionContext(Expression, mapperFactory ?? throw new ArgumentNullException($"{nameof(mapperFactory)} is required."));
        }
    }
}
