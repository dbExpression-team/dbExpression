using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFieldExpression<TValue,TNullableValue> : FieldExpression,
        IExpressionElement<TValue,TNullableValue>
    {
        #region constructors
        protected NullableFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(TNullableValue), entity)
        {

        }
        #endregion

        #region in value set
        public abstract FilterExpressionSet In(params TValue[] value);
        public abstract FilterExpressionSet In(IEnumerable<TValue> value);
        public abstract FilterExpressionSet In(params TNullableValue[] value);
        public abstract FilterExpressionSet In(IEnumerable<TNullableValue> value);
        #endregion
    }
}
