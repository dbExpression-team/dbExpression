using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableSingleFieldExpression : 
        NullableFieldExpression<float,float?>,
        NullSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleFieldExpression>
    {
        #region constructors
        protected NullableSingleFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        protected NullableSingleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion

        #region as
        public abstract NullSingleElement As(string alias);
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
