using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public static class dbex
    {
        public static AliasExpression alias(string tableName, string fieldName)
            => new AliasExpression(tableName, fieldName);
    }
#pragma warning restore IDE1006 // Naming Styles
}
