using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }

        public IAppender CommandTextWriter { get; private set; }

        public BeforeInsertPipelineExecutionContext(ExpressionSet expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            : base(expression)
        {
            CommandTextWriter = appender;
            ParameterBuilder = parameterBuilder;
            InsertFields = new FilteredFields(Expression, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(Expression, SqlStatementExecutionType.Insert);
        }
    }
}
