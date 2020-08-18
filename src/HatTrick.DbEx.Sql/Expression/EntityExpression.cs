using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class EntityExpression :
        IExpression, 
        ISqlMetadataProvider<ISqlEntityMetadata>,
        IExpressionProvider<SchemaExpression>,
        IExpressionListProvider<FieldExpression>,
        IExpressionAliasProvider,
        IEquatable<EntityExpression>
   {
        #region internals
        protected object Identifier;
        protected Lazy<ISqlEntityMetadata> MetadataResolver { get; }
        protected SchemaExpression Schema { get; }
        protected ISqlEntityMetadata Metadata => MetadataResolver.Value;
        protected IDictionary<string, FieldExpression> Fields { get; } = new Dictionary<string, FieldExpression>();
        protected string Alias { get; }
        #endregion

        #region interface
        SchemaExpression IExpressionProvider<SchemaExpression>.Expression => Schema;
        IList<FieldExpression> IExpressionListProvider<FieldExpression>.Expressions => Fields.Values.ToList();
        ISqlEntityMetadata ISqlMetadataProvider<ISqlEntityMetadata>.Metadata => Metadata;
        string IExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected EntityExpression(object identifier, SchemaExpression schema, Lazy<ISqlEntityMetadata> metadata, string alias)
        {
            Identifier = identifier ?? throw new ArgumentNullException($"{nameof(identifier)} is required.");
            Schema = schema ?? throw new ArgumentNullException($"{nameof(schema)} is required.");
            MetadataResolver = metadata ?? throw new ArgumentNullException($"{nameof(metadata)} is required.");
            Alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => this.ToString("[s].[e]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            string val;
            switch (format)
            {
                case "e":
                    val = Metadata.Name;
                    break;
                case "s.e":
                    val = $"{Metadata.Schema.Name}.{Metadata.Name}";
                    break;
                case "[e]":
                    val = $"[{Metadata.Name}]";
                    break;
                case "[s.e]":
                    val = $"[{Metadata.Schema.Name}.{Metadata.Name}]";
                    break;
                case "[s].[e]":
                    val = $"{Metadata.Schema.Name}.[{Metadata.Name}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (!ignoreAlias && !string.IsNullOrWhiteSpace(Alias))
            {
                val += $" AS {Alias}";
            }

            return val;
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

            if (Schema is null && obj.Schema is object) return false;
            if (Schema is object && obj.Schema is null) return false;
            if (!Schema.Equals(obj.Schema)) return false;

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

            return Identifier.Equals(obj.Identifier);
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
                hash = (hash * multiplier) ^ (Identifier is object ? Identifier.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
