using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EnumToStringValueTypeFormatter : ValueTypeFormatter<Enum, string>
    {
        public override string Format(Enum value)
            => value.ToString();
    }
}
