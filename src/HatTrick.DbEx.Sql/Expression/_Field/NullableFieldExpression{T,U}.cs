using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFieldExpression<TValue,TNullableValue> : FieldExpression,
        IExpressionElement<TValue,TNullableValue>
    {
        #region constructors
        protected NullableFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(TNullableValue), entity)
        {

        }

        protected NullableFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(TNullableValue), entity, alias)
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
