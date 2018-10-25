using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityExpressionOverride
    {
        public OverrideScope CurrentScope { get; set; }
        public IDictionary<EntityExpression, string> Aliases { get; set; } = new Dictionary<EntityExpression, string>();
        public string Alias { get; set; }
    }
}
