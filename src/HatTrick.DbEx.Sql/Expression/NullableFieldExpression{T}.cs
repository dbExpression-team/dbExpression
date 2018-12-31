using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class NullableFieldExpression<T> : FieldExpression<T>
            where T : struct, IComparable
    {
        #region constructors
        public NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata) : base(entity, metadata)
        {
        }

        private NullableFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, string alias) : base(entity, metadata, alias)
        {
        }
        #endregion

        public new NullableFieldExpression<T> As(string alias) => new NullableFieldExpression<T>(base.Entity, base.Metadata, alias);

        #region set value
        public AssignmentExpression Set(T? value) => new AssignmentExpression(this, value);
        #endregion

        #region insert value
        public InsertExpression Insert(T? value) => new InsertExpression(this, value, typeof(T));
        #endregion

        #region field to value relational operators
        public static FilterExpression operator ==(NullableFieldExpression<T> field, T? value) => new FilterExpression(field, value, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableFieldExpression<T> field, T? value) => new FilterExpression(field, value, FilterExpressionOperator.NotEqual);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
}
