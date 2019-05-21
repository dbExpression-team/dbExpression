using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression : 
        IDbExpression, 
        IAssemblyPart,
        IDbExpressionAliasProvider,
        ISupportedForSelectExpression,
        ISupportedForFunctionExpression<CastFunctionExpression, byte>,
        ISupportedForFunctionExpression<CastFunctionExpression, short>,
        ISupportedForFunctionExpression<CastFunctionExpression, int>,
        ISupportedForFunctionExpression<CastFunctionExpression, long>,
        ISupportedForFunctionExpression<CastFunctionExpression, decimal>,
        ISupportedForFunctionExpression<CastFunctionExpression, double>,
        ISupportedForFunctionExpression<CastFunctionExpression, float>,
        ISupportedForFunctionExpression<CastFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, byte>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, short>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, int>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, long>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, double>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, float>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, byte>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, short>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, int>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, long>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, decimal>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, double>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, float>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, byte>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, short>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, int>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, long>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, double>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, float>,
        ISupportedForFunctionExpression<MaximumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, byte>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, short>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, int>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, long>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, double>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, float>,
        ISupportedForFunctionExpression<MinimumFunctionExpression, DateTime>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, short>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, long>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, decimal>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, double>,
        ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression, float>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, byte>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, short>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, int>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, long>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, decimal>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, double>,
        ISupportedForFunctionExpression<PopulationVarianceFunctionExpression, float>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, byte>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, short>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, int>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, long>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, decimal>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, double>,
        ISupportedForFunctionExpression<StandardDeviationFunctionExpression, float>,
        ISupportedForFunctionExpression<SumFunctionExpression, byte>,
        ISupportedForFunctionExpression<SumFunctionExpression, short>,
        ISupportedForFunctionExpression<SumFunctionExpression, int>,
        ISupportedForFunctionExpression<SumFunctionExpression, long>,
        ISupportedForFunctionExpression<SumFunctionExpression, decimal>,
        ISupportedForFunctionExpression<SumFunctionExpression, double>,
        ISupportedForFunctionExpression<SumFunctionExpression, float>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, byte>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, short>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, int>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, long>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, decimal>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, double>,
        ISupportedForFunctionExpression<VarianceFunctionExpression, float>
    {
        #region internals
        protected string Alias { get; private set; }
        #endregion

        #region interface
        public (Type, object) Expression { get; private set; }
        public (Type, object) LeftPart => ((DbExpressionPair)Expression.Item2).LeftPart;
        public (Type, object) RightPart => ((DbExpressionPair)Expression.Item2).RightPart;
        public ArithmeticExpressionOperator ExpressionOperator { get; private set; }

        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected ArithmeticExpression((Type, object) expression, ArithmeticExpressionOperator arithmeticOperator, string alias)
        {
            Expression = expression;
            ExpressionOperator = arithmeticOperator;
            Alias = alias;
        }

        protected ArithmeticExpression(object leftArg, object rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(ArithmeticExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(ArithmeticExpression leftArg, ArithmeticExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(ArithmeticExpression), leftArg), (typeof(ArithmeticExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, ArithmeticExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (typeof(ArithmeticExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(FieldExpression leftArg, FieldExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(FieldExpression), leftArg), (typeof(FieldExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(CastFunctionExpression leftArg, CastFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(CastFunctionExpression), leftArg), (typeof(CastFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(CoalesceFunctionExpression leftArg, CoalesceFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(CoalesceFunctionExpression), leftArg), (typeof(CoalesceFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        internal ArithmeticExpression(IsNullFunctionExpression leftArg, IsNullFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((typeof(IsNullFunctionExpression), leftArg), (typeof(IsNullFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression(IDbNumericFunctionExpression leftArg, IComparable rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression(IDbNumericFunctionExpression leftArg, IDbNumericFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (typeof(IsNullFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression(IDbDateFunctionExpression leftArg, IDbDateFunctionExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (typeof(IsNullFunctionExpression), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression(IDbDateFunctionExpression leftArg, FieldExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Item2} {ExpressionOperator} {RightPart.Item2})";
        #endregion

        #region as
        public ArithmeticExpression As(string alias) => new ArithmeticExpression(Expression, ExpressionOperator, alias);
        #endregion

        #region implicit select expression operator
        //public static implicit operator SelectExpression(ArithmeticExpression a) => new SelectExpression(a);
        #endregion

        #region implicit group by expression operator
        public static implicit operator GroupByExpression(ArithmeticExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic expression to value operators arithmetic operators

        public static ArithmeticExpression operator +(ArithmeticExpression a, string b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator +(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

         public static ArithmeticExpression operator +(ArithmeticExpression a, DateTime b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator -(ArithmeticExpression a, DateTime b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator *(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator /(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        public static ArithmeticExpression operator %(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region arithmetic expression to expression relational operators
        public static FilterExpression operator ==(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression a, IDbExpression b)  => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic to value relational operators
        public static FilterExpression operator ==(ArithmeticExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator ==(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(ArithmeticExpression a, string b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator !=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator <=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(ArithmeticExpression a, decimal b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, double b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, int b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator >=(ArithmeticExpression a, long b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region arithmetic expression to arithmetic expression operators
        //public static ArithmeticExpression operator +(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
    
}
