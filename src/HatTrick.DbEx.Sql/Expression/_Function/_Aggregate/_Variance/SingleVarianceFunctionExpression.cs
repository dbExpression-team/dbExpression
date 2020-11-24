using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleVarianceFunctionExpression :
        VarianceFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleVarianceFunctionExpression>
    {
        #region constructors
        public SingleVarianceFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int32Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public SingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleVarianceFunctionExpression obj)
            => obj is SingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
