using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableTimeSpanFieldExpression : 
        NullableFieldExpression<TimeSpan,TimeSpan?>,
        NullTimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<NullableTimeSpanFieldExpression>
    {
        #region constructors
        protected NullableTimeSpanFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableTimeSpanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullTimeSpanElement As(string alias);
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
