using System;
using System.Data;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql
{
    #region delegate definitions
    public delegate void FillObjectCallback<T>(T obj, object[] data) where T : new();

    public delegate DBSelectExpressionSet SelectExpressionProvider();

    public delegate DBInsertExpressionSet InsertExpressionProvider<T>(T obj) where T : new();
    #endregion
}