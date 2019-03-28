using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Extensions
{
    public static class ListExtensions
    {
        public static bool CompareTo<T>(this IList<T> a, IList<T> b)
        {
            return CompareTo(a.AsEnumerable(), b.AsEnumerable());
        }

        public static bool CompareTo<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            if (a == default && b == default)
                return true;

            if (a != default && b == default)
                return false;

            if (a == default && b != default)
                return false;

            if (a.Count() != b.Count())
                return false;

            var lookup = new Dictionary<T, int>();
            foreach (T value in a)
            {
                if (lookup.ContainsKey(value))
                {
                    lookup[value]++;
                }
                else
                {
                    lookup.Add(value, 1);
                }
            }
            foreach (T value in b)
            {
                if (lookup.ContainsKey(value))
                {
                    lookup[value]--;
                }
                else
                {
                    return false;
                }
            }
            return lookup.Values.All(c => c == 0);
        }
    }
}
