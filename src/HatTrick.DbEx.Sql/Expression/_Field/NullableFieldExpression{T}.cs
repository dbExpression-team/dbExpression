using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFieldExpression<TValue> : FieldExpression<TValue>
        where TValue : struct, IComparable
    {
        #region constructors
        protected NullableFieldExpression(string identifier, Type declaredType, EntityExpression entity) : base(identifier, declaredType, entity)
        {

        }

        protected NullableFieldExpression(string identifier, Type declaredType, EntityExpression entity, string alias) : base(identifier, declaredType, entity, alias)
        {

        }
        #endregion

        #region isnull
        public abstract FilterExpression<bool> IsNull();
        public abstract FilterExpression<bool> IsNotNull();
        #endregion

        #region set
        public abstract AssignmentExpression Set(TValue? value);
        public abstract AssignmentExpression Set(NullableExpressionMediator<TValue> value);
        #endregion

        #region insert value
        public abstract InsertExpression Insert(TValue? value);
        #endregion
    }
}
