using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.CodeTemplating.Builder
{
    public class TypeBuilder
    {
        private static readonly TypeModel _bool = new TypeModel<bool>("bool");
        private static readonly TypeModel _byte = new TypeModel<byte>("byte");
        private static readonly TypeModel _decimal = new TypeModel<decimal>("decimal");
        private static readonly TypeModel _dateTime = new TypeModel<DateTime>("DateTime");
        private static readonly TypeModel _dateTimeOffset = new TypeModel<DateTimeOffset>("DateTimeOffset");
        private static readonly TypeModel _double = new TypeModel<double>("double");
        private static readonly TypeModel _float = new TypeModel<float>("float");
        private static readonly TypeModel _guid = new TypeModel<Guid>("Guid");
        private static readonly TypeModel _short = new TypeModel<short>("short");
        private static readonly TypeModel _int = new TypeModel<int>("int");
        private static readonly TypeModel _long = new TypeModel<long>("long");
        private static readonly TypeModel _string = new TypeModel<string>("string");
        private static readonly TypeModel _timeSpan = new TypeModel<TimeSpan>("TimeSpan");

        private static readonly Dictionary<Type, TypeModel> allTypes = new Dictionary<Type, TypeModel>()
        {
            { typeof(bool), _bool },
            { typeof(byte), _byte },
            { typeof(decimal), _decimal },
            { typeof(DateTime), _dateTime },
            { typeof(DateTimeOffset), _dateTimeOffset },
            { typeof(double), _double },
            { typeof(float), _float },
            { typeof(Guid), _guid },
            { typeof(short), _short },
            { typeof(int), _int },
            { typeof(long), _long },
            { typeof(string), _string },
            { typeof(TimeSpan), _timeSpan }
       };

        private static readonly Dictionary<Type, TypeModel> numericTypes = new Dictionary<Type, TypeModel>()
        {
            { typeof(byte), _byte },
            { typeof(decimal), _decimal },
            { typeof(double), _double },
            { typeof(float), _float },
            { typeof(short), _short },
            { typeof(int), _int },
            { typeof(long), _long }
        };

        private static readonly Dictionary<Type, TypeModel> dateTypes = new Dictionary<Type, TypeModel>()
        {
            { typeof(DateTime), _dateTime },
            { typeof(DateTimeOffset), _dateTimeOffset }
       };

        private HashSet<TypeModel> @types = new HashSet<TypeModel>();
        private HashSet<TypeModel> exceptTypes = new HashSet<TypeModel>();

        public TypeBuilder AddAllTypes()
        {
            foreach (var @type in allTypes)
                if (!@types.Contains(@type.Value))
                    @types.Add(@type.Value);
            return this;
        }

        public TypeBuilder AddNumericTypes()
        {
            foreach (var @type in numericTypes)
                if (!@types.Contains(@type.Value))
                    @types.Add(@type.Value);
            return this;
        }

        public TypeBuilder AddDateTypes()
        {
            foreach (var @type in dateTypes)
                if (!@types.Contains(@type.Value))
                    @types.Add(@type.Value);
            return this;
        }

        public TypeBuilder Add<T>()
            where T : IComparable
        {
            var t = typeof(T);
            if (!@types.Contains(allTypes[typeof(T)]))
                @types.Add(allTypes[typeof(T)]);
            return this;
        }

        public TypeBuilder Except<T>()
            where T : IComparable
        {
            var t = typeof(T);
            if (!exceptTypes.Contains(allTypes[typeof(T)]))
                exceptTypes.Add(allTypes[typeof(T)]);
            return this;
        }

        public TypeBuilder Except(params Type[] remove)
        {
            foreach (var t in remove)
            {
                if (!exceptTypes.Contains(allTypes[t]))
                    exceptTypes.Add(allTypes[t]);
            }
            return this;
        }

        public List<TypeModel> ToList() => @types.Except(exceptTypes).ToList();

        public static TypeBuilder CreateBuilder()
            => new TypeBuilder();

        public static TypeModel Get<T>()
            => allTypes[typeof(T)];

        public static TypeModel Create<T>()
            => new TypeModel(typeof(T), allTypes[typeof(T)].Alias);

        public static TypeModel Get(Type type)
            => allTypes[type];

        public static TypeModel InferReturnType<TSource, TTarget>()
        {
            return InferReturnType(Get<TSource>(), Get<TTarget>());
        }

        public static TypeModel InferReturnType(TypeModel sourceType, TypeModel targetType)
        {
            if (sourceType == Get<byte>())
            {
                return targetType;
            }
            if (sourceType == Get<decimal>())
            {
                if (targetType == Get<byte>()) return Get<decimal>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<decimal>();
                if (targetType == Get<float>()) return Get<decimal>();
                if (targetType == Get<int>()) return Get<decimal>();
                if (targetType == Get<long>()) return Get<decimal>();
                if (targetType == Get<short>()) return Get<decimal>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<DateTime>())
            {
                if (targetType == Get<string>()) return Get<string>();
                return sourceType;
            }
            if (sourceType == Get<DateTimeOffset>())
            {
                if (targetType == Get<string>()) return Get<string>();
                return sourceType;
            }
            if (sourceType == Get<double>())
            {
                if (targetType == Get<byte>()) return Get<double>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<double>();
                if (targetType == Get<float>()) return Get<double>();
                if (targetType == Get<int>()) return Get<double>();
                if (targetType == Get<long>()) return Get<double>();
                if (targetType == Get<short>()) return Get<double>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<short>())
            {
                if (targetType == Get<byte>()) return Get<short>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<double>();
                if (targetType == Get<float>()) return Get<float>();
                if (targetType == Get<int>()) return Get<int>();
                if (targetType == Get<long>()) return Get<long>();
                if (targetType == Get<short>()) return Get<short>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<int>())
            {
                if (targetType == Get<byte>()) return Get<int>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<double>();
                if (targetType == Get<float>()) return Get<float>();
                if (targetType == Get<int>()) return Get<int>();
                if (targetType == Get<long>()) return Get<long>();
                if (targetType == Get<short>()) return Get<int>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<long>())
            {
                if (targetType == Get<byte>()) return Get<long>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<double>();
                if (targetType == Get<float>()) return Get<float>();
                if (targetType == Get<int>()) return Get<long>();
                if (targetType == Get<long>()) return Get<long>();
                if (targetType == Get<short>()) return Get<long>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<float>())
            {
                if (targetType == Get<byte>()) return Get<float>();
                if (targetType == Get<decimal>()) return Get<decimal>();
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                if (targetType == Get<DateTimeOffset>()) return Get<DateTimeOffset>();
                if (targetType == Get<double>()) return Get<double>();
                if (targetType == Get<float>()) return Get<float>();
                if (targetType == Get<int>()) return Get<float>();
                if (targetType == Get<long>()) return Get<float>();
                if (targetType == Get<short>()) return Get<float>();
                if (targetType == Get<string>()) return Get<string>();
            }
            if (sourceType == Get<TimeSpan>())
            {
                if (targetType == Get<DateTime>()) return Get<DateTime>();
                return sourceType;
            }
            return sourceType;
        }

    }
}
