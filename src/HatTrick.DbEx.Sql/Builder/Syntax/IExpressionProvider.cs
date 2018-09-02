using HatTrick.DbEx.Sql.Expression;
using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IExpressionProvider
    {
        ExpressionSet GetExpression();

        #region hide object properties
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
        #endregion
    }
}
