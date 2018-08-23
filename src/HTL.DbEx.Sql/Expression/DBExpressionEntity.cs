using HTL.DbEx.Sql.Assembler;
using HTL.DbEx.Utility;
using System;

namespace HTL.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class DBExpressionEntity : IDBExpression, ISqlAssemblyPart
    {
        #region interface
        public virtual DBExpressionSchema Schema { get; private set; }

        public virtual string EntityName { get; private set; }

        public virtual string AliasName { get; protected set; }

        public bool IsAliased => !string.IsNullOrWhiteSpace(AliasName);

        public bool IsCorrelated { get; protected set; }
        #endregion

        #region constructors
        protected DBExpressionEntity(DBExpressionSchema schema, string name)
        {
            Schema = schema;
            EntityName = name;
        }

        protected DBExpressionEntity(DBExpressionSchema schema, string name, string alias) : this(schema, name)
        {
            AliasName = alias;
        }
        #endregion

        #region copy
        protected void CopyTo(DBExpressionEntity destination)
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

        public abstract DBSelectExpressionSet GetInclusiveSelectExpression();
    }
}
