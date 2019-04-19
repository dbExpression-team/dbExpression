using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyContext : IPipelineExecutionContext
    {
        private ExpressionSet ExpressionSet { get; set; }
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }
        public ISqlEntityMetadata BaseEntityMetadata => ExpressionSet.BaseEntity as ISqlEntityMetadata;

        public ISqlStatementBuilder SqlStatementBuilder { get; private set; }

        public AfterAssemblyContext(ExpressionSet set, ISqlStatementBuilder builder)
        {
            ExpressionSet = set;
            InsertFields = new FilteredFields(set, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(set, SqlStatementExecutionType.Insert);
            SqlStatementBuilder = builder;
        }
    }
}
