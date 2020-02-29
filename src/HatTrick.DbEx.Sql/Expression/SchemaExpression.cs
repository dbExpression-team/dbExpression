using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class SchemaExpression : 
        IAssemblyPart, 
        IDbExpression,
        IDbExpressionMetadataProvider<ISqlSchemaMetadata>,
        IDbExpressionListProvider<EntityExpression>,
        IDbExpressionAliasProvider,
        IEquatable<SchemaExpression>
    {
        #region internals
        private Lazy<ISqlSchemaMetadata> metadataResolver;
        protected ISqlSchemaMetadata Metadata => metadataResolver.Value;
        protected IDictionary<string, EntityExpression> Entities { get; } = new Dictionary<string, EntityExpression>();
        protected string Alias { get; }
        #endregion

        #region interface
        ISqlSchemaMetadata IDbExpressionMetadataProvider<ISqlSchemaMetadata>.Metadata => Metadata;
        IList<EntityExpression> IDbExpressionListProvider<EntityExpression>.Expressions => Entities.Values.ToList();
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected SchemaExpression(Lazy<ISqlSchemaMetadata> metadata, string alias)
        {
            this.metadataResolver = metadata ?? throw new ArgumentNullException($"{nameof(metadata)} is required");
            Alias = alias;
        }
        #endregion

        #region methods
        public override string ToString() => ToString("[s]");

        public string ToString(string format)
        {
            string val;
            switch (format)
            {
                case "s":
                    val = this.Metadata.Name;
                    break;
                case "[s]":
                    val = $"[{this.Metadata.Name}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            return val;
        }
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

            if (Metadata is null && obj.Metadata is object) return false;
            if (Metadata is object && obj.Metadata is null) return false;
            if (!Metadata.Equals(obj.Metadata)) return false;

            if (!StringComparer.Ordinal.Equals(Alias, obj.Alias)) return false;

            return true;
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
                hash = (hash * multiplier) ^ (Metadata is object ? Metadata.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (Alias is object ? Alias.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
