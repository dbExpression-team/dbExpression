using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        IDbExpression,
        IDbExpressionMetadataProvider<ISqlFieldMetadata>,
        IDbExpressionProvider<EntityExpression>,
        IDbExpressionAliasProvider,
        IEquatable<FieldExpression>
    {
        #region internals
        protected object Identifier;

        protected Lazy<ISqlFieldMetadata> MetadataResolver;
        protected EntityExpression Entity { get; }
        protected ISqlFieldMetadata Metadata => MetadataResolver.Value;
        protected string Alias { get; private set; }
        #endregion

        #region interface
        EntityExpression IDbExpressionProvider<EntityExpression>.Expression => Entity;
        ISqlFieldMetadata IDbExpressionMetadataProvider<ISqlFieldMetadata>.Metadata => Metadata;
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : this(identifier, entity, metadata, null)
        {
        }

        protected FieldExpression(object identifier, EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias)
        {
            Identifier = identifier ?? throw new ArgumentNullException($"{nameof(identifier)} is required.");
            Entity = entity ?? throw new ArgumentNullException($"{nameof(entity)} is required.");
            MetadataResolver = metadata ?? throw new ArgumentNullException($"{nameof(metadata)} is required.");
            Alias = alias;
        }
        #endregion

        #region as
        public FieldExpression As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region to string
        public override string ToString() => this.ToString("[s].[e].[f]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            string val;
            switch (format)
            {
                case "f":
                    val = this.Metadata.Name;
                    break;
                case "[f]":
                    val = $"[{this.Metadata.Name}]";
                    break;
                case "e.f":
                    val = $"{this.Metadata.Entity.Name}.{this.Metadata.Name}";
                    break;
                case "s.e.f":
                    val = $"{this.Metadata.Entity.Schema.Name}.{this.Metadata.Entity.Name}.{this.Metadata.Name}";
                    break;
                case "[s].[e].[f]":
                    val = $"[{this.Metadata.Entity.Schema.Name}].[{this.Metadata.Entity.Name}].[{this.Metadata.Name}]";
                    break;
                case "[s.e.f]":
                    val = $"[{this.Metadata.Entity.Schema.Name}.{this.Metadata.Entity.Name}.{this.Metadata.Name}]";
                    break;
                default:
                    throw new ArgumentException($"encountered unknown format string: {format} valid formats are 'e','f','[e]','[f]','e.f','[e].[f]', s.e.f, [s].[e].[f], [s.e.f]", nameof(format));
            }

            if (!ignoreAlias && !string.IsNullOrWhiteSpace(Alias))
            {
                val += $" AS {Alias}";
            }

            return val;
        }
        #endregion

        #region order
        public abstract OrderByExpression Asc { get; }
        public abstract OrderByExpression Desc { get; }
        #endregion

        #region operators
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

        #region equals
        public bool Equals(FieldExpression obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (Entity is null && obj.Entity is object) return false;
            if (Entity is object && obj.Entity is null) return false;
            if (!Entity.Equals(obj.Entity)) return false;

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

            return Identifier.Equals(obj.Identifier);
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
                hash = (hash * multiplier) ^ (Identifier is object ? Identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Entity is object ? Entity.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }

}
