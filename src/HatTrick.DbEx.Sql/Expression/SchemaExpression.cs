using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SchemaExpression : 
        IExpressionElement,
        ISqlMetadataIdentifierProvider,
        IExpressionListProvider<EntityExpression>,
        IEquatable<SchemaExpression>
    {
        #region internals
        protected readonly string identifier;
        protected IDictionary<string, EntityExpression> Entities { get; } = new Dictionary<string, EntityExpression>();
        protected string Alias { get; }
        #endregion

        #region interface
        public string Identifier => identifier;
        IList<EntityExpression> IExpressionListProvider<EntityExpression>.Expressions => Entities.Values.ToList();
        #endregion

        #region constructors
        protected SchemaExpression(string identifier, string alias)
        {
            this.identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            Alias = alias;
        }
        #endregion

        #region methods
        public override string ToString()
            => Identifier;
        #endregion

        #region operators
        public static bool operator ==(SchemaExpression obj1, SchemaExpression obj2)
        {
            if (obj1 is null && obj2 is object) return false;
            if (obj1 is object && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SchemaExpression obj1, SchemaExpression obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(SchemaExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Identifier.Equals(obj.Identifier);
        }

        public override bool Equals(object obj)
            => obj is SchemaExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (Identifier is object ? Identifier.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
