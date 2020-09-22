using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlField
    {
        int Index { get; }
        string Name { get; }
        Type DataType { get; }
        object Value { get; }
        T GetValue<T>();
    }
}
