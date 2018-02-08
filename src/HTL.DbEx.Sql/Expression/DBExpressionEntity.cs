using System;

namespace HTL.DbEx.Sql.Expression
{
    //TODO: JRod, need to add schema to the entity name...
    public class DBExpressionEntity
    {
        #region interface
        public virtual string Schema { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string AliasName { get; protected set; }

        public bool IsAliased { get; protected set; }

        public bool IsCorrelated { get; protected set; }
        #endregion

        #region constructors
        public DBExpressionEntity(string schema, string name)
        {
            this.Schema = schema;
            this.Name = name;
        }
        #endregion

        #region as
        public DBExpressionEntity As(string alias) => new DBExpressionEntity(this.Schema, this.Name) { AliasName = alias, IsAliased = true };
        #endregion

        #region correlate
        public DBExpressionEntity Correlate(string name) => new DBExpressionEntity(this.Schema, this.Name) { AliasName = name, IsCorrelated = true };
        #endregion

        #region join
        public DBJoinExpression Join(DBExpressionJoinType joinType, DBFilterExpression joinCondition) => new DBJoinExpression(this, joinType, joinCondition);
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
                    val = this.Name;
                    break;
                case "s.e":
                    val = $"{this.Schema}.{this.Name}";
                    break;
                case "[e]":
                    val = $"[{this.Name}]";
                    break;
                case "[s.e]":
                    val = $"[{this.Schema}.{this.Name}]";
                    break;
                case "[s].[e]":
                    val = $"[{this.Schema}].[{this.Name}]";
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
    }

}
