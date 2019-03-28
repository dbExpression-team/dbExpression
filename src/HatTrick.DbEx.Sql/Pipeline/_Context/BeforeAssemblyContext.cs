using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyContext : IPipelineExecutionContext
    {
        private ExpressionSet ExpressionSet { get; set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }
        public ISqlEntityMetadata BaseEntityMetadata => ExpressionSet.BaseEntity as ISqlEntityMetadata;

        public BeforeAssemblyContext(ExpressionSet set)
        {
            ExpressionSet = set;
            InsertFields = new FilteredFields(set, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(set, SqlStatementExecutionType.Insert);
        }
    }
}
