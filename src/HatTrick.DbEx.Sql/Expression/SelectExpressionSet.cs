using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpressionSet : 
        IExpressionElement,
        IExpressionSet<SelectExpression>
    {
        #region interface
        public IEnumerable<SelectExpression> Expressions { get; private set; } = new List<SelectExpression>();
        #endregion

        #region constructor
        private SelectExpressionSet()
        {

        }

        public SelectExpressionSet(params SelectExpression[] expressions)
        {
            Expressions = (expressions ?? throw new ArgumentNullException($"{nameof(expressions)} is required")).ToList();
        }

        public SelectExpressionSet(SelectExpression selectExpression)
        {
            Expressions = new SelectExpression[1] { selectExpression ?? throw new ArgumentNullException($"{nameof(selectExpression)} is required") };
        }

        public SelectExpressionSet(SelectExpressionSet selectExpressionSet)
        {
            Expressions = selectExpressionSet?.Expressions;
        }

        public SelectExpressionSet(IEnumerable<SelectExpression> expressions)
        {
            Expressions = expressions ?? throw new ArgumentNullException($"{nameof(expressions)} is required");
        }

        public SelectExpressionSet(SelectExpression aSelectExpression, SelectExpression bSelectExpression)
        {
            Expressions = new SelectExpression[2] {
                aSelectExpression ?? throw new ArgumentNullException($"{nameof(aSelectExpression)} is required"),
                bSelectExpression ?? throw new ArgumentNullException($"{nameof(bSelectExpression)} is required")
            };
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(", ", Expressions.Select(g => g.ToString()));
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpression b)
        {
            if (aSet is null)
            {
                aSet = b;
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new SelectExpression[1] { b });
            }
            return aSet;
        }

        public static SelectExpressionSet operator &(SelectExpressionSet aSet, SelectExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
