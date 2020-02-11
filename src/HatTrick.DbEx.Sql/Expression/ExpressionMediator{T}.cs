using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class ExpressionMediator : IDbExpression, IDbExpressionAliasProvider
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; set; }
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator((Type, object) function)
        {
            Expression = function;
        }
        #endregion

        #region as
        public ExpressionMediator As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion
    }

    public class ExpressionMediator<TValue> : ExpressionMediator, ISupportedForSelectFieldExpression<TValue>
    {
        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator((Type,object) expression) : base(expression)
        {
        }
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(ExpressionMediator<TValue> mediator) => new OrderByExpression(mediator.Expression, OrderExpressionDirection.ASC);
        #endregion        

        #region as
        public new ExpressionMediator<TValue> As(string alias)
        {
            base.As(alias);
            return this;
        }
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static ExpressionMediator<byte> operator +(ExpressionMediator<TValue> a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ExpressionMediator<TValue> a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ExpressionMediator<TValue> a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ExpressionMediator<TValue> a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ExpressionMediator<TValue> a, byte b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(byte a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(byte a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(byte a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(byte a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(byte a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(ExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(ExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(ExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(ExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(ExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(byte? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(byte? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(byte? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(byte? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(byte? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static ExpressionMediator<DateTime> operator +(ExpressionMediator<TValue> a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(ExpressionMediator<TValue> a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(ExpressionMediator<TValue> a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(ExpressionMediator<TValue> a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(ExpressionMediator<TValue> a, DateTime b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTime a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTime a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTime a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTime a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTime a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(ExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(ExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(ExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(ExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(ExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(ExpressionMediator<TValue> a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(ExpressionMediator<TValue> a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(ExpressionMediator<TValue> a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(ExpressionMediator<TValue> a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(ExpressionMediator<TValue> a, DateTimeOffset b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffset a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffset a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffset a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffset a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffset a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(ExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(ExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(ExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(ExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(ExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static ExpressionMediator<decimal> operator +(ExpressionMediator<TValue> a, decimal b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(ExpressionMediator<TValue> a, decimal b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(ExpressionMediator<TValue> a, decimal b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(ExpressionMediator<TValue> a, decimal b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(ExpressionMediator<TValue> a, decimal b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<decimal> operator +(decimal a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(decimal a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(decimal a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(decimal a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(decimal a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(ExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(ExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(ExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(ExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(ExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(decimal? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(decimal? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(decimal? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(decimal? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(decimal? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static ExpressionMediator<double> operator +(ExpressionMediator<TValue> a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(ExpressionMediator<TValue> a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(ExpressionMediator<TValue> a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(ExpressionMediator<TValue> a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(ExpressionMediator<TValue> a, double b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(double a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(double a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(double a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(double a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(double a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(ExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(ExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(ExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(ExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(ExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(double? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(double? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(double? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(double? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(double? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static ExpressionMediator<float> operator +(ExpressionMediator<TValue> a, float b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(ExpressionMediator<TValue> a, float b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(ExpressionMediator<TValue> a, float b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(ExpressionMediator<TValue> a, float b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(ExpressionMediator<TValue> a, float b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<float> operator +(float a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(float a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(float a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(float a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(float a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(ExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(ExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(ExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(ExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(ExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(float? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(float? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(float? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(float? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(float? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid
        public static ExpressionMediator<Guid> operator +(ExpressionMediator<TValue> a, Guid b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<Guid> operator -(ExpressionMediator<TValue> a, Guid b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<Guid> operator *(ExpressionMediator<TValue> a, Guid b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<Guid> operator /(ExpressionMediator<TValue> a, Guid b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<Guid> operator %(ExpressionMediator<TValue> a, Guid b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<Guid> operator +(Guid a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<Guid> operator -(Guid a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<Guid> operator *(Guid a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<Guid> operator /(Guid a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<Guid> operator %(Guid a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(ExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(ExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(ExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(ExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(ExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(Guid? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(Guid? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(Guid? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(Guid? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(Guid? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region int
        public static ExpressionMediator<int> operator +(ExpressionMediator<TValue> a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(ExpressionMediator<TValue> a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(ExpressionMediator<TValue> a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(ExpressionMediator<TValue> a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(ExpressionMediator<TValue> a, int b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(int a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(int a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(int a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(int a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(int a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(ExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(ExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(ExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(ExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(ExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(int? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(int? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(int? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(int? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(int? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static ExpressionMediator<long> operator +(ExpressionMediator<TValue> a, long b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(ExpressionMediator<TValue> a, long b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(ExpressionMediator<TValue> a, long b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(ExpressionMediator<TValue> a, long b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(ExpressionMediator<TValue> a, long b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<long> operator +(long a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(long a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(long a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(long a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(long a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(ExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(ExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(ExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(ExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(ExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(long? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(long? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(long? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(long? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(long? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region short
        public static ExpressionMediator<short> operator +(ExpressionMediator<TValue> a, short b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(ExpressionMediator<TValue> a, short b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(ExpressionMediator<TValue> a, short b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(ExpressionMediator<TValue> a, short b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(ExpressionMediator<TValue> a, short b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<short> operator +(short a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(short a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(short a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(short a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(short a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(ExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(ExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(ExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(ExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(ExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(short? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(short? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(short? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(short? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(short? a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region string
        public static ExpressionMediator<string> operator +(ExpressionMediator<TValue> a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator -(ExpressionMediator<TValue> a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<string> operator *(ExpressionMediator<TValue> a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<string> operator /(ExpressionMediator<TValue> a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<string> operator %(ExpressionMediator<TValue> a, string b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<string> operator +(string a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator -(string a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<string> operator *(string a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<string> operator /(string a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<string> operator %(string a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region field
        #region byte
        public static ExpressionMediator<byte> operator +(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(ByteFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ByteFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ByteFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ByteFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ByteFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static ExpressionMediator<DateTime> operator +(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(DateTimeFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(DateTimeFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(DateTimeFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(DateTimeFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(DateTimeFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(DateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(DateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(DateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(DateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(DateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static ExpressionMediator<decimal> operator +(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<decimal> operator +(DecimalFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(DecimalFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(DecimalFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(DecimalFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(DecimalFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static ExpressionMediator<double> operator +(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(DoubleFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(DoubleFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(DoubleFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(DoubleFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(DoubleFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableDoubleFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableDoubleFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableDoubleFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableDoubleFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableDoubleFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static ExpressionMediator<float> operator +(ExpressionMediator<TValue> a, FloatFieldExpression b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(ExpressionMediator<TValue> a, FloatFieldExpression b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(ExpressionMediator<TValue> a, FloatFieldExpression b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(ExpressionMediator<TValue> a, FloatFieldExpression b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(ExpressionMediator<TValue> a, FloatFieldExpression b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<float> operator +(FloatFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(FloatFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(FloatFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(FloatFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(FloatFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(ExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(ExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(ExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(ExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(ExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static ExpressionMediator<int> operator +(ExpressionMediator<TValue> a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(ExpressionMediator<TValue> a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(ExpressionMediator<TValue> a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(ExpressionMediator<TValue> a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(ExpressionMediator<TValue> a, Int32FieldExpression b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(Int32FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(Int32FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(Int32FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(Int32FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(Int32FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static ExpressionMediator<long> operator +(ExpressionMediator<TValue> a, Int64FieldExpression b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(ExpressionMediator<TValue> a, Int64FieldExpression b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(ExpressionMediator<TValue> a, Int64FieldExpression b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(ExpressionMediator<TValue> a, Int64FieldExpression b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(ExpressionMediator<TValue> a, Int64FieldExpression b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<long> operator +(Int64FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(Int64FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(Int64FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(Int64FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(Int64FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region short
        public static ExpressionMediator<short> operator +(ExpressionMediator<TValue> a, Int16FieldExpression b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(ExpressionMediator<TValue> a, Int16FieldExpression b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(ExpressionMediator<TValue> a, Int16FieldExpression b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(ExpressionMediator<TValue> a, Int16FieldExpression b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(ExpressionMediator<TValue> a, Int16FieldExpression b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<short> operator +(Int16FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(Int16FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(Int16FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(Int16FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(Int16FieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region string
        public static ExpressionMediator<string> operator +(ExpressionMediator<TValue> a, StringFieldExpression b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator +(StringFieldExpression a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a, b.Expression, ArithmeticExpressionOperator.Add)));
        #endregion
        #endregion
        #endregion

        #region mediator
        #region byte
        public static ExpressionMediator<byte> operator +(ExpressionMediator<TValue> a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ExpressionMediator<TValue> a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ExpressionMediator<TValue> a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ExpressionMediator<TValue> a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ExpressionMediator<TValue> a, ExpressionMediator<byte> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<byte> operator +(ExpressionMediator<byte> a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<byte> operator -(ExpressionMediator<byte> a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<byte> operator *(ExpressionMediator<byte> a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<byte> operator /(ExpressionMediator<byte> a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<byte> operator %(ExpressionMediator<byte> a, ExpressionMediator<TValue> b) => new ExpressionMediator<byte>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<byte?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<byte?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<byte?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<byte?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<byte?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Datetime
        public static ExpressionMediator<DateTime> operator +(ExpressionMediator<TValue> a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(ExpressionMediator<TValue> a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(ExpressionMediator<TValue> a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(ExpressionMediator<TValue> a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(ExpressionMediator<TValue> a, ExpressionMediator<DateTime> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTime> operator +(ExpressionMediator<DateTime> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTime> operator -(ExpressionMediator<DateTime> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTime> operator *(ExpressionMediator<DateTime> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTime> operator /(ExpressionMediator<DateTime> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTime> operator %(ExpressionMediator<DateTime> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTime>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<DateTime?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<DateTime?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<DateTime?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<DateTime?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<DateTime?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static ExpressionMediator<DateTimeOffset> operator +(ExpressionMediator<TValue> a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(ExpressionMediator<TValue> a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(ExpressionMediator<TValue> a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(ExpressionMediator<TValue> a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(ExpressionMediator<TValue> a, ExpressionMediator<DateTimeOffset> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<DateTimeOffset> operator +(ExpressionMediator<DateTimeOffset> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<DateTimeOffset> operator -(ExpressionMediator<DateTimeOffset> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<DateTimeOffset> operator *(ExpressionMediator<DateTimeOffset> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<DateTimeOffset> operator /(ExpressionMediator<DateTimeOffset> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<DateTimeOffset> operator %(ExpressionMediator<DateTimeOffset> a, ExpressionMediator<TValue> b) => new ExpressionMediator<DateTimeOffset>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<DateTimeOffset?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<DateTimeOffset?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<DateTimeOffset?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<DateTimeOffset?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<DateTimeOffset?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static ExpressionMediator<decimal> operator +(ExpressionMediator<TValue> a, ExpressionMediator<decimal> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(ExpressionMediator<TValue> a, ExpressionMediator<decimal> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(ExpressionMediator<TValue> a, ExpressionMediator<decimal> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(ExpressionMediator<TValue> a, ExpressionMediator<decimal> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(ExpressionMediator<TValue> a, ExpressionMediator<decimal> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<decimal> operator +(ExpressionMediator<decimal> a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<decimal> operator -(ExpressionMediator<decimal> a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<decimal> operator *(ExpressionMediator<decimal> a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<decimal> operator /(ExpressionMediator<decimal> a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<decimal> operator %(ExpressionMediator<decimal> a, ExpressionMediator<TValue> b) => new ExpressionMediator<decimal>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<decimal?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<decimal?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<decimal?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<decimal?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<decimal?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static ExpressionMediator<double> operator +(ExpressionMediator<TValue> a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(ExpressionMediator<TValue> a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(ExpressionMediator<TValue> a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(ExpressionMediator<TValue> a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(ExpressionMediator<TValue> a, ExpressionMediator<double> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<double> operator +(ExpressionMediator<double> a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<double> operator -(ExpressionMediator<double> a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<double> operator *(ExpressionMediator<double> a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<double> operator /(ExpressionMediator<double> a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<double> operator %(ExpressionMediator<double> a, ExpressionMediator<TValue> b) => new ExpressionMediator<double>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<double?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<double?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<double?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<double?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<double?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static ExpressionMediator<float> operator +(ExpressionMediator<TValue> a, ExpressionMediator<float> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(ExpressionMediator<TValue> a, ExpressionMediator<float> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(ExpressionMediator<TValue> a, ExpressionMediator<float> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(ExpressionMediator<TValue> a, ExpressionMediator<float> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(ExpressionMediator<TValue> a, ExpressionMediator<float> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<float> operator +(ExpressionMediator<float> a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<float> operator -(ExpressionMediator<float> a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<float> operator *(ExpressionMediator<float> a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<float> operator /(ExpressionMediator<float> a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<float> operator %(ExpressionMediator<float> a, ExpressionMediator<TValue> b) => new ExpressionMediator<float>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<float?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<float?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<float?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<float?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<float?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid
        public static ExpressionMediator<Guid> operator +(ExpressionMediator<TValue> a, ExpressionMediator<Guid> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<Guid> operator -(ExpressionMediator<TValue> a, ExpressionMediator<Guid> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<Guid> operator *(ExpressionMediator<TValue> a, ExpressionMediator<Guid> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<Guid> operator /(ExpressionMediator<TValue> a, ExpressionMediator<Guid> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<Guid> operator %(ExpressionMediator<TValue> a, ExpressionMediator<Guid> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<Guid> operator +(ExpressionMediator<Guid> a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<Guid> operator -(ExpressionMediator<Guid> a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<Guid> operator *(ExpressionMediator<Guid> a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<Guid> operator /(ExpressionMediator<Guid> a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<Guid> operator %(ExpressionMediator<Guid> a, ExpressionMediator<TValue> b) => new ExpressionMediator<Guid>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<Guid?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<Guid?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<Guid?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<Guid?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<Guid?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static ExpressionMediator<int> operator +(ExpressionMediator<TValue> a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(ExpressionMediator<TValue> a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(ExpressionMediator<TValue> a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(ExpressionMediator<TValue> a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(ExpressionMediator<TValue> a, ExpressionMediator<int> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<int> operator +(ExpressionMediator<int> a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<int> operator -(ExpressionMediator<int> a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<int> operator *(ExpressionMediator<int> a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<int> operator /(ExpressionMediator<int> a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<int> operator %(ExpressionMediator<int> a, ExpressionMediator<TValue> b) => new ExpressionMediator<int>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<int?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<int?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<int?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<int?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<int?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static ExpressionMediator<long> operator +(ExpressionMediator<TValue> a, ExpressionMediator<long> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(ExpressionMediator<TValue> a, ExpressionMediator<long> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(ExpressionMediator<TValue> a, ExpressionMediator<long> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(ExpressionMediator<TValue> a, ExpressionMediator<long> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(ExpressionMediator<TValue> a, ExpressionMediator<long> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<long> operator +(ExpressionMediator<long> a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<long> operator -(ExpressionMediator<long> a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<long> operator *(ExpressionMediator<long> a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<long> operator /(ExpressionMediator<long> a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<long> operator %(ExpressionMediator<long> a, ExpressionMediator<TValue> b) => new ExpressionMediator<long>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<long?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<long?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<long?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<long?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<long?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region short
        public static ExpressionMediator<short> operator +(ExpressionMediator<TValue> a, ExpressionMediator<short> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(ExpressionMediator<TValue> a, ExpressionMediator<short> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(ExpressionMediator<TValue> a, ExpressionMediator<short> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(ExpressionMediator<TValue> a, ExpressionMediator<short> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(ExpressionMediator<TValue> a, ExpressionMediator<short> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<short> operator +(ExpressionMediator<short> a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<short> operator -(ExpressionMediator<short> a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<short> operator *(ExpressionMediator<short> a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<short> operator /(ExpressionMediator<short> a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<short> operator %(ExpressionMediator<short> a, ExpressionMediator<TValue> b) => new ExpressionMediator<short>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(ExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(ExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(ExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(ExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(ExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<short?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<short?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<short?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<short?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<short?> a, ExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region string
        public static ExpressionMediator<string> operator +(ExpressionMediator<TValue> a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator -(ExpressionMediator<TValue> a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<string> operator *(ExpressionMediator<TValue> a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<string> operator /(ExpressionMediator<TValue> a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<string> operator %(ExpressionMediator<TValue> a, ExpressionMediator<string> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static ExpressionMediator<string> operator +(ExpressionMediator<string> a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static ExpressionMediator<string> operator -(ExpressionMediator<string> a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static ExpressionMediator<string> operator *(ExpressionMediator<string> a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static ExpressionMediator<string> operator /(ExpressionMediator<string> a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static ExpressionMediator<string> operator %(ExpressionMediator<string> a, ExpressionMediator<TValue> b) => new ExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        public static FilterExpression<TValue> operator ==(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<TValue> operator !=(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.NotEqual);

        public static FilterExpression<TValue> operator <(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThan);

        public static FilterExpression<TValue> operator <=(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TValue> operator >(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TValue> operator >=(ExpressionMediator<TValue> a, TValue b) => new FilterExpression<TValue>(a, new LiteralExpression<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<TValue> operator ==(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<TValue> operator !=(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<TValue> operator <(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<TValue> operator <=(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<TValue> operator >(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<TValue> operator >=(TValue a, ExpressionMediator<TValue> b) => new FilterExpression<TValue>(new LiteralExpression<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
