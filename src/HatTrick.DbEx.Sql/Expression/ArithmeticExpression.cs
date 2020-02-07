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
        protected ArithmeticExpression(IDbExpression leftArg, (Type, object) rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), rightArg));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression(IDbExpression leftArg, IDbExpression rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair((leftArg.GetType(), leftArg), (rightArg.GetType(), rightArg)));
            ExpressionOperator = arithmeticOperator;
        }

        protected ArithmeticExpression((Type,object) leftArg, (Type,object) rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair(leftArg, rightArg));
            ExpressionOperator = arithmeticOperator;
        }

        public ArithmeticExpression((Type, object) leftArg, IDbExpression righArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            Expression = (typeof(DbExpressionPair), new DbExpressionPair(leftArg, (righArg.GetType(), righArg)));
            ExpressionOperator = arithmeticOperator;
        }

        private ArithmeticExpression((Type, object) inner, ArithmeticExpressionOperator arithmeticOperator, string alias)
        {
            Expression = inner;
            ExpressionOperator = arithmeticOperator;
            Alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => $"({LeftPart.Item2} {ExpressionOperator} {RightPart.Item2})";
        #endregion

        #region as
        public ArithmeticExpression As(string alias) => new ArithmeticExpression(Expression, ExpressionOperator, alias);
        #endregion

        #region implicit expression operator
        public static implicit operator OrderByExpression(ArithmeticExpression average) => new OrderByExpression((average.GetType(), average), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(ArithmeticExpression average) => new GroupByExpression((average.GetType(), average));
        #endregion

        //#region arithmetic expression to value operators arithmetic operators

        //public static ArithmeticExpression operator +(ArithmeticExpression a, string b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator +(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator +(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator +(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator +(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        // public static ArithmeticExpression operator +(ArithmeticExpression a, DateTime b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, DateTime b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator *(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        //public static ArithmeticExpression operator *(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        //public static ArithmeticExpression operator *(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        //public static ArithmeticExpression operator *(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        //public static ArithmeticExpression operator /(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        //public static ArithmeticExpression operator /(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        //public static ArithmeticExpression operator /(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        //public static ArithmeticExpression operator /(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        //public static ArithmeticExpression operator %(ArithmeticExpression a, decimal b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        //public static ArithmeticExpression operator %(ArithmeticExpression a, double b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        //public static ArithmeticExpression operator %(ArithmeticExpression a, int b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);

        //public static ArithmeticExpression operator %(ArithmeticExpression a, long b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        //#endregion

        //#region arithmetic expression to expression relational operators
        //public static FilterExpression operator ==(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator !=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator <(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression operator <=(ArithmeticExpression a, IDbExpression b)  => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression operator >(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression operator >=(ArithmeticExpression a, IDbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        //#endregion

        //#region arithmetic to value relational operators
        //public static FilterExpression operator ==(ArithmeticExpression a, string b) => new FilterExpression<string>(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator ==(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator ==(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator ==(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator ==(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.Equal);

        //public static FilterExpression operator !=(ArithmeticExpression a, string b) => new FilterExpression<string>(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator !=(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator !=(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator !=(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator !=(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.NotEqual);

        //public static FilterExpression operator <(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression operator <(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression operator <(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression operator <(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.LessThan);

        //public static FilterExpression operator <=(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression operator <=(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression operator <=(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression operator <=(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.LessThanOrEqual);

        //public static FilterExpression operator >(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression operator >(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression operator >(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression operator >(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.GreaterThan);

        //public static FilterExpression operator >=(ArithmeticExpression a, decimal b) => new FilterExpression<decimal>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression operator >=(ArithmeticExpression a, double b) => new FilterExpression<double>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression operator >=(ArithmeticExpression a, int b) => new FilterExpression<int>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        //public static FilterExpression operator >=(ArithmeticExpression a, long b) => new FilterExpression<long>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        //#endregion

        //#region arithmetic expression to arithmetic expression operators
        ////public static ArithmeticExpression operator +(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        //public static ArithmeticExpression operator -(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        //public static ArithmeticExpression operator *(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        //public static ArithmeticExpression operator /(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        //public static ArithmeticExpression operator %(ArithmeticExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        //#endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }
    
}
