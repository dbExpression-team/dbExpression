using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class AverageFunctionExpression :
        DbExpression,
        IAssemblyPart,
        IDbExpressionSelectClausePart
    {
        #region interface
        public (Type, object) Expression { get; }
        public bool IsDistinct { get; }
        #endregion

        #region constructors
        internal AverageFunctionExpression()
        {
        }

        public AverageFunctionExpression(IDbExpressionSelectClausePart expression, bool isDistinct)
        {
            Expression = (expression.GetType(), (object)expression);
            IsDistinct = isDistinct;
        }
        #endregion

        #region as
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);

        #endregion

        #region to string
        public override string ToString() => $"AVG({Expression})";
        #endregion

        #region implicit select operators
        public static implicit operator SelectExpression(AverageFunctionExpression a) => new SelectExpression(a);
        #endregion
    }
}
