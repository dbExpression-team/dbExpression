using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class ObjectPopulationStandardDeviationFunctionExpression :
        PopulationStandardDeviationFunctionExpression<object>,
        ObjectElement,
        AnyObjectElement,
        IEquatable<ObjectPopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public ObjectPopulationStandardDeviationFunctionExpression(AnyObjectElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public ObjectElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion

        #region distinct
        public ObjectPopulationStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(ObjectPopulationStandardDeviationFunctionExpression obj)
            => obj is ObjectPopulationStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ObjectPopulationStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
