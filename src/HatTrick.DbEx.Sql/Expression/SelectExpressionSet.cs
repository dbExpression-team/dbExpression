using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpressionSet : 
        IDbExpression,
        IDbExpressionIsDistinctProvider,
        IDbExpressionIsTopProvider
    {
        #region internals
        protected bool _isDistinct;
        protected int? _top;
        #endregion

        #region interface
        public IList<SelectExpression> Expressions { get; } = new List<SelectExpression>();
        bool IDbExpressionIsDistinctProvider.IsDistinct => _isDistinct;
        int? IDbExpressionIsTopProvider.Top => _top;
        #endregion

        #region constructor
        internal SelectExpressionSet()
        {

        }

        public SelectExpressionSet(params SelectExpression[] expressions)
        {
            Expressions = expressions.ToList();
        }

        public SelectExpressionSet(SelectExpression selectExpression)
        {
            Expressions.Add(selectExpression ?? throw new ArgumentNullException($"{nameof(selectExpression)} is required"));
        }

        public SelectExpressionSet(SelectExpressionSet selectExpressionSet)
        {
            Expressions = selectExpressionSet?.Expressions;
        }

        public SelectExpressionSet(IList<SelectExpression> expressions)
        {
            Expressions = expressions ?? throw new ArgumentNullException($"{nameof(expressions)} is required");
        }

        public SelectExpressionSet(SelectExpression aSelectExpression, SelectExpression bSelectExpression)
        {
            Expressions.Add(aSelectExpression ?? throw new ArgumentNullException($"{nameof(aSelectExpression)} is required"));
            Expressions.Add(bSelectExpression ?? throw new ArgumentNullException($"{nameof(bSelectExpression)} is required"));
        }
        #endregion

        #region distinct
        public SelectExpressionSet Distinct(bool distinct = true)
        {
            _isDistinct = distinct & true;
            return this;
        }
        #endregion

        #region top
        public SelectExpressionSet Top(int? count)
        {
            _top = count;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(s => s.ToString()));
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpression b)
        {
            if (aSet == null)
            {
                aSet = new SelectExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new SelectExpressionSet(bSet.Expressions);
            }
            else
            {
                foreach (var e in bSet.Expressions)
                {
                    aSet.Expressions.Add(e);
                }
            }
            return aSet;
        }
        #endregion
    }
    
}
