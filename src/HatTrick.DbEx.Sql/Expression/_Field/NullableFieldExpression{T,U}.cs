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
        public abstract FilterExpression<bool> In(params TValue[] value);
        public abstract FilterExpression<bool> In(IEnumerable<TValue> value);
        public abstract FilterExpression<bool> In(params TNullableValue[] value);
        public abstract FilterExpression<bool> In(IEnumerable<TNullableValue> value);
        #endregion

        #region set
        public abstract AssignmentExpression Set(TValue value);

        public abstract AssignmentExpression Set(TNullableValue value);
        public abstract AssignmentExpression Set(DBNull value);
        #endregion

        #region insert value
        public abstract InsertExpression Insert(TValue value);
        public abstract InsertExpression Insert(TNullableValue value);
        #endregion
    }
}
