using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleCastFunctionExpression :
        CastFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleCastFunctionExpression>
    {
        #region constructors
        public SingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType)
            : base(expression, convertToDbType, typeof(float))
        {

        }

        protected SingleCastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, int? size, int? precision, int? scale, string alias) 
            : base(expression, convertToDbType, typeof(float), size, precision, scale, alias)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleCastFunctionExpression(base.Expression, base.ConvertToDbType, base.Size, base.Precision, base.Scale, alias);
        #endregion

        #region equals
        public bool Equals(SingleCastFunctionExpression obj)
            => obj is SingleCastFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleCastFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
