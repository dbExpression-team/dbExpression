using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Utility;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression : 
        IDbExpression, 
        IAssemblyPart, 
        IExpressionMetadataProvider<EntityExpressionMetadata>,
        IEquatable<EntityExpression>
    {
        #region internals
        private EntityExpressionMetadata Metadata { get; set; }
        #endregion

        #region interface
        EntityExpressionMetadata IExpressionMetadataProvider<EntityExpressionMetadata>.Metadata => Metadata;
        #endregion

        #region constructors
        protected EntityExpression(EntityExpressionMetadata metadata)
        {
            Metadata = metadata;
        }

        protected EntityExpression(SchemaExpression schema, string name)
        {
            Metadata = new EntityExpressionMetadata(schema, name);
        }

        protected EntityExpression(SchemaExpression schema, string name, string alias) : this(schema, name)
        {
            Metadata.AliasName = alias;
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
                    val = this.Metadata.EntityName;
                    break;
                case "s.e":
                    val = $"{this.Metadata.Schema.ToString("s")}.{this.Metadata.EntityName}";
                    break;
                case "[e]":
                    val = $"[{this.Metadata.EntityName}]";
                    break;
                case "[s.e]":
                    val = $"[{this.Metadata.Schema.ToString("s")}.{this.Metadata.EntityName}]";
                    break;
                case "[s].[e]":
                    val = $"{this.Metadata.Schema.ToString("[s]")}.[{this.Metadata.EntityName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (!ignoreAlias && !string.IsNullOrWhiteSpace(this.Metadata.AliasName))
            {
                val += $" AS {this.Metadata.AliasName}";
            }

            return val;
        }
        #endregion

        public bool Equals(EntityExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (string.Compare(obj.Metadata.EntityName, this.Metadata.EntityName, true) != 0) return false;
            if (string.Compare(obj.Metadata.AliasName, this.Metadata.AliasName, true) != 0) return false;
            if (obj.Metadata.Schema != this.Metadata.Schema) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityExpression other)) return false;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (string.Compare(other.Metadata.EntityName, this.Metadata.EntityName, true) != 0) return false;
            if (string.Compare(other.Metadata.AliasName, this.Metadata.AliasName, true) != 0) return false;
            if (other.Metadata.Schema != this.Metadata.Schema) return false;

            return true;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(EntityExpression obj1, EntityExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (string.Compare(obj1.Metadata.EntityName, obj2.Metadata.EntityName, true) != 0) return false;
            if (string.Compare(obj1.Metadata.AliasName, obj2.Metadata.AliasName, true) != 0) return false;
            if (obj1.Metadata.Schema != obj2.Metadata.Schema) return false;

            return true;
        }

        public static bool operator !=(EntityExpression obj1, EntityExpression obj2)
            => !(obj1 == obj2);

        protected abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
