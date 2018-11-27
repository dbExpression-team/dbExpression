using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class JoinExpressionSet : DbExpression, IDbExpressionSet<JoinExpression>, IAssemblyPart
    {
        #region interface
        public IList<JoinExpression> Expressions { get; }  = new List<JoinExpression>();
        #endregion

        #region constructors
        public JoinExpressionSet(JoinExpression a)
        {
            Expressions.Add(a);
        }

        public JoinExpressionSet(JoinExpression a, JoinExpression b)
        {
            Expressions.Add(a);
            Expressions.Add(b);
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
