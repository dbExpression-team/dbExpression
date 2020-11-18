using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class DoubleFieldExpression : 
        FieldExpression<double>,
        DoubleElement,
        AnyDoubleElement,
        IEquatable<DoubleFieldExpression>
    {
        #region constructors
        protected DoubleFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(double), entity)
        {

        }

        protected DoubleFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(double), entity, alias)
        {

        }
        #endregion

        #region as
        public abstract DoubleElement As(string alias);
        #endregion

        #region equals
        public bool Equals(DoubleFieldExpression obj)
            => obj is DoubleFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is DoubleFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
