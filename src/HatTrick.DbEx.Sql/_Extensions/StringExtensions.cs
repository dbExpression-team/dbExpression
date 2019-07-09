namespace HatTrick.DbEx.Sql
{
    public static class StringExtensions
    {
        public static string Before(this string s, string before) => string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(before) ? s : before + s;
        public static string After(this string s, string after) => string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(after) ? s : s + after;
    }
}
