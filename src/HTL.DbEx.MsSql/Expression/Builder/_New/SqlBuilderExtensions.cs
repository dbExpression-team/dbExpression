using HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql.Expression._New
{
    public static class SqlBuilderExtensions
    {
        public static void Execute(this ITerminationBuilder builder) => builder.Execute((SqlConnection)null);

        //TODO: feature/interface-implementation: should this be an actual Transaction and not a connection? 
        public static void Execute(this ITerminationBuilder builder, SqlConnection transaction)
        {
            var expression = (builder as SqlBuilder).Expression;
            //var validator = new MsSqlValidator(expression).Validate();
            //string sql = new MsSqlAssembler(expression).Assemble();
            //var executor = new SqlExecutor(SqlOptions.MsSql, sql, transaction);  //SqlOptions.MsSql is an object configured at app startup that has connection string, sql version, etc...
        }

        public static T Execute<T>(this ITerminationBuilder<T> builder) => builder.Execute((SqlConnection)null);

        public static T Execute<T>(this ITerminationBuilder<T> builder, SqlConnection transaction)
        {
            var expression = (builder as SqlBuilder).Expression;
            //var validator  = new MsSqlValidator(expression).Validate();
            //string sql = new MsSqlAssembler(expression).Assemble();
            //var executor = new SqlExecutor(SqlOptions.MsSql, sql, transaction);  //SqlOptions.MsSql is an object configured at app startup that has connection string, sql version, etc...
            return default(T);
        }
    }
}
