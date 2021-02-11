using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableTimeSpanFieldExpression : 
        NullableFieldExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanFieldExpression>
    {
        #region constructors
        protected NullableTimeSpanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public abstract NullableTimeSpanElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanFieldExpression obj)
            => obj is NullableTimeSpanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
