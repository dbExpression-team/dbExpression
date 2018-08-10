using HTL.DbEx.Utility;
using System;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class DBExpressionEntity
    {
        #region interface
        public virtual string ConnectionName { get; set; }
        public virtual string Schema { get; private set; }

        public virtual string EntityName { get; private set; }

        public virtual string AliasName { get; protected set; }

        public bool IsAliased => !string.IsNullOrWhiteSpace(AliasName);

        public bool IsCorrelated { get; protected set; }
        #endregion

        #region constructors
        protected DBExpressionEntity(string connectionName, string schema, string name)
        {
            ConnectionName = connectionName;
            Schema = schema;
            EntityName = name;
        }
        #endregion

        #region to string
        public override string ToString() => this.IsCorrelated ? this.AliasName : this.ToString("[s].[e]");

        public string ToString(string format)
        {
            if (this.IsCorrelated) { throw new InvalidOperationException("Correlated entities cannot be converted to string with a formatter."); }

            string val = null;
            switch (format)
            {
                case "e":
                    val = this.EntityName;
                    break;
                case "s.e":
                    val = $"{this.Schema}.{this.EntityName}";
                    break;
                case "[e]":
                    val = $"[{this.EntityName}]";
                    break;
                case "[s.e]":
                    val = $"[{this.Schema}.{this.EntityName}]";
                    break;
                case "[s].[e]":
                    val = $"[{this.Schema}].[{this.EntityName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            if (this.IsAliased)
            {
                val += $" AS {this.AliasName}";
            }

            return val;
        }
        #endregion

        public abstract DBSelectExpressionSet GetInclusiveSelectExpression();
    }
}
