using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class FieldDescriptor
    { 
        public FieldExpression Field { get; private set; }
        public ISqlFieldMetadata Metadata => (Field as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata;

        public FieldDescriptor(FieldExpression field)
        {
            Field = field;
        }
    }

    public class BeforeInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public IEnumerable<FieldDescriptor> InsertFields { get; private set; }
        public IEnumerable<FieldDescriptor> AllFields { get; private set; }

        public IAppender CommandTextWriter { get; private set; }

        public BeforeInsertPipelineExecutionContext(InsertQueryExpression expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            : base(expression)
        {
            CommandTextWriter = appender;
            ParameterBuilder = parameterBuilder;
            InsertFields = expression.Insert.Expressions.Select(x => new FieldDescriptor((x as IDbInsertExpressionProvider).Assignee)).ToList().AsReadOnly();
            AllFields = (expression.BaseEntity as IDbExpressionListProvider<FieldExpression>).Expressions.Select(x => new FieldDescriptor(x)).ToList().AsReadOnly();
        }
    }
}
