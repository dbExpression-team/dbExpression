using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FilterExpressionSet :
        AnyWhereClause,
        AnyJoinOnClause,
        AnyHavingClause
    {
        #region interface
        public ConditionalExpressionOperator ConditionalOperator { get; private set; }
        public bool Negate { get; private set; }
        public IFilterExpressionElement LeftArg { get; private set; }
        public IFilterExpressionElement RightArg { get; private set; }
        public bool IsSingleArg => RightArg is null;
        public bool IsEmpty => LeftArg is null && RightArg is null;
        #endregion

        #region constructors
        private FilterExpressionSet()
        { 
        
        }        
        
        public FilterExpressionSet(FilterExpression singleArg)
        {
            LeftArg = singleArg ?? throw new ArgumentNullException($"{nameof(singleArg)} is required.");
        }

        public FilterExpressionSet(FilterExpression leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        public FilterExpressionSet(FilterExpressionSet leftArg, FilterExpressionSet rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }

        private FilterExpressionSet(FilterExpressionSet leftArg, FilterExpression rightArg, ConditionalExpressionOperator conditionalOperator)
        {
            LeftArg = leftArg ?? throw new ArgumentNullException($"{nameof(leftArg)} is required.");
            RightArg = rightArg ?? throw new ArgumentNullException($"{nameof(rightArg)} is required.");
            ConditionalOperator = conditionalOperator;
        }
        #endregion

        #region to string
        public override string ToString() => (Negate) ? $"NOT ({LeftArg} {ConditionalOperator} {RightArg})" : $"{LeftArg} {ConditionalOperator} {RightArg}";
        #endregion

        #region implicit operators
        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                a.RightArg = b;
                a.ConditionalOperator = ConditionalExpressionOperator.And;
                return a;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator &(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                if (b.IsSingleArg && b.LeftArg is FilterExpression inner_bFilter)
                {
                    inner_bFilter.Negate = b.Negate;
                    a.RightArg = inner_bFilter;
                }
                else
                {
                    a.RightArg = b;
                }
                a.ConditionalOperator = ConditionalExpressionOperator.And;
                return a;
            }

            if (b.IsSingleArg && b.LeftArg is FilterExpression bFilter)
            {
                bFilter.Negate = b.Negate;
                b.Negate = false;
                if (a.IsSingleArg && a.LeftArg is FilterExpression inner_aFilter)
                {
                    inner_aFilter.Negate = a.Negate;
                    b.RightArg = b.LeftArg;
                    b.LeftArg = inner_aFilter;
                }
                else
                {
                    b.RightArg = b.LeftArg;
                    b.LeftArg = a;
                }
                b.ConditionalOperator = ConditionalExpressionOperator.And;
                return b;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.And);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpression b)
        {
            if (a is null && b is object) { return new FilterExpressionSet(b); }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                a.RightArg = b;
                a.ConditionalOperator = ConditionalExpressionOperator.Or;
                return a;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static FilterExpressionSet operator |(FilterExpressionSet a, FilterExpressionSet b)
        {
            if (a is null && b is object) { return b; }
            if (a is object && b is null) { return a; }
            if (a is null && b is null) { return null; }

            if (a.IsSingleArg && a.LeftArg is FilterExpression aFilter)
            {
                aFilter.Negate = a.Negate;
                a.Negate = false;
                if (b.IsSingleArg && b.LeftArg is FilterExpression inner_bFilter)
                {
                    inner_bFilter.Negate = b.Negate;
                    a.RightArg = inner_bFilter;
                }
                else
                {
                    a.RightArg = b;
                }
                a.ConditionalOperator = ConditionalExpressionOperator.Or;
                return a;
            }

            if (b.IsSingleArg && b.LeftArg is FilterExpression bFilter)
            {
                bFilter.Negate = b.Negate;
                b.Negate = false;
                if (a.IsSingleArg && a.LeftArg is FilterExpression inner_aFilter)
                {
                    inner_aFilter.Negate = a.Negate;
                    b.RightArg = b.LeftArg;
                    b.LeftArg = inner_aFilter;
                }
                else
                {
                    b.RightArg = b.LeftArg;
                    b.LeftArg = a;
                }
                b.ConditionalOperator = ConditionalExpressionOperator.Or;
                return b;
            }

            return new FilterExpressionSet(a, b, ConditionalExpressionOperator.Or);
        }

        public static implicit operator JoinOnExpressionSet(FilterExpressionSet filter)
            => filter.ConvertToJoinOnExpressionSet();

        public static implicit operator HavingExpression(FilterExpressionSet a) 
            => new HavingExpression(a);

        public static FilterExpressionSet operator !(FilterExpressionSet filter)
        {
            if (filter is object) filter.Negate = !filter.Negate;
            return filter;
        }
        #endregion
    }
}
