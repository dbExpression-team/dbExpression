using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        private ISqlParameterBuilder ParameterBuilder { get; set; }
        protected new InsertQueryExpression Expression { get; private set; }
        public IEnumerable<FieldDescriptor> InsertFields { get; private set; }
        public IEnumerable<FieldDescriptor> AllFields { get; private set; }

        public InsertedEntityPipelineExecutionContext Entity { get; private set; }
        public IEnumerable<ParameterizedFieldExpression> Parameters => ParameterBuilder.Parameters.ToList().AsReadOnly();

        public AfterInsertPipelineExecutionContext(InsertQueryExpression expression, ISqlParameterBuilder parameterBuilder, IMapperFactory mapperFactory)
            : base(expression)
        {
            Expression = expression;
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
            InsertFields = expression.Insert.Expressions.Select(x => new FieldDescriptor((x as IDbInsertExpressionProvider).Assignee)).ToList().AsReadOnly();
            AllFields = (expression.BaseEntity as IDbExpressionListProvider<FieldExpression>).Expressions.Select(x => new FieldDescriptor(x)).ToList().AsReadOnly();
            Entity = new InsertedEntityPipelineExecutionContext(Expression, mapperFactory ?? throw new ArgumentNullException($"{nameof(mapperFactory)} is required."));
        }
    }
}
