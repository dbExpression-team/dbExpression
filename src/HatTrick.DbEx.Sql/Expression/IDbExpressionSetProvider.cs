using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionSetProvider
    {
        ExpressionSet Expression { get; }

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
