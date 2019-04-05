namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionAliasProvider
    {
        string Alias { get; }
    }

    public interface IDbExpressionIsDistinctProvider
    {
        bool IsDistinct { get; }
    }

    public interface IDbExpressionIsTopProvider
    {
        int? Top { get; }
    }
}
