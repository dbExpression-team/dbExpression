using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class ValueTypeFormatter<TFrom, TTo> : IValueTypeFormatter<TFrom, TTo>
        where TFrom : IConvertible
        where TTo : IComparable
    {
        public virtual TTo Format(TFrom value)
        {
            if (!TryConvert(value, out TTo converted))
                throw new DbExpressionException($"Cannot convert '{value}' from type {typeof(TFrom)} to type {typeof(TTo)}.");

            return converted;
        }

        public object Format(object value)
            => Format((TFrom)value);

        public virtual bool TryConvert(TFrom value, out TTo converted)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(TFrom));
            if (converter.CanConvertTo(typeof(TTo)) && converter.CanConvertFrom(typeof(TFrom)))
            {
                converted = (TTo)converter.ConvertFrom(value);
                return true;
            }
            else
            {
                converted = default;
                return false;
            }
        }
    }
}
