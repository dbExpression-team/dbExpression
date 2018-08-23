using System;
using System.Collections.Generic;
using System.Data.Common;
using HTL.DbEx.Sql.Assembler;

namespace HTL.DbEx.Sql.Expression
{
    [Serializable]
    public class DBExpressionField : IDBExpression, IDBExpressionSelectClausePart, ISqlAssemblyPart
    {
        #region interface
        public DBExpressionEntity ParentEntity { get; protected set; }

        public string Name { get; private set; }

        public int? Size { get; private set; }

        public DBFilterExpression IsNull { get { return new DBFilterExpression(this, null, DBFilterExpressionOperator.Equal); } }

        public DBOrderByExpression Asc { get { return new DBOrderByExpression(this, DBOrderExpressionDirection.ASC); } }

        public DBOrderByExpression Desc { get { return new DBOrderByExpression(this, DBOrderExpressionDirection.DESC); } }
        #endregion

        #region constructors
        internal DBExpressionField(DBExpressionEntity parentEntity, string name, int size) : this(parentEntity, name)
        {
            this.Size = size;
        }

        internal DBExpressionField(DBExpressionEntity parentEntity, string name)
        {
            this.ParentEntity = parentEntity;
            this.Name = name;
        }
        #endregion

        #region to string
        public override string ToString() => $"{this.ParentEntity.ToString()}.[{this.Name}]";

        public string ToString(string format)
        {
            switch (format)
            {
                case "f":
                    return this.Name;
                case "[f]":
                    return $"[{this.Name}]";
                case "e.f":
                    return this.ToString();
                case "s.e.f":
                    return $"{this.ParentEntity.ToString("s.e")}.{this.Name}";
                case "[s].[e].[f]":
                    return $"{this.ParentEntity.ToString("[s].[e]")}.[{this.Name}]";
                case "[s.e.f]":
                    return $"[{this.ParentEntity.ToString("s.e")}.{this.Name}]";
                default:
                    throw new ArgumentException($"encountered unknown format string: {format} valid formats are 'e','f','[e]','[f]','e.f','[e].[f]'", "format");
            }
        }
        #endregion

        #region as
        public DBSelectExpression As(string alias) => new DBSelectExpression(this).As(alias);
        #endregion

        #region like
        public DBFilterExpression Like(string phrase) => new DBFilterExpression(this, phrase, DBFilterExpressionOperator.Like);
        #endregion

        #region set field
        public DBAssignmentExpression Set(DBExpression expression) => new DBAssignmentExpression(this, expression);
        #endregion

        #region aggregate functions
        public DBSelectExpression Avg(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.AVG, distinct);

        public DBSelectExpression Min(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.MIN, distinct);

        public DBSelectExpression Max(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.MAX, distinct);

        public DBSelectExpression Sum(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.SUM, distinct);

        public DBSelectExpression Count(bool distinct = false) => new DBAggregateFunctionExpression(this, DBAggregateFunction.COUNT, distinct);
        #endregion

        #region implicit select operator
        public static implicit operator DBSelectExpression(DBExpressionField field) => new DBSelectExpression(field);
        #endregion

        #region field to expression relational operators
        public static DBFilterExpression operator ==(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.Equal);

        public static DBFilterExpression operator !=(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.NotEqual);

        public static DBFilterExpression operator <(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThan);

        public static DBFilterExpression operator <=(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.LessThanOrEqual);

        public static DBFilterExpression operator >(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThan);

        public static DBFilterExpression operator >=(DBExpressionField a, DBExpression b) => new DBFilterExpression(a, b, DBFilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField a, DBExpressionField b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBExpressionField a, DBExpressionField b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBExpressionField a, DBExpressionField b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBExpressionField a, DBExpressionField b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBExpressionField a, DBExpressionField b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to arithmetic expression arithmetic operators
        public static DBArithmeticExpression operator +(DBExpressionField a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Add);

        public static DBArithmeticExpression operator -(DBExpressionField a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Subtract);

        public static DBArithmeticExpression operator *(DBExpressionField a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Multiply);

        public static DBArithmeticExpression operator /(DBExpressionField a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Divide);

        public static DBArithmeticExpression operator %(DBExpressionField a, DBArithmeticExpression b) => new DBArithmeticExpression(a, b, DBArithmeticExpressionOperator.Modulo);
        #endregion

        #region conditional & operator
        public static DBSelectExpressionSet operator &(DBExpressionField a, DBExpressionField b) => new DBSelectExpressionSet(a, b);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}
