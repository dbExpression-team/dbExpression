using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression :
        AnyEntity,
        ISqlMetadataIdentifier,
        IExpressionProvider<SchemaExpression>,
        IExpressionListProvider<FieldExpression>,
        IExpressionAliasProvider,
        IEquatable<EntityExpression>
   {
        #region internals
        protected readonly string identifier;
        protected readonly SchemaExpression schema;
        protected IDictionary<string, FieldExpression> Fields { get; } = new Dictionary<string, FieldExpression>();
        protected readonly string alias;
        #endregion

        #region interface
        string ISqlMetadataIdentifier.Identifier => identifier;
        SchemaExpression IExpressionProvider<SchemaExpression>.Expression => schema;
        IList<FieldExpression> IExpressionListProvider<FieldExpression>.Expressions => Fields.Values.ToList();
        string IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        private EntityExpression()
        {

        }
        
        protected EntityExpression(string identifier, SchemaExpression schema, string alias)
        {
            this.identifier = identifier ?? throw new ArgumentNullException($"{nameof(identifier)} is required.");
            this.schema = schema ?? throw new ArgumentNullException($"{nameof(schema)} is required.");
            this.alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => this.ToString(false);

        public string ToString(bool ignoreAlias = false)
        {
            if (ignoreAlias || string.IsNullOrWhiteSpace(alias))
                return identifier;

            return $"{identifier} AS {alias}";
        }
        #endregion

        #region operators
        public static bool operator ==(EntityExpression obj1, EntityExpression obj2)
        {
            if (obj1 is null && obj2 is object) return false;
            if (obj1 is object && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntityExpression obj1, EntityExpression obj2)
            => !(obj1 == obj2);
        #endregion

        #region equals
        public bool Equals(EntityExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (schema is null && obj.schema is object) return false;
            if (schema is object && obj.schema is null) return false;
            if (!schema.Equals(obj.schema)) return false;

            if (!StringComparer.Ordinal.Equals(alias, obj.alias)) return false;

            return identifier.Equals(obj.identifier);
        }

        public override bool Equals(object obj)
            => obj is EntityExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is object ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias is object ? alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
