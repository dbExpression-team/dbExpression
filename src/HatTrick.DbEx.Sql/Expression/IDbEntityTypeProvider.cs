using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbEntityTypeProvider
    {
        Type EntityType { get; }
    }
}
