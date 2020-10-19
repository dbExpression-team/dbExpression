using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class TimeSpanFieldExpression : 
        FieldExpression<TimeSpan>,
        IEquatable<TimeSpanFieldExpression>
    {
        #region constructors
        protected TimeSpanFieldExpression(string identifier, EntityExpression entity) : base(identifier, typeof(TimeSpan), entity)
        {

        }

        protected TimeSpanFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, typeof(TimeSpan), entity, alias)
        {

        }
        #endregion

        #region equals
        public bool Equals(TimeSpanFieldExpression obj)
            => obj is TimeSpanFieldExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is TimeSpanFieldExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
