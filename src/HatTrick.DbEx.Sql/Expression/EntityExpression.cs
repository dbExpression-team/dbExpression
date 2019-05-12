using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression : 
        IDbExpression, 
        IAssemblyPart, 
        IDbExpressionMetadataProvider<ISqlEntityMetadata>,
        IDbExpressionProvider<SchemaExpression>,
        IDbExpressionListProvider<FieldExpression>,
        IDbExpressionAliasProvider,
        IEquatable<EntityExpression>
   {
        #region internals
        protected SchemaExpression Schema { get; }
        protected ISqlEntityMetadata Metadata { get; }
        protected IDictionary<string, Lazy<FieldExpression>> Fields { get; } = new Dictionary<string, Lazy<FieldExpression>>();
        protected string Alias { get; }
        #endregion

        #region interface
        SchemaExpression IDbExpressionProvider<SchemaExpression>.Expression => Schema;
        IList<FieldExpression> IDbExpressionListProvider<FieldExpression>.Expressions => Fields.Values.Select(v => v.Value).ToList();
        ISqlEntityMetadata IDbExpressionMetadataProvider<ISqlEntityMetadata>.Metadata => Metadata;
        string IDbExpressionAliasProvider.Alias => Alias;
        #endregion

        #region constructors
        protected EntityExpression(SchemaExpression schema, ISqlEntityMetadata metadata, string alias)
        {
            Schema = schema;
            Metadata = metadata;
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
            => Equals(obj, false);

        public bool Equals(EntityExpression obj, bool ignoreAlias)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.Metadata != this.Metadata) return false;
            if (!ignoreAlias && obj.Alias != this.Alias) return false;

            return true;
        }

        public override bool Equals(object obj)
            => Equals(obj as EntityExpression);

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(EntityExpression obj1, EntityExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntityExpression obj1, EntityExpression obj2)
            => !(obj1 == obj2);

        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
