using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Utility;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression : 
        IDbExpression, 
        IAssemblyPart, 
        IDbExpressionMetadataProvider<ISqlEntityMetadata>,
        IDbExpressionProvider<SchemaExpression>,
        IDbExpressionAliasProvider,
        IEquatable<EntityExpression>
   {
        #region internals
        protected SchemaExpression Schema { get; }
        protected ISqlEntityMetadata Metadata { get; }
        protected IDictionary<string, ISqlFieldMetadata> Fields { get; } = new Dictionary<string, ISqlFieldMetadata>();
        protected string Alias { get; }
        #endregion

        #region interface
        SchemaExpression IDbExpressionProvider<SchemaExpression>.Expression => Schema;
        ISqlEntityMetadata IDbExpressionMetadataProvider<ISqlEntityMetadata>.Metadata => Metadata;
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected EntityExpression(SchemaExpression schema, ISqlEntityMetadata metadata, IDictionary<string, ISqlFieldMetadata> fields, string alias)
        {
            Schema = schema;
            Metadata = metadata;
            Fields = fields;
            Alias = alias;
        }
        #endregion

        #region to string
        public override string ToString() => this.ToString("[s].[e]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            string val = null;
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

        public bool Equals(EntityExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.Metadata != this.Metadata) return false;
            if (obj.Alias != this.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
            => Equals(obj as EntityExpression);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(EntityExpression obj1, EntityExpression obj2)
        {
            if (ReferenceEquals(null, obj1) && !ReferenceEquals(null, obj2)) return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntityExpression obj1, EntityExpression obj2)
            => !(obj1 == obj2);

        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
