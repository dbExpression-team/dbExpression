namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IContinuationBuilder<T, U> : IContinuationBuilder<T>
        where U : IContinuationBuilder<T>
    { }
}
