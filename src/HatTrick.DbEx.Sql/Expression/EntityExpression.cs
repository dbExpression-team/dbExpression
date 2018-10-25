using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Utility;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class EntityExpression : DbExpression, IDbExpressionAssemblyPart
    {
        #region interface
        public virtual SchemaExpression Schema { get; private set; }

        public virtual string EntityName { get; private set; }

        public virtual string AliasName { get; set; }

        public bool IsAliased => !string.IsNullOrWhiteSpace(AliasName);

        public bool IsCorrelated { get; protected set; }
        #endregion

        #region constructors
        protected EntityExpression(SchemaExpression schema, string name)
        {
            Schema = schema;
            EntityName = name;
        }

        protected EntityExpression(SchemaExpression schema, string name, string alias) : this(schema, name)
        {
            AliasName = alias;
        }
        #endregion

        #region copy
        public void CopyTo(EntityExpression destination)
        {
            destination.Schema = Schema;
            destination.EntityName = EntityName;
            destination.AliasName = AliasName;
            destination.IsCorrelated = IsCorrelated;
        }
        #endregion

        #region to string
        public override string ToString() => this.IsCorrelated ? this.AliasName : this.ToString("[s].[e]");

        public string ToString(string format, bool ignoreAlias = false)
        {
            if (this.IsCorrelated) { throw new InvalidOperationException("Correlated entities cannot be converted to string with a formatter."); }

            string val = null;
            switch (format)
            {
                case "e":
                    val = this.EntityName;
                    break;
                case "s.e":
                    val = $"{this.Schema.ToString("s")}.{this.EntityName}";
                    break;
                case "[e]":
                    val = $"[{this.EntityName}]";
                    break;
                case "[s.e]":
                    val = $"[{this.Schema.ToString("s")}.{this.EntityName}]";
                    break;
                case "[s].[e]":
                    val = $"{this.Schema.ToString("[s]")}.[{this.EntityName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (!ignoreAlias && this.IsAliased)
            {
                val += $" AS {this.AliasName}";
            }

            return val;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var entity = obj as EntityExpression;
            if (entity == null)
                return false;

            if (string.Compare(entity.EntityName, this.EntityName, true) != 0)
                return false;

            if (string.Compare(entity.AliasName, this.AliasName, true) != 0)
                return false;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public abstract SelectExpressionSet GetInclusiveSelectExpression();
    }
}
