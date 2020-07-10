using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }

        public BeforeAssemblyPipelineExecutionContext(ExpressionSet expression)
            : base(expression)
        {
            InsertFields = new FilteredFields(expression, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(expression, SqlStatementExecutionType.Insert);
        }
    }
}
