using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class ByteFieldExpression : FieldExpression<byte>,
        ISupportedForSelectFieldExpression<byte>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte>,
        ISupportedForFunctionExpression<CastFunctionExpression, byte>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, byte>,
        ISupportedForFunctionExpression<CountFunctionExpression, byte>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, byte>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, byte>,
        ISupportedForFunctionExpression<AverageFunctionExpression, byte>,
        ISupportedForFunctionExpression<SumFunctionExpression, byte>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte>
    {
        protected ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected ByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region byte
        public static ExpressionMediator<byte> operator +(ByteFieldExpression a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ByteFieldExpression a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ByteFieldExpression a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ByteFieldExpression a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ByteFieldExpression a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(byte a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(byte a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(byte a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(byte a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(byte a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(ByteFieldExpression a, byte? b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ByteFieldExpression a, byte? b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ByteFieldExpression a, byte? b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ByteFieldExpression a, byte? b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ByteFieldExpression a, byte? b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(byte? a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(byte? a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(byte? a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(byte? a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(byte? a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region mediator
        public static ExpressionMediator<byte> operator +(ByteFieldExpression a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ByteFieldExpression a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ByteFieldExpression a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ByteFieldExpression a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ByteFieldExpression a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(ByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(ByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(ByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(ByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(ByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region byte
        public static FilterExpression<byte> operator ==(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ByteFieldExpression field, byte? value) => new FilterExpression<byte>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(byte? value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ByteFieldExpression field, byte value) => new FilterExpression<byte>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(byte value, ByteFieldExpression field) => new FilterExpression<byte>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<byte?> operator ==(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(ByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<byte> operator ==(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ExpressionMediator<byte> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte> operator ==(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte> operator !=(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte> operator <(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte> operator <=(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte> operator >(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte> operator >=(ExpressionMediator<byte?> a, ByteFieldExpression b) => new FilterExpression<byte>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
