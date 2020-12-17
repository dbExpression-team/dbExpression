using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SinglePopulationStandardDeviationFunctionExpression :
        PopulationStandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public SinglePopulationStandardDeviationFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(Int16Element expression) : base(expression)
        {

        }
        public SinglePopulationStandardDeviationFunctionExpression(Int32Element expression) : base(expression)
        {
        }

        public SinglePopulationStandardDeviationFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SinglePopulationStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SinglePopulationStandardDeviationFunctionExpression obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
