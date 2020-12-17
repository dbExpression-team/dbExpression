using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectAverageFunctionExpression :
        AverageFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectAverageFunctionExpression>
    {
        #region constructors
        public ObjectAverageFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ObjectAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectAverageFunctionExpression obj)
            => obj is ObjectAverageFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectAverageFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
