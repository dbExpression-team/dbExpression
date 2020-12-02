using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        AnyElement,
        AnyOrderByClause,
        AnyGroupByClause,
        IExpressionTypeProvider,
        ISqlMetadataIdentifier,
        IExpressionProvider<EntityExpression>,
        IExpressionAliasProvider,
        IEquatable<FieldExpression>
    {
        #region internals
        protected readonly string identifier;
        protected readonly Type declaredType;
        protected readonly EntityExpression entity;
        protected readonly string alias;
        #endregion

        #region interface
        string ISqlMetadataIdentifier.Identifier => identifier;
        Type IExpressionTypeProvider.DeclaredType => declaredType;
        EntityExpression IExpressionProvider<EntityExpression>.Expression => entity;
        string IExpressionAliasProvider.Alias => alias;
        #endregion

        #region constructors
        protected FieldExpression(string identifier, Type declaredType, EntityExpression entity) : this(identifier, declaredType, entity, null)
        {
        }

        protected FieldExpression(string identifier, Type declaredType, EntityExpression entity, string alias)
        {
            this.identifier = identifier ?? throw new ArgumentNullException($"{nameof(identifier)} is required.");
            this.declaredType = declaredType ?? throw new ArgumentNullException($"{nameof(declaredType)} is required.");
            this.entity = entity ?? throw new ArgumentNullException($"{nameof(entity)} is required.");
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

        #region order
        public virtual OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public virtual OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(FieldExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (entity is null && obj.entity is object) return false;
            if (entity is object && obj.entity is null) return false;
            if (!entity.Equals(obj.entity)) return false;

            if (declaredType != obj.declaredType) return false;
            if (!StringComparer.Ordinal.Equals(alias, obj.alias)) return false;

            return identifier.Equals(obj.identifier);
        }

        public override bool Equals(object obj)
            => obj is FieldExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (identifier is object ? identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (entity is object ? entity.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (declaredType is object ? declaredType.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (alias is object ? alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region operators
        public static implicit operator OrderByExpression(FieldExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression a) => new GroupByExpression(a);

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (obj1 is null && obj2 is object) return false;
            if (obj1 is object && obj2 is null) return false;
            if (obj1 is null && obj2 is null) return true;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }
}
