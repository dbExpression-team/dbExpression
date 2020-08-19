using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DatePartsExpression<TEnum> : DatePartsExpression
        where TEnum : Enum
    {
        public new TEnum Expression { get; }

        public DatePartsExpression(TEnum value) : base(value)
        {
        }
    }
}
