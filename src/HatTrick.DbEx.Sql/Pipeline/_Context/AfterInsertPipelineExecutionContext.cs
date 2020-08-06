using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public IEnumerable<InsertFieldDescriptor> Fields { get; private set; }
        public InsertedEntityPipelineExecutionContext Entity { get; private set; }
        public SqlStatement Statement { get; private set; }

        public AfterInsertPipelineExecutionContext(DatabaseConfiguration database, InsertQueryExpression expression, InsertExpressionSet target, SqlStatement statement)
            : base(database, expression)
        {
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
            Fields = target.Expressions.Select(x => new InsertFieldDescriptor((x as IDbAssignmentExpressionProvider).Assignee, (x as IDbAssignmentExpressionProvider).Assignment)).ToList().AsReadOnly();
            Entity = new InsertedEntityPipelineExecutionContext(database, expression, target);
        }
    }
}
