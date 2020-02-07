using System;
using System.Linq.Expressions;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class NullableByteFieldExpression : NullableFieldExpression<byte>,
        ISupportedForSelectFieldExpression<byte?>,
        ISupportedForFunctionExpression<CastFunctionExpression, byte?>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte?>,
        ISupportedForFunctionExpression<NullableCastFunctionExpression, byte?>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, byte?>,
        ISupportedForFunctionExpression<CountFunctionExpression, byte?>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, byte?>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, byte?>,
        ISupportedForFunctionExpression<AverageFunctionExpression, byte?>,
        ISupportedForFunctionExpression<SumFunctionExpression, byte?>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte?>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte?>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, byte?>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte?>
    {
        protected NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Expression<Func<IDbEntity, byte?>> mapExpression) : base(entity, metadata, mapExpression)
        {
        }

        protected NullableByteFieldExpression(EntityExpression entity, ISqlFieldMetadata metadata, Lazy<Action<IDbEntity, byte?>> mapExpression, string alias) : base(entity, metadata, mapExpression, alias)
        {

        }

        #region arithmetic operators
        #region byte
        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(byte? a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(byte? a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(byte? a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(byte? a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(byte? a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(byte a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(byte a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(byte a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(byte a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(byte a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region mediator
        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression field, DBNull value) => new FilterExpression<byte?>(field, value, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression field, DBNull value) => new FilterExpression<byte?>(field, value, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator ==(DBNull value, NullableByteFieldExpression field) => new FilterExpression<byte?>(value, field, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(DBNull value, NullableByteFieldExpression field) => new FilterExpression<byte?>(value, field, FilterExpressionOperator.NotEqual);
        #endregion

        #region byte
        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression field, byte? value) => new FilterExpression<byte?>(field, new LiteralExpression<byte?>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(byte? value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte?>(value), field, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression field, byte value) => new FilterExpression<byte?>(field, new LiteralExpression<byte>(value), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(byte value, NullableByteFieldExpression field) => new FilterExpression<byte?>(new LiteralExpression<byte>(value), field, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field
        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression a, ByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(ByteFieldExpression a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediator
        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression a, ExpressionMediator<byte?> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(ExpressionMediator<byte?> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(NullableByteFieldExpression a, ExpressionMediator<byte> b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<byte?> operator ==(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<byte?> operator !=(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<byte?> operator <(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<byte?> operator <=(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<byte?> operator >(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<byte?> operator >=(ExpressionMediator<byte> a, NullableByteFieldExpression b) => new FilterExpression<byte?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
