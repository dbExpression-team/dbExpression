using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeInsertContext : IPipelineExecutionContext
    {
        public ExpressionSet ExpressionSet { get; set; }
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }
        public ISqlEntityMetadata BaseEntityMetadata => ExpressionSet.BaseEntity as ISqlEntityMetadata;

        public IAppender CommandTextWriter { get; private set; }

        public BeforeInsertContext(ExpressionSet expressionSet, IAppender appender, ISqlParameterBuilder parameterBuilder)
        {
            ExpressionSet = expressionSet;
            CommandTextWriter = appender;
            ParameterBuilder = parameterBuilder;
            InsertFields = new FilteredFields(expressionSet, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(expressionSet, SqlStatementExecutionType.Insert);
        }
    }
}
