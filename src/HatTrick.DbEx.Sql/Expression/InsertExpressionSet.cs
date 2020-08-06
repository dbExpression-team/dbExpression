using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpressionSet : IDbExpression
    {
        #region interface
        public IDbEntity Entity { get; }
        public IList<InsertExpression> Expressions { get; } = new List<InsertExpression>();
        #endregion

        #region constructors
        protected InsertExpressionSet() { }

        public InsertExpressionSet(IDbEntity entity, IList<InsertExpression> fields)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(entity)} is required.");
            Entity = entity;
            Expressions = fields?.ToList() ?? throw new ArgumentNullException($"{nameof(fields)} is required.");
        }
        #endregion
    }
}
