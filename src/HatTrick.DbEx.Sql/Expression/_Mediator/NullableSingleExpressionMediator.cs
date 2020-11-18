using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleExpressionMediator :
        NullableExpressionMediator<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleExpressionMediator>
    {
        #region constructors
        private NullableSingleExpressionMediator()
        {
        }

        public NullableSingleExpressionMediator(IExpressionElement expression) : base(expression, typeof(float?))
        {
        }

        protected NullableSingleExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(float?), alias)
        {
        }
        #endregion

        #region as
        public NullSingleElement As(string alias)
            => new NullableSingleExpressionMediator(base.Expression, alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleExpressionMediator obj)
            => obj is NullableSingleExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
