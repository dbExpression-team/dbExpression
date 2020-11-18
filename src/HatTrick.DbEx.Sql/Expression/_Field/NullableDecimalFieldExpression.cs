using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDecimalFieldExpression : 
        NullableFieldExpression<decimal,decimal?>,
        NullDecimalElement,
        AnyDecimalElement,
        IEquatable<NullableDecimalFieldExpression>
    {
        #region constructors
        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullDecimalElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableDecimalFieldExpression obj)
            => obj is NullableDecimalFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableDecimalFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
