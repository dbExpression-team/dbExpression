using System;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression<TValue> : FieldExpression
    {
        #region constructors
        protected FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : base(entity, metadata)
        {

        }

        protected FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias) : base(entity, metadata, alias)
        {
        }
        #endregion

        #region in value set
        public FilterExpression In(params TValue[] value) => value != null ? new FilterExpression<TValue>(new ExpressionContainer(this), new ExpressionContainer(new LiteralExpression<TValue[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region set
        public AssignmentExpression Set(TValue value) => new AssignmentExpression(new ExpressionContainer(this), new ExpressionContainer(new LiteralExpression<TValue>(value)));
        public AssignmentExpression Set(ExpressionMediator<TValue> value) => new AssignmentExpression(new ExpressionContainer(this), value.Expression);
        #endregion

        #region insert value
        public InsertExpression Insert(TValue value) => new InsertExpression(this, value, typeof(TValue));
        #endregion
    }
}
