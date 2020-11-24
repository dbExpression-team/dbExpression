using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpressionSet : 
        IExpressionElement, 
        IExpressionSet<JoinExpression>
    {
        #region interface
        public IEnumerable<JoinExpression> Expressions { get; private set; }  = new List<JoinExpression>();
        #endregion

        #region constructors
        private JoinExpressionSet()
        { 
        
        }

        public JoinExpressionSet(JoinExpression joinExpression)
        {
            Expressions = Expressions.Concat(new JoinExpression[1] { joinExpression ?? throw new ArgumentNullException($"{nameof(joinExpression)} is required.") });
        }

        public JoinExpressionSet(JoinExpression aJoinExpression, JoinExpression bJoinExpression)
        {
            Expressions = new List<JoinExpression>
            {
                aJoinExpression ?? throw new ArgumentNullException($"{nameof(aJoinExpression)} is required."),
                bJoinExpression ?? throw new ArgumentNullException($"{nameof(bJoinExpression)} is required.")
            };
        }

        public JoinExpressionSet(IEnumerable<JoinExpression> joinExpressions)
        {
            Expressions = joinExpressions ?? throw new ArgumentNullException($"{nameof(joinExpressions)} is required.");
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(Environment.NewLine, Expressions.Select(j => j.ToString()));
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpression b)
        {
            if (aSet is null)
            {
                aSet = new JoinExpressionSet(b);
            }
            else
            {
                aSet.Expressions = aSet.Expressions.Concat(new JoinExpression[1] { b });
            }
            return aSet;
        }

        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpressionSet bSet)
        {
            if (aSet is null)
                return bSet;

            aSet.Expressions = aSet.Expressions.Concat(bSet?.Expressions);
            return aSet;
        }
        #endregion
    }
    
}
