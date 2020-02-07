using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CastFunctionExpression : ConversionFunctionExpression,
        IDbFunctionExpression,
        IAssemblyPart,
        ISupportedForExpression<SelectExpression>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression>,
        ISupportedForFunctionExpression<CountFunctionExpression>,
        ISupportedForFunctionExpression<IsNullFunctionExpression>,
        ISupportedForFunctionExpression<IDbDateFunctionExpression>,
        IEquatable<CastFunctionExpression>
    {
        #region interface
        public SqlDbType ConvertToSqlDbType { get; set; }
        public int? Size { get; set; }
        public int? Precision { get; set; }
        public int? Scale { get; set; }
        #endregion

        #region constructors
        protected CastFunctionExpression()
        {
        }

        protected CastFunctionExpression((Type, object) expression)
            : base(expression)
        {
        }
        #endregion

        #region to string
        public override string ToString() => $"CAST({Expression.Item2} AS {ConvertToSqlDbType}{(Size.HasValue ? $"({Size})" : "")})";
        #endregion

        #region equals
        public bool Equals(CastFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (!obj.ConvertToSqlDbType.Equals(this.ConvertToSqlDbType)) return false;
            if (!obj.Size.Equals(this.Size)) return false;
            if (!obj.Precision.Equals(this.Precision)) return false;
            if (!obj.Scale.Equals(this.Scale)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is CastFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator OrderByExpression(CastFunctionExpression cast) => new OrderByExpression(cast.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(CastFunctionExpression cast) => new GroupByExpression(cast.Expression);
        #endregion
    }
}
