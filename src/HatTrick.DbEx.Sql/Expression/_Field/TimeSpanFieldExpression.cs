using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract partial class TimeSpanFieldExpression : 
        FieldExpression<TimeSpan>,
        TimeSpanElement,
        AnyTimeSpanElement,
        IEquatable<TimeSpanFieldExpression>
    {
        #region constructors
        protected TimeSpanFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(TimeSpan), entity)
        {

        }
        #endregion

        #region as
        public abstract TimeSpanElement As(string alias);
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
