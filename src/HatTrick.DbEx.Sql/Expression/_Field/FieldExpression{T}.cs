using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression<TValue> : FieldExpression,
        IExpressionElement<TValue>
    {
        #region constructors
        protected FieldExpression(string identifier, string name, Type declaredType, EntityExpression entity) : base(identifier, name, declaredType, entity)
        {

        }
        #endregion

        #region in value set
        public abstract FilterExpressionSet In(params TValue[] value);
        public abstract FilterExpressionSet In(IEnumerable<TValue> value);
        #endregion
    }
}
