using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringCastFunctionExpression :
        CastFunctionExpression<string>,
        StringElement,
        AnyStringElement,
        IEquatable<StringCastFunctionExpression>
    {
        #region constructors
        public StringCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(string))
        {

        }

        protected StringCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias) 
            : base(expression, convertToDbType, typeof(string), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public StringElement As(string alias)
            => new StringCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(StringCastFunctionExpression obj)
            => obj is StringCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
