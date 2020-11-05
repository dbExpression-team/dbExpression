using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpressionSet : IExpression
    {
        #region interface
        public IDbEntity Entity { get; }
        public IEnumerable<InsertExpression> Expressions { get; private set; } = new List<InsertExpression>();
        #endregion

        #region constructors
        protected InsertExpressionSet() { }

        public InsertExpressionSet(IDbEntity entity, IEnumerable<InsertExpression> fields)
        {
            Entity = entity ?? throw new ArgumentNullException($"{nameof(entity)} is required.");
            Expressions = fields ?? throw new ArgumentNullException($"{nameof(fields)} is required.");
        }
        #endregion
    }
}
