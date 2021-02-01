using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeUpdatePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public IEnumerable<UpdateFieldDescriptor> Fields { get; private set; }
        public SqlStatement SqlStatement { get; private set; }

        public BeforeUpdatePipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, UpdateQueryExpression expression, SqlStatement statement, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            SqlStatement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
            Fields = expression.Assign.Expressions.Select(x => new UpdateFieldDescriptor((x as IAssignmentExpressionProvider).Assignee, (x as IAssignmentExpressionProvider).Assignment)).ToList().AsReadOnly();
        }
    }
}
