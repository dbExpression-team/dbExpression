using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Utility;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression : DbExpression, 
        IAssemblyPart, 
        IExpressionMetadataProvider<EntityExpressionMetadata>,
        IEquatable<EntityExpression>
    {
        #region internals
        private EntityExpressionMetadata _metadata;
        #endregion

        #region interface
        public bool IsCorrelated { get; protected set; }
        EntityExpressionMetadata IExpressionMetadataProvider<EntityExpressionMetadata>.Metadata => _metadata;
        #endregion

        #region constructors
        protected EntityExpression(EntityExpressionMetadata metadata)
        {
            _metadata = metadata;
        }

        protected EntityExpression(SchemaExpression schema, string name)
        {
            _metadata = new EntityExpressionMetadata(schema, name);
        }

        protected EntityExpression(SchemaExpression schema, string name, string alias) : this(schema, name)
        {
            _metadata.AliasName = alias;
        }
        #endregion

        #region copy
        public void CopyTo(EntityExpression destination)
        {
            destination._metadata.Schema = _metadata.Schema;
            destination._metadata.EntityName = _metadata.EntityName;
            destination._metadata.AliasName = _metadata.AliasName;
            destination.IsCorrelated = IsCorrelated;
        }
        #endregion

        #region to string
        public override string ToString() => this.IsCorrelated ? this._metadata.AliasName : this.ToString("[s].[e]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            if (this.IsCorrelated) { throw new InvalidOperationException("Correlated entities cannot be converted to string with a formatter."); }

            string val = null;
            switch (format)
            {
                case "e":
                    val = this._metadata.EntityName;
                    break;
                case "s.e":
                    val = $"{this._metadata.Schema.ToString("s")}.{this._metadata.EntityName}";
                    break;
                case "[e]":
                    val = $"[{this._metadata.EntityName}]";
                    break;
                case "[s.e]":
                    val = $"[{this._metadata.Schema.ToString("s")}.{this._metadata.EntityName}]";
                    break;
                case "[s].[e]":
                    val = $"{this._metadata.Schema.ToString("[s]")}.[{this._metadata.EntityName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (!ignoreAlias && !string.IsNullOrWhiteSpace(this._metadata.AliasName))
            {
                val += $" AS {this._metadata.AliasName}";
            }

            return val;
        }
        #endregion

        public bool Equals(EntityExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (string.Compare(obj._metadata.EntityName, this._metadata.EntityName, true) != 0) return false;
            if (string.Compare(obj._metadata.AliasName, this._metadata.AliasName, true) != 0) return false;
            if (obj._metadata.Schema != this._metadata.Schema) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityExpression other)) return false;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (string.Compare(other._metadata.EntityName, this._metadata.EntityName, true) != 0) return false;
            if (string.Compare(other._metadata.AliasName, this._metadata.AliasName, true) != 0) return false;
            if (other._metadata.Schema != this._metadata.Schema) return false;

            return true;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(EntityExpression obj1, EntityExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (string.Compare(obj1._metadata.EntityName, obj2._metadata.EntityName, true) != 0) return false;
            if (string.Compare(obj1._metadata.AliasName, obj2._metadata.AliasName, true) != 0) return false;
            if (obj1._metadata.Schema != obj2._metadata.Schema) return false;

            return true;
        }

        public static bool operator !=(EntityExpression obj1, EntityExpression obj2)
            => !(obj1 == obj2);

        public abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
