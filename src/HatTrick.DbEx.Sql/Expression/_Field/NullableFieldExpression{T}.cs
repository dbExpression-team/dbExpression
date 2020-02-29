using System;
using System.Linq.Expressions;
using System.Reflection;

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

        public FilterExpression<TValue?> IsNull() => new FilterExpression<TValue?>(new ExpressionContainer(this), new ExpressionContainer(DBNull.Value), FilterExpressionOperator.Equal);
        public FilterExpression<TValue> IsNotNull() => new FilterExpression<TValue>(new ExpressionContainer(this), new ExpressionContainer(DBNull.Value), FilterExpressionOperator.NotEqual);

        #region set
        public AssignmentExpression Set(TValue? value) => new AssignmentExpression(new ExpressionContainer(this), new ExpressionContainer(new LiteralExpression<TValue?>(value)));
        public AssignmentExpression Set(NullableExpressionMediator<TValue?> value) => new AssignmentExpression(new ExpressionContainer(this), value.Expression);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue? value) => new InsertExpression(this, value, typeof(TValue?));
        #endregion
    }
}
