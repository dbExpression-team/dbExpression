using System;
using System.Collections.Generic;
using System.Data.Common;
using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.Sql.Expression
{
    public class FieldExpression : 
        DbExpression,
        IDbExpressionSelectClausePart, 
        IAssemblyPart,
        IExpressionMetadataProvider<FieldExpressionMetadata>
    {
        #region internals
        private FieldExpressionMetadata _metadata;
        #endregion

        #region interface
        public FilterExpression IsNull { get { return new FilterExpression(this, null, FilterExpressionOperator.Equal); } }

        public OrderByExpression Asc { get { return new OrderByExpression(this, OrderExpressionDirection.ASC); } }

        public OrderByExpression Desc { get { return new OrderByExpression(this, OrderExpressionDirection.DESC); } }

        FieldExpressionMetadata IExpressionMetadataProvider<FieldExpressionMetadata>.Metadata => _metadata;
        #endregion

        #region constructors
        internal FieldExpression(EntityExpression parentEntity, string name, int size) : this(parentEntity, name)
        {
            this._metadata.Size = size;
        }

        internal FieldExpression(EntityExpression parentEntity, string name)
        {
            this._metadata = new FieldExpressionMetadata(parentEntity, name);
        }
        #endregion

        #region to string
        public override string ToString() => $"{this._metadata.ParentEntity.ToString()}.[{this._metadata.Name}]";

        public string ToString(string format)
        {
            switch (format)
            {
                case "f":
                    return this._metadata.Name;
                case "[f]":
                    return $"[{this._metadata.Name}]";
                case "e.f":
                    return this.ToString();
                case "s.e.f":
                    return $"{this._metadata.ParentEntity.ToString("s.e")}.{this._metadata.Name}";
                case "[s].[e].[f]":
                    return $"{this._metadata.ParentEntity.ToString("[s].[e]")}.[{this._metadata.Name}]";
                case "[s.e.f]":
                    return $"[{this._metadata.ParentEntity.ToString("s.e")}.{this._metadata.Name}]";
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
        public bool Equals(FieldExpression obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (string.Compare(obj._metadata.Name, this._metadata.Name, true) != 0) return false;
            if (obj._metadata.ParentEntity != this._metadata.ParentEntity) return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FieldExpression other)) return false;
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other._metadata.ParentEntity != this._metadata.ParentEntity) return false;

            return true;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(FieldExpression obj1, FieldExpression obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            if (ReferenceEquals(obj2, null)) return false;
            if (obj1._metadata.ParentEntity != obj2._metadata.ParentEntity) return false;

            return true;
        }

        public static bool operator !=(FieldExpression obj1, FieldExpression obj2)
            => !(obj1 == obj2);
        #endregion
    }

}
