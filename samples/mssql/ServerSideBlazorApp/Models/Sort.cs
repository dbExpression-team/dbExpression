using DbExpression.Sql.Expression;
using System;

namespace ServerSideBlazorApp.Models
{
    public class Sort : IEquatable<Sort>
    {
        public string Field { get; set; }
        public OrderExpressionDirection Direction { get; set; }

        public Sort(string field, OrderExpressionDirection direction)
        {
            Field = field;
            Direction = direction;
        }

        public bool Equals(Sort? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            if (Field != other.Field) return false;
            if (Direction != other.Direction) return false;

            return true;
        }

        public override bool Equals(object? other)
        {
            return other is Sort paging && Equals(paging);
        }

        public static bool operator ==(Sort? obj1, Sort? obj2)
        {
            if (obj1 is null && obj2 is not null) return false;
            if (obj1 is not null && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1!.Equals(obj2!);
        }

        public static bool operator !=(Sort? obj1, Sort? obj2)
            => !(obj1 == obj2);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ Field?.GetHashCode() ?? 0;
                hash = (hash * multiplier) ^ Direction.GetHashCode();
                return hash;
            }
        }
    }
}
