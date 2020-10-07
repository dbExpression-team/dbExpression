using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionTypeProvider
    {
        Type DeclaredType { get; }
    }
}
