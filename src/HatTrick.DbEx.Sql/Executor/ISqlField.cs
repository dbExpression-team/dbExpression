using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlField
    {
        int Index { get; }
        string Name { get; }
        object Value { get; }
        T GetValue<T>();
    }
}
