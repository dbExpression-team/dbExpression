using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class SchemaExpression : 
        IAssemblyPart, 
        IDbExpression,
        IEquatable<SchemaExpression>,
        IDbExpressionMetadataProvider<ISqlSchemaMetadata>,
        IDbExpressionAliasProvider
    {
        #region internals
        protected ISqlSchemaMetadata Metadata { get; }
        protected string Alias { get; }
        #endregion

        #region interface
        ISqlSchemaMetadata IDbExpressionMetadataProvider<ISqlSchemaMetadata>.Metadata => Metadata;
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        public SchemaExpression(ISqlSchemaMetadata metadata, string alias)
        {
            Metadata = metadata ?? throw new DbExpressionConfigurationException($"Schema expression is invalid - required argument is null", new ArgumentNullException($"{nameof(metadata)} is required"));
            Alias = alias;
        }
        #endregion

        #region methods
        public override string ToString() => ToString("[s]");

        public string ToString(string format)
        {
            string val = null;
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

        public bool Equals(SchemaExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.Alias != this.Alias) return false;
            if (obj.Metadata != this.Metadata) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SchemaExpression other)) return false;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.Alias != this.Alias) return false;
            if (other.Metadata != this.Metadata) return false;

            return true;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(SchemaExpression obj1, SchemaExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (obj1.Metadata != obj2.Metadata) return false;

            return true;
        }

        public static bool operator !=(SchemaExpression obj1, SchemaExpression obj2)
            => !(obj1 == obj2);

        #endregion
    }
}
