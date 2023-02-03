using HatTrick.DbEx.Tools.Configuration;
using HatTrick.Model.Sql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Tools
{
    internal static class NamedMetaExtensions
    {
        private static string overrides_key = "__overrides";

        internal static void EnsureOverrides(this INamedMeta meta, params Override[] seed)
        {
            if (!meta.Meta.TryGetValue(overrides_key, out var value))
            {
                meta.Meta[overrides_key] = new List<Override>(seed);
            }
        }

        internal static bool TryGetOverrides(this INamedMeta meta, out IList<Override>? overrides)
        {
            overrides = null;
            if (meta.Meta.TryGetValue(overrides_key, out var value))
            {
                overrides = value as IList<Override>;
                return true;
            }
            return false;
        }

        internal static IList<Override> GetOverrides(this INamedMeta meta)
        {
            return (meta.Meta[overrides_key] as IList<Override>)!;
        }

        internal static bool TryResolveMeta<T>(this INamedMeta meta, Func<Apply, T?> getAppliedValue, out T? item)
        {
            item = default;
            if (!meta.Meta.TryGetValue(overrides_key, out var value))
                return false;

            var overrides = value as List<Override>;

            if (overrides is null || !overrides.Any())
                return false;

            //last apply provided wins
            for (var i = overrides.Count - 1; i >= 0; i--)
            {
                var @override = overrides[i];
                item = getAppliedValue(@override.Apply);
                if (item is not null)
                    return true;
            }

            return false;
        }

        internal static bool TryResolveMeta<T>(this INamedMeta meta, Func<Apply, IOverrideItemList<T>?> getAppliedValue, out IEnumerable<T>? item)
            where T : IComparable
        {
            item = default;
            IOverrideItemList<T>? current = null;
            var collector = new List<T>();

            if (!meta.TryGetOverrides(out var overrides))
                return false;

            if (overrides is null || !overrides.Any())
                return false;

            //last apply provided wins
            for (var i = 0; i < overrides.Count; i++)
            {
                var @override = overrides[i];
                current = getAppliedValue(@override.Apply);
                if (current is null)
                    continue;

                foreach (var x in current.Add)
                {
                    if (!collector.Contains(x))
                        collector.Add(x);
                }
                foreach (var x in current.Remove)
                {
                    if (collector.Contains(x))
                        collector.Remove(x);
                }
            }

            item = collector.AsEnumerable();

            return collector.Any();
        }
    }
}
