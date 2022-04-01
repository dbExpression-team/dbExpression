using Blazorise;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp.Models
{

    public class PagingParameters : IEquatable<PagingParameters>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public IEnumerable<Sort> Sorting { get; set; } = Enumerable.Empty<Sort>();

        public PagingParameters()
        {
        }

        public PagingParameters(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        public PagingParameters(int offset, int limit, Sort sort)
        {
            Offset = offset;
            Limit = limit;
            Sorting = new List<Sort> { sort };
        }

        public PagingParameters(int offset, int limit, IEnumerable<Sort> sorting)
        {
            Offset = offset;
            Limit = limit;
            Sorting = sorting;
        }

        public static PagingParameters CreateDefault(string defaultSortField, SortDirection defaultSortDirection)
            => new PagingParameters(0, 10, CreateDefaultSort(defaultSortField, defaultSortDirection));

        public static PagingParameters CreateDefault(int pageSize, Sort defaultSort)
            => new PagingParameters(0, pageSize, defaultSort);

        public static PagingParameters CreateDefault(Sort defaultSort)
            => new PagingParameters(0, 10, defaultSort);

        public static Sort CreateDefaultSort(string defaultSortField, SortDirection defaultSortDirection)
            => new Sort(defaultSortField, defaultSortDirection == SortDirection.Ascending ? OrderExpressionDirection.ASC : OrderExpressionDirection.DESC);

        public bool Equals(PagingParameters? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Offset != other.Offset) return false;
            if (Limit != other.Limit) return false;
            if (Sorting is null && other.Sorting is object) return false;
            if (Sorting is not null && other.Sorting is null) return false;
            if (Sorting is not null && !Sorting.SequenceEqual(other.Sorting!)) return false;

            return true;
        }

        public override bool Equals(object? other)
            => other is PagingParameters paging && Equals(paging);

        public static bool operator ==(PagingParameters? obj1, PagingParameters? obj2)
        {
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2!);
        }

        public static bool operator !=(PagingParameters obj1, PagingParameters obj2)
            => !(obj1 == obj2);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ Offset.GetHashCode();
                hash = (hash * multiplier) ^ Limit.GetHashCode();
                hash = (hash * multiplier) ^ (Sorting is object ? Sorting.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
