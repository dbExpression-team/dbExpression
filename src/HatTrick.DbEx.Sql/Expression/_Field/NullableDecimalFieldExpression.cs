using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class NullableDecimalFieldExpression : 
        NullableFieldExpression<decimal>,
        IEquatable<NullableDecimalFieldExpression>
    {
        #region constructors
        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(decimal?), entity)
        {

        }

        protected NullableDecimalFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(decimal?), entity, alias)
        {

        }
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
