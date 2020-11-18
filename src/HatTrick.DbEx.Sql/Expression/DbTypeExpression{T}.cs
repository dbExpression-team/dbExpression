using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DbTypeExpression<TEnum> : DbTypeExpression
        where TEnum : Enum
    {
        public new TEnum Expression { get; }

        public DbTypeExpression(TEnum value) : base(value)
        {
            this.Expression = value;
        }

        public override string ToString() => Expression.ToString();
    }
}
