using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableFieldExpression<TValue> : FieldExpression<TValue>
        where TValue : struct, IComparable
    {
        #region constructors
        protected NullableFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(identifier, entity, metadata)
        {

        }

        protected NullableFieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(identifier, entity, metadata, alias)
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
