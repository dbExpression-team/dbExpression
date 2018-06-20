namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IContinuationBuilder<T> : IBuilder<T>
    { }

    public interface IContinuationBuilder<T,U> : IContinuationBuilder<T>
        where U : IContinuationBuilder<T>
    { }
}
