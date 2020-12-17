using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectPopulationVarianceFunctionExpression :
        PopulationVarianceFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectPopulationVarianceFunctionExpression>
    {
        #region constructors
        public ObjectPopulationVarianceFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
            => new ObjectSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public ObjectPopulationVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectPopulationVarianceFunctionExpression obj)
            => obj is ObjectPopulationVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectPopulationVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
