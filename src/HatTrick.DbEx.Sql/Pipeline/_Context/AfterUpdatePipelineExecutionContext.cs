using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterUpdatePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public SqlStatement Statement { get; private set; }
        public IEnumerable<UpdateFieldDescriptor> Fields { get; private set; }

        public AfterUpdatePipelineExecutionContext(DatabaseConfiguration database, UpdateQueryExpression expression, SqlStatement statement)
            : base(database, expression)
        {
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
            Fields = expression.Assign.Expressions.Select(x => new UpdateFieldDescriptor((x as IAssignmentExpressionProvider).Assignee, (x as IAssignmentExpressionProvider).Assignment)).ToList().AsReadOnly();
        }
    }
}
