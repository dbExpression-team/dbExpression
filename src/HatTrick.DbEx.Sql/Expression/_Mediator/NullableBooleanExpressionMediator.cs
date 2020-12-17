using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableBooleanExpressionMediator :
        NullableExpressionMediator<bool,bool?>,
        NullableBooleanElement,
        AnyBooleanElement,
        IEquatable<NullableBooleanExpressionMediator>
    {
        #region constructors
        private NullableBooleanExpressionMediator()
        {
        }

        public NullableBooleanExpressionMediator(IExpressionElement expression) : base(expression, typeof(bool?))
        {
        }

        protected NullableBooleanExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(bool?), alias)
        {
        }
        #endregion

        #region as
        public NullableBooleanElement As(string alias)
            => new NullableBooleanSelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableBooleanExpressionMediator obj)
            => obj is NullableBooleanExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableBooleanExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
