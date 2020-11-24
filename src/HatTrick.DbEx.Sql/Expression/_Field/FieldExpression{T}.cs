using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression<TValue> : FieldExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected FieldExpression(string identifier, Type declaredType, EntityExpression entity) : base(identifier, declaredType, entity)
        {

        }

        protected FieldExpression(string identifier, Type declaredType, EntityExpression entity, string alias) : base(identifier, declaredType, entity, alias)
        {

        }
        #endregion

        #region in value set
        public abstract FilterExpressionSet In(params TValue[] value);
        public abstract FilterExpressionSet In(IEnumerable<TValue> value);
        #endregion

        #region set
        public abstract AssignmentExpression Set(TValue value);
        #endregion
    }
}
