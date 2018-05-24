using HTL.DbEx.Utility;
using System;

namespace HTL.DbEx.Sql.Expression
{
    public abstract class DBExpressionEntity
    {
        #region interface
        public virtual string Schema { get; private set; }

        public virtual string EntityName { get; private set; }

        public virtual string AliasName { get; protected set; }

        public bool IsAliased { get; protected set; }

        public bool IsCorrelated { get; protected set; }
        #endregion

        #region constructors
        protected DBExpressionEntity(string schema, string name)
        {
            this.Schema = schema;
            this.EntityName = name;
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
    }

    public interface IDbExpressionEntity<T>
    {
        DBSelectExpressionSet GetInclusiveSelectExpression();

        DBInsertExpressionSet GetInclusiveInsertExpression(T entity);

        void FillObject(T entity, object[] values);
    }

    //TODO: JRod, need to add schema to the entity name...
    public abstract class DBExpressionEntity<T> : DBExpressionEntity, IDbExpressionEntity<T>
    {
        #region interface
        public Func<DBSelectExpressionSet> SelectExpressionProvider { get; set; }
        public Action<T,object[]> FillProvider { get; set; }
        public Func<T,DBInsertExpressionSet> InsertExpressionProvider { get; set; }

        #endregion

        #region constructors
        public DBExpressionEntity(string schema, string name/*, Func<DBSelectExpressionSet> inclusiveSelectExpressionProvider, Action<T, object[]> fillProvider, Func<T,DBInsertExpressionSet> inclusiveInsertProvider*/) : base(schema, name)
        {
            //SelectExpressionProvider = inclusiveSelectExpressionProvider;
            //FillProvider = fillProvider;
            //InsertExpressionProvider = inclusiveInsertProvider;
        }
        #endregion

        #region as
        public DBExpressionEntity<T> As(string alias)
        {
            var clone = CloneUtility.DeepCopy(this);
            clone.AliasName = alias;
            clone.IsAliased = true;
            return clone;
        }
        #endregion

        #region correlate
        public DBExpressionEntity<T> Correlate(string name)
        {
            var clone = CloneUtility.DeepCopy(this);
            clone.AliasName = name;
            clone.IsCorrelated = true;
            return clone;
        }
        #endregion

        #region join
        public DBJoinExpression Join(DBExpressionJoinType joinType, DBFilterExpression joinCondition) => new DBJoinExpression(this, joinType, joinCondition);

        public abstract DBSelectExpressionSet GetInclusiveSelectExpression();

        public abstract DBInsertExpressionSet GetInclusiveInsertExpression(T entity);

        public abstract void FillObject(T entity, object[] values);
        #endregion
    }

}
