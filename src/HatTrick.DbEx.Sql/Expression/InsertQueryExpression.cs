using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertQueryExpression : QueryExpression
    {
        public IDictionary<int, InsertExpressionSet> Inserts { get; set; } = new Dictionary<int, InsertExpressionSet>();
        public IList<FieldExpression> Outputs { get; set; }

        #region to string
        public override string ToString()
        {
            var sb = new StringBuilder("INSERT ");
            sb.Append(" ");
            sb.Append(Inserts);
            sb.Append(" INTO ");
            sb.Append(BaseEntity);
            sb.Append(" ");

            return sb.ToString();
        }
        #endregion
    }
}
