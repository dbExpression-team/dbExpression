using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ConcatFunctionExpression<TValue> : ConcatFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        ISupportedForFunctionExpression<AverageFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CastFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TValue>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, TValue>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, TValue>,
        ISupportedForFunctionExpression<SumFunctionExpression, TValue>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression<TValue>, TValue>,
        ISupportedForSelectFieldExpression<TValue>,
        IEquatable<ConcatFunctionExpression<TValue>>
    {
        #region constructors
        internal ConcatFunctionExpression()
        {
        }

        public ConcatFunctionExpression(IList<(Type, object)> expressions)
            : base(expressions.ToArray())
        {
        }
        #endregion

        #region as
        public new ConcatFunctionExpression<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ConcatFunctionExpression<TValue> obj)
            => base.Equals(obj);

        public override bool Equals(object obj)
         => obj is ConcatFunctionExpression<TValue> exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        //MILESTONE: Function Arithmetic
        //public static implicit operator ExpressionMediator<string>(ConcatFunctionExpression<TValue> concat) => new ExpressionMediator<string>((concat.GetType(), concat));
        public static implicit operator OrderByExpression(ConcatFunctionExpression<TValue> concat) => new OrderByExpression((concat.GetType(), concat), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(ConcatFunctionExpression<TValue> concat) => new GroupByExpression((concat.GetType(), concat));
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<string> operator ==(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(ConcatFunctionExpression<TValue> a, string b) => new FilterExpression<string>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(string a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region string
        public static FilterExpression<string> operator ==(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(ConcatFunctionExpression<TValue> a, ExpressionMediator<string> b) => new FilterExpression<string>(a, b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.Equal);

        public static FilterExpression<string> operator !=(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<string> operator <(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<string> operator <=(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<string> operator >(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<string> operator >=(ExpressionMediator<string> a, ConcatFunctionExpression<TValue> b) => new FilterExpression<string>(a.Expression, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
