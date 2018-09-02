using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Extensions
{
    public static class StringExtensions
    {
        public static string SpaceBefore(this string s) => string.IsNullOrWhiteSpace(s) ? s : " " + s;
        public static string SpaceAfter(this string s) => string.IsNullOrWhiteSpace(s) ? s : s + " ";
        public static string NewLineBefore(this string s, bool minify) => string.IsNullOrWhiteSpace(s) || minify ? s : Environment.NewLine + s;
        public static string NewLineAfter(this string s, bool minify) => string.IsNullOrWhiteSpace(s) || minify ? s : s + Environment.NewLine;

    }
}
