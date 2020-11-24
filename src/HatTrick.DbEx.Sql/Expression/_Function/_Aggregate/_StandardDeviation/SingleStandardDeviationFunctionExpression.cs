using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleStandardDeviationFunctionExpression :
        StandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public SingleStandardDeviationFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int32Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(SingleElement expression) : base(expression)
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
        public SingleStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleStandardDeviationFunctionExpression obj)
            => obj is SingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
