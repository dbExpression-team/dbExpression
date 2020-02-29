using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class FilteredFields
    {
        private SqlStatementExecutionType ExecutionType { get; set; }
        private ExpressionSet ExpressionSet { get; set; }

        public IEnumerable<ISqlFieldMetadata> Metadata => Fields.Select(e => (e as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata).ToList();
        public IEnumerable<FieldExpression> Fields
        {
            get
            {
                switch (ExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        return ExpressionSet.Insert.Expressions.Select(e => e.Expression.LeftPart.Object as FieldExpression).ToList().AsReadOnly();
                    case SqlStatementExecutionType.Update:
                        return ExpressionSet.Assign.Expressions.Select(e => e.Expression.LeftPart.Object as FieldExpression).ToList().AsReadOnly();
                    default:
                        throw new NotImplementedException($"'{ExecutionType}' has not been implemented.");
                }
            }
        }

        public FilteredFields(ExpressionSet expressionSet, SqlStatementExecutionType executionType)
        {
            ExpressionSet = expressionSet;
            ExecutionType = executionType;
        }
    }
}
