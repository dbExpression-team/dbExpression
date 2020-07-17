using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class FieldPair
    {
        public FieldExpression Field { get; private set; }
        public ISqlFieldMetadata Metadata { get; private set; }

        public FieldPair(FieldExpression field, ISqlFieldMetadata metadata)
        {
            Field = field;
            Metadata = metadata;
        }
    }

    public class AllFields
    {
        private IList<FieldPair> _fields;

        private SqlStatementExecutionType ExecutionType { get; set; }
        private ExpressionSet ExpressionSet { get; set; }

        public IEnumerable<FieldPair> Fields
        {
            get
            {
                if (_fields is object)
                    return _fields;

                switch (ExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                    case SqlStatementExecutionType.Update:
                        _fields = (ExpressionSet.BaseEntity as IDbExpressionListProvider<FieldExpression>).Expressions
                            .Select(x => new FieldPair(x, (x as IDbExpressionMetadataProvider<ISqlFieldMetadata>).Metadata))
                            .ToList();
                        break;
                    default:
                        throw new NotImplementedException($"'{ExecutionType}' has not been implemented.");
                }

                return _fields;
            }
        }

        public AllFields(ExpressionSet expressionSet, SqlStatementExecutionType executionType)
        {
            ExpressionSet = expressionSet;
            ExecutionType = executionType;
        }
    }
}
