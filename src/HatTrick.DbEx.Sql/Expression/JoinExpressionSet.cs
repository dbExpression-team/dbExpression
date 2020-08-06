using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpressionSet : 
        IExpression, 
        IExpressionSet<JoinExpression>
    {
        #region interface
        public IList<JoinExpression> Expressions { get; }  = new List<JoinExpression>();
        #endregion

        #region constructors
        internal JoinExpressionSet()
        { 
        
        }

        public JoinExpressionSet(JoinExpression joinExpression)
        {
            Expressions.Add(joinExpression ?? throw new ArgumentNullException($"{nameof(joinExpression)} is required."));
        }

        public JoinExpressionSet(JoinExpression aJoinExpression, JoinExpression bJoinExpression)
        {
            Expressions.Add(aJoinExpression ?? throw new ArgumentNullException($"{nameof(aJoinExpression)} is required."));
            Expressions.Add(bJoinExpression ?? throw new ArgumentNullException($"{nameof(bJoinExpression)} is required."));
        }
        #endregion

        #region to string
        public override string ToString() => string.Join(Environment.NewLine, Expressions.Select(j => j.ToString()));
        #endregion

        #region logical & operator
        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpression b)
        {
            aSet.Expressions.Add(b);
            return aSet;
        }

        public static JoinExpressionSet operator &(JoinExpressionSet aSet, JoinExpressionSet bSet)
        {
            foreach (var b in bSet.Expressions)
                aSet.Expressions.Add(b);
            return aSet;
        }
        #endregion
    }
    
}
