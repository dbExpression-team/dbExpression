using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    public class CoalesceFunctionExpression : 
        DbExpression, 
        IAssemblyPart,
        IDbExpressionSelectClausePart
    {
        #region interface
        public IList<(Type,object)> Expressions { get; } = new List<(Type,object)>();
        #endregion

        #region constructors
        internal CoalesceFunctionExpression()
        {
        }

        public CoalesceFunctionExpression(IList<IDbExpressionSelectClausePart> expressions)
        {
            Expressions = expressions.Select(e => (e.GetType(), (object)e)).ToList();
        }
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);

        #endregion

        #region to string
        public override string ToString() => $"COALESCE({string.Join(", ", Expressions.Select(e => e.Item2))})";
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(CoalesceFunctionExpression a) => new SelectExpression(a);
        #endregion
    }
}
