using System;
using System.Collections.Generic;
using System.Data.Common;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public class FieldExpression : DbExpression, IDbExpressionSelectClausePart, IDbExpressionAssemblyPart
    {
        #region interface
        public EntityExpression ParentEntity { get; protected set; }

        public string Name { get; private set; }

        public int? Size { get; private set; }

        public FilterExpression IsNull { get { return new FilterExpression(this, null, FilterExpressionOperator.Equal); } }

        public OrderByExpression Asc { get { return new OrderByExpression(this, OrderExpressionDirection.ASC); } }

        public OrderByExpression Desc { get { return new OrderByExpression(this, OrderExpressionDirection.DESC); } }
        #endregion

        #region constructors
        internal FieldExpression(EntityExpression parentEntity, string name, int size) : this(parentEntity, name)
        {
            this.Size = size;
        }

        internal FieldExpression(EntityExpression parentEntity, string name)
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
        public SelectExpression As(string alias) => new SelectExpression(this).As(alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase) => new FilterExpression(this, phrase, FilterExpressionOperator.Like);
        #endregion

        #region set field
        public AssignmentExpression Set(DbExpression expression) => new AssignmentExpression(this, expression);
        #endregion

        #region aggregate functions
        public SelectExpression Avg(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.AVG, distinct);

        public SelectExpression Min(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.MIN, distinct);

        public SelectExpression Max(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.MAX, distinct);

        public SelectExpression Sum(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.SUM, distinct);

        public SelectExpression Count(bool distinct = false) => new AggregateFunctionExpression(this, AggregateFunction.COUNT, distinct);
        #endregion

        #region implicit select operator
        public static implicit operator SelectExpression(FieldExpression field) => new SelectExpression(field);
        #endregion

        #region field to expression relational operators
        public static FilterExpression operator ==(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator <=(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator >=(FieldExpression a, DbExpression b) => new FilterExpression(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region field to field arithmetic operators
        public static ArithmeticExpression operator +(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(FieldExpression a, FieldExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region field to arithmetic expression arithmetic operators
        public static ArithmeticExpression operator +(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide);

        public static ArithmeticExpression operator %(FieldExpression a, ArithmeticExpression b) => new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo);
        #endregion

        #region conditional & operator
        public static SelectExpressionSet operator &(FieldExpression a, FieldExpression b) => new SelectExpressionSet(a, b);
        #endregion

        #region equals
        public override bool Equals(object obj) => base.Equals(obj);
        #endregion

        #region override get hash code
        public override int GetHashCode() => base.GetHashCode();
        #endregion
    }

}
