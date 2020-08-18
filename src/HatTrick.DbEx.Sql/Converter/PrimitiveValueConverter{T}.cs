using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class PrimitiveValueConverter<T> : IValueConverter<T>
    {
        public readonly Func<object, T> to;
        public readonly Func<T, object> from;

        public PrimitiveValueConverter(Func<object, T> to, Func<T, object> from)
        {
            this.to = to;
            this.from = from;
        }

        public T Convert(object value) => to(value);
        public object Convert(T value) => from(value);
    }
}
