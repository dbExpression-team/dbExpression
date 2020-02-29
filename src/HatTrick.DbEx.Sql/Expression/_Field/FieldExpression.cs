using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class FieldExpression : 
        IDbExpression,
        IAssemblyPart,
        IDbExpressionMetadataProvider<ISqlFieldMetadata>,
        IDbExpressionProvider<EntityExpression>,
        IDbExpressionAliasProvider,
        IEquatable<FieldExpression>
    {
        #region internals
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
        protected FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata) : this(entity, metadata, null)
        {
        }

        protected FieldExpression(EntityExpression entity, Lazy<ISqlFieldMetadata> metadata, string alias)
        {
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
        public OrderByExpression Asc => new OrderByExpression(new ExpressionContainer(this), OrderExpressionDirection.ASC);
        public OrderByExpression Desc => new OrderByExpression(new ExpressionContainer(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(FieldExpression field) => new OrderByExpression(new ExpressionContainer(field), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(FieldExpression field) => new GroupByExpression(new ExpressionContainer(field));
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

            if (Entity is null && obj.Entity is object) return false;
            if (Entity is object && obj.Entity is null) return false;
            if (!Entity.Equals(obj.Entity)) return false;

            if (Metadata is null && obj.Metadata is object) return false;
            if (Metadata is object && obj.Metadata is null) return false;
            if (!Metadata.Equals(obj.Metadata)) return false;

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

            return true;
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
                hash = (hash * multiplier) ^ (Entity is object ? Entity.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Metadata is object ? Metadata.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }

}
