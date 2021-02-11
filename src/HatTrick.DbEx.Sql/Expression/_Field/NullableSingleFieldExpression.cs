using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableSingleFieldExpression : 
        NullableFieldExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleFieldExpression>
    {
        #region constructors
        protected NullableSingleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name,  entity)
        {

        }
        #endregion

        #region as
        public abstract NullableSingleElement As(string alias);
        #endregion

        #region equals
        public bool Equals(NullableSingleFieldExpression obj)
            => obj is NullableSingleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
