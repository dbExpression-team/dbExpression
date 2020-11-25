using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertQueryExpression : QueryExpression
    {
        public IDictionary<int, InsertExpressionSet> Inserts { get; set; } = new Dictionary<int, InsertExpressionSet>();
        public IList<FieldExpression> Outputs { get; set; }
    }
}
