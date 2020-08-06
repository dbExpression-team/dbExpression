using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public IDbEntity Entity { get; private set; }
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public IEnumerable<InsertFieldDescriptor> Fields { get; private set; }
        public IAppender CommandTextWriter { get; private set; }

        public BeforeInsertPipelineExecutionContext(DatabaseConfiguration database, InsertQueryExpression expression, InsertExpressionSet target, IAppender appender, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            CommandTextWriter = appender ?? throw new ArgumentNullException($"{nameof(appender)} is required.");
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
            Entity = target?.Entity ?? throw new ArgumentNullException($"{nameof(target)} is required.");
            Fields = target.Expressions.Select(x => new InsertFieldDescriptor((x as IAssignmentExpressionProvider).Assignee, (x as IAssignmentExpressionProvider).Assignment)).ToList().AsReadOnly();
        }
    }
}
