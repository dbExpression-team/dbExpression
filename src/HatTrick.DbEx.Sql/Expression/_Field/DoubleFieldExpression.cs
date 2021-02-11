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
        protected DoubleFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(double), entity)
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
