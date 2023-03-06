#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}
#endif

#if !NETCOREAPP3_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class DoesNotReturnAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal class NotNullAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal class CallerArgumentExpressionAttribute : Attribute { public CallerArgumentExpressionAttribute(string _) { } }

    [AttributeUsage(AttributeTargets.Constructor)]
    internal class SetsRequiredMembersAttribute : Attribute { }
}
#endif
