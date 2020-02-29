using HatTrick.DbEx.CodeTemplating.Builder;
using System;
using System.Linq;

namespace HatTrick.DbEx.CodeTemplating.Model
{
    public static class TypeModelExtensions
    {
        public static bool In(this TypeModel model, params Type[] types)
            => types.FirstOrDefault(t => TypeBuilder.Get(t) == model) != null;

        public static bool In(this Type type, params TypeModel[] types)
            => types.FirstOrDefault(t => TypeBuilder.Get(type) == t) != null;
    }
}
